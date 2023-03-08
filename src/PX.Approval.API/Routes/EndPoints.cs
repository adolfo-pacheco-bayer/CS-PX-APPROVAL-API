using MediatR;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.Application.GoalsPlanning.Queries;

namespace PX.Approval.API.Routes
{
    public  static class Endpoints
    {

        public static void MapEndPoints(this WebApplication app)
        {
            app.MapGet("/check",() =>
            {
                return "Service is running!";
            });

            app.MapGet("/get-all-goals-planning", async ([FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetAllGoalsPlanningInActiveCropsQuery()
                {
                });
            });
        }
    }
}
