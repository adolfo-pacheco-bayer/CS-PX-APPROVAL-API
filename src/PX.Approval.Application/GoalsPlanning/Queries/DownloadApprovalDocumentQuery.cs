using MediatR;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries;

public class DownloadApprovalDocumentQuery : IRequest<FileStreamResult>
{
    public string FileName { get; set; }
    public Guid GoalsPlanningIntegrationId { get; set; }

    public DownloadApprovalDocumentQuery(string fileName, Guid goalsPlanningIntegrationId)
    {
        FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        GoalsPlanningIntegrationId = goalsPlanningIntegrationId;
    }
}
