using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Library.Common.BayerServices.Models;
using PX.Library.Common.OmegaServices.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PX.Approval.Application.Common.PipelineBehaviours
{
    public  class AuthorizeBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
    {
        private readonly ILogger<AuthorizeBehaviour<TRequest, TResponse>> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IResponse _response;

        public AuthorizeBehaviour(ILogger<AuthorizeBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public AuthorizeBehaviour(ILogger<AuthorizeBehaviour<TRequest, TResponse>> logger, IHttpContextAccessor httpContextAccessor, IResponse response)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _response = response;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var inputToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]
                 .FirstOrDefault()
                 ?.Replace("Bearer ", string.Empty);

            IEnumerable<ProfileViewModel>? profiles = null;


            var cwid = _httpContextAccessor.HttpContext.Request.Headers["CWID"].ToString();

            if (cwid.Equals("system"))
            {
                return await next();
            }

            if (string.IsNullOrEmpty(inputToken))
            {
                return (TResponse)(await _response.CreateErrorResponseAsync(new UnauthorizedResult(), System.Net.HttpStatusCode.Unauthorized));
            }
            else
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(inputToken);

                var expirationTime = jwtSecurityToken.Claims.First(claim => claim.Type == "exp");

                var expirationDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt32(expirationTime.Value)).DateTime;
                if (expirationDate < DateTime.UtcNow)
                {
                    return (TResponse)(await _response.CreateErrorResponseAsync(new UnauthorizedResult(), System.Net.HttpStatusCode.Unauthorized));

                }

                var expiresIn = (expirationDate - DateTime.UtcNow).TotalSeconds;

                var userCwid = jwtSecurityToken?.Claims?.FirstOrDefault(claim => claim.Type == "name")?.Value ?? string.Empty;
                var profileClaim = jwtSecurityToken?.Claims?.FirstOrDefault(claim => claim.Type == "Profiles")?.Value;

                if (profileClaim != null)
                    profiles = JsonConvert.DeserializeObject<IEnumerable<ProfileViewModel>>(profileClaim)?.ToList();

                var identity = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault();
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
                    Cwid = userCwid,
                });

                identity?.AddClaim(new Claim("user", user));
            }
        
            return await next();
        }
    }
}
