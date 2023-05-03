using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PX.Library.Common.BayerServices.Models;
using PX.Library.Common.OmegaServices.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PX.Approval.API.Authorization
{
    public class JwtAuthorizationRequirementHandler : AuthorizationHandler<JwtAuthorizationRequirement>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public JwtAuthorizationRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtAuthorizationRequirement requirement)
        {
            var inputToken = _httpContextAccessor.HttpContext?.Request.Headers.Authorization
               .FirstOrDefault()
               ?.Replace("Bearer ", string.Empty);

            IEnumerable<ProfileViewModel>? profiles = null;

            var cwid = _httpContextAccessor.HttpContext?.Request.Headers["CWID"].ToString();

            if (cwid.Equals("system"))
            {
                context.Succeed(requirement);
                return;
            }

            if (string.IsNullOrEmpty(inputToken))
            {
                await Fail(context);
                return;
            }

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(inputToken);

            var expirationTime = jwtSecurityToken.Claims.First(claim => claim.Type == "exp");

            var expirationDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt32(expirationTime.Value)).DateTime;
            if (expirationDate < DateTime.UtcNow)
            {
                await Fail(context);
                return;
            }

            var expiresIn = (expirationDate - DateTime.UtcNow).TotalSeconds;

            var userCwid = jwtSecurityToken?.Claims?.FirstOrDefault(claim => claim.Type == "name")?.Value ?? string.Empty;
            var profileClaim = jwtSecurityToken?.Claims?.FirstOrDefault(claim => claim.Type == "Profiles")?.Value;

            if (profileClaim != null)
                profiles = JsonConvert.DeserializeObject<IEnumerable<ProfileViewModel>>(profileClaim)?.ToList();

            var identity = _httpContextAccessor.HttpContext?.User.Identities.FirstOrDefault();
            identity?.AddClaim(new Claim("cwid", userCwid));

            var roles = new List<RoleViewModel>();
            IEnumerable<LevelViewModel>? levels = null;

            foreach (var profile in profiles)
            {
                roles.Add(new RoleViewModel()
                {
                    ApproveRequired = true,
                    Description = profile.Description,
                    Name = profile.Name,
                    Level = new()
                    {
                        Name = profile.Description,
                        RestrictionCodes = profile.Level?.RestrictionCodes.ToList()
                    }
                });
            }

            var user = JsonConvert.SerializeObject(new LoginSSOViewModel()
            {
                Email = userCwid,
                NameUser = userCwid,
                Roles = roles,
                Cwid = cwid,
            });

            identity?.AddClaim(new Claim("user", user));
            context.Succeed(requirement);
        }

        private async Task Fail(AuthorizationHandlerContext context)
        {
            _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
            await _httpContextAccessor.HttpContext.Response.WriteAsJsonAsync(new { StatusCode = StatusCodes.Status401Unauthorized, Message = "Unauthorized. You must provide a valid jwt token." });
            await _httpContextAccessor.HttpContext.Response.CompleteAsync();

            context.Fail();
        }
    }
}
