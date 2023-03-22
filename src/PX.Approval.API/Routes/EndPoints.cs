using MediatR;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.API.Models;
using PX.Approval.Application.GoalsPlanning.Commands;
using PX.Approval.Application.GoalsPlanning.Queries;

namespace PX.Approval.API.Routes
{
    public static class Endpoints
    {

        public static void MapEndPoints(this WebApplication app)
        {
            app.MapGet("api/approval/check", () =>
            {
                return "Service is running!";
            });

            app.MapGet("api/approval/get-active-crops", async ([FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetActiveCropsQuery());
            }).RequireAuthorization("Omega");

            app.MapGet("api/approval/get-all-goals-planning/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetAllGoalsPlanningInActiveCropsQuery()
                {
                    CropIntegrationId = cropintegrationid
                });
            });

            app.MapGet("api/approval/get-user-info", async ([FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetUserInfoQuery());
            }).RequireAuthorization("Omega");

            app.MapGet("api/approval/getgraphicstatus/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetGraphicStatusQuery()
                {
                    CropIntegrationId = cropintegrationid
                });
            });

            app.MapPut("api/approval/return-status-goals-planning", async ([FromServices] IMediator mediator, [FromBody]ReturnStatusRequest request) =>
            {
                return await mediator.Send(new ReturnStatusGoalsPlanningCommand(request.Reason, request.GoalsPlanningIntegrationIds.ToList()));
            }).RequireAuthorization("Omega");

            app.MapPut("api/approval/approve-goals-planning", async ([FromServices] IMediator mediator, [FromBody] ApproveRequest request) =>
            {
                return await mediator.Send(new ApproveGoalsPlanningCommand(request.GoalsPlanningIntegrationIds.ToList()));
            }).RequireAuthorization("Omega");

            app.MapPut("api/approval/reprove-goals-planning", async ([FromServices] IMediator mediator, [FromBody] ReproveRequest request) =>
            {
                return await mediator.Send(new ReproveGoalsPlanningCommand(request.Reason, request.File, request.GoalsPlanningIntegrationIds.ToList()));
            }).RequireAuthorization("Omega");
        }
    }
}

