using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries
{
    public class GetGraphicStatusQuery :  IRequest<Response>
    {
        public Guid CropIntegrationId { get; set; }

    }
}
