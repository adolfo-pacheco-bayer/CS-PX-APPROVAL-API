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

            app.MapGet("api/approval/active-crops", async ([FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetActiveCropsQuery());
            }).RequireAuthorization("Omega");

            app.MapGet("api/approval/all-goals-planning/crop/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetAllGoalsPlanningInActiveCropsQuery()
                {
                    CropIntegrationId = cropintegrationid
                });
            });

            app.MapGet("api/approval/user-info", async ([FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetUserInfoQuery());
            }).RequireAuthorization("Omega");

            app.MapGet("api/approval/planning-total/crop/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetPlanningTotalQuery()
                {
                    CropIntegrationId = cropintegrationid
                });
            });

            app.MapGet("api/approval/graphic-status/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
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

            
            app.MapGet("api/approval/graphic-partnertype/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetGraphicsPartnerTyperQuery()
                {
                    CropIntegrationId = cropintegrationid
                });
            });

            app.MapGet("api/approval/all-inapproval-goals-planning", async (Guid[] cropintegrationids, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetInApprovalGoalsPlanningQuery(cropintegrationids.ToList()));
            });
        }
    }
}

