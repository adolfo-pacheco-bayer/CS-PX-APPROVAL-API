using MediatR;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.Application.Common.Interfaces;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class ExportExcelModelQueryHandler : IRequestHandler<ExportExcelModelQuery, FileStreamResult>
    {
        private IGoalsPlanningClient _goalsPlanningClient;

        public ExportExcelModelQueryHandler(IGoalsPlanningClient goalsPlanningClient)
        {
            _goalsPlanningClient = goalsPlanningClient;
        }

        public async Task<FileStreamResult> Handle(ExportExcelModelQuery request, CancellationToken cancellationToken)
        {
            var result = await _goalsPlanningClient.ExportExcelModel(request.GoalsPlanningIntegrationId, request.PartnerIntegrationId);

            return new FileStreamResult(result, "application/octet-stream")
            {
                FileDownloadName = "GoalsPlanningExport.xlsx"
            };
        }
    }
}
