using MediatR;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.Application.GoalsPlanning.Queries;

namespace PX.Approval.API.Routes
{
    public  static class Endpoints
    {

        public static void MapEndPoints(this WebApplication app)
        {
            app.MapGet("api/approval/check",() =>
            {
                return "Service is running!";
            });

            app.MapGet("api/approval/get-all-goals-planning/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetAllGoalsPlanningInActiveCropsQuery()
                {
                    CropIntegrationId = cropintegrationid
                });
            });
        }
    }
}
