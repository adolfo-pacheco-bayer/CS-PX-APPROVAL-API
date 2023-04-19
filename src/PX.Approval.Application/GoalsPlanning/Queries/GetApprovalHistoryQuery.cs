using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries;

public class GetApprovalHistoryQuery : IRequest<Response>
{
    public Guid CropIntegrationId { get; private set; }

	public GetApprovalHistoryQuery(Guid cropIntegrationId)
	{
		CropIntegrationId = cropIntegrationId;
	}
}
