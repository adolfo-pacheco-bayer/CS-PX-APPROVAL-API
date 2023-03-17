using MediatR;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.API.Models;
using PX.Approval.Application.GoalsPlanning.Commands;
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

            app.MapGet("api/approval/get-all-goals-planning", async ([FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetAllGoalsPlanningInActiveCropsQuery()
                {
                });
            });

            app.MapPut("api/approval/return-status-goals-planning", async ([FromServices] IMediator mediator, [FromBody]ReturnStatusRequest request) =>
            {
                return await mediator.Send(new ReturnStatusGoalsPlanningCommand(request.Reason, request.GoalsPlanningIntegrationIds.ToList()));
            });
        }
    }
}

