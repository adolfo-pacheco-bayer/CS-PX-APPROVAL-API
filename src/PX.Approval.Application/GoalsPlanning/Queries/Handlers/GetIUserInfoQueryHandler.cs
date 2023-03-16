using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Library.Common.BayerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetIUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, Response>
    {
        private IResponse _response;
        private IHttpContextAccessor _httpContextAccessor;

        public GetIUserInfoQueryHandler(IResponse response,
                                        IHttpContextAccessor httpContextAccessor)
        {
            _response = response;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<Response> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = JsonConvert.DeserializeObject<LoginSSOViewModel>(_httpContextAccessor.HttpContext?.User.FindFirst("user").Value);

            if (user == null)
            {
                return _response.CreateErrorResponseAsync(System.Net.HttpStatusCode.NotFound);
            }

            return _response.CreateSuccessResponseAsync(user);
        }
    }
}
