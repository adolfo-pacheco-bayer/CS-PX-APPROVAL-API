using MediatR;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetActiveCropsQueryHandler : IRequestHandler<GetActiveCropsQuery, Response>
    {
        private IResponse _response;
        private ICropServiceClient _cropClient;

        public GetActiveCropsQueryHandler(IResponse response,
                                          ICropServiceClient cropClient)
        {
            _response = response;
            _cropClient = cropClient;
        }

        public async Task<Response> Handle(GetActiveCropsQuery request, CancellationToken cancellationToken)
        {
            var allActiveCrops = await _cropClient.GetAllActiveCrops();

            if (allActiveCrops == null || !allActiveCrops.Any())
            {
                return await _response.CreateErrorResponseAsync(System.Net.HttpStatusCode.NotFound);
            }

            return await _response.CreateSuccessResponseAsync(allActiveCrops);
        }
    }
}
