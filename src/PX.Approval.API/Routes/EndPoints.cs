    using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            
            app.MapPut("api/approval/return-status-goals-planning", async (HttpRequest request, string? fileName, string payload, IMediator mediator) =>
            {
                using var reader = new StreamReader(request.Body, System.Text.Encoding.UTF8);

                using var ms = new MemoryStream();
                await reader.BaseStream.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

                var p = JsonConvert.DeserializeObject<ReturnStatusRequest>(payload);

                return await mediator.Send(new ReturnStatusGoalsPlanningCommand(p.Reason, fileBytes, fileName, p.GoalsPlanningIntegrationIds.ToList()));

            }).RequireAuthorization("Omega").Accepts<IFormFile>("application/pdf");
            
            app.MapPut("api/approval/cancel-goals-planning", async (HttpRequest request, string? fileName, string payload, IMediator mediator) =>
            {
                using var reader = new StreamReader(request.Body, System.Text.Encoding.UTF8);

                using var ms = new MemoryStream();
                await reader.BaseStream.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

                var p = JsonConvert.DeserializeObject<CancelRequest>(payload);

                return await mediator.Send(new CancelGoalsPlanningCommand(p.Reason, fileBytes, fileName, p.GoalsPlanningIntegrationIds.ToList()));

            }).RequireAuthorization("Omega").Accepts<IFormFile>("application/pdf");

            app.MapGet("api/approval/graphic-partnertype/{cropintegrationid}", async (Guid cropintegrationid, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetGraphicsPartnerTyperQuery()
                {
                    CropIntegrationId = cropintegrationid
                });
            });



            app.MapGet("api/approval/brands/{goalsPlanningId}/valued", async (Guid goalsPlanningId, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetAllValuedCPBrandByGoalsPlanningQuery()
                {
                    GoalsPlanningId = goalsPlanningId
                }); ;
            });

            app.MapGet("api/approval/brands/{goalsPlanningId}/volume", async (Guid goalsPlanningId, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetAllVolumeCPBrandByGoalsPlanningQuery()
                {
                    GoalsPlanningId = goalsPlanningId
                }); ;
            });

            app.MapGet("api/approval/all-inapproval-goals-planning/{cropIntegrationId}", async (Guid cropIntegrationId, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetInApprovalGoalsPlanningQuery(cropIntegrationId));
            });

            app.MapPut("api/approval/approve-goals-planning", async ([FromServices] IMediator mediator, [FromBody] ApproveRequest request) =>
            {
                return await mediator.Send(new ApproveGoalsPlanningCommand(request.GoalsPlanningIntegrationIds.ToList()));
            }).RequireAuthorization("Omega");

            app.MapPut("api/approval/reprove-goals-planning", async (HttpRequest request, string? fileName, string payload, IMediator mediator) =>
            {
                using var reader = new StreamReader(request.Body, System.Text.Encoding.UTF8);

                using var ms = new MemoryStream();
                await reader.BaseStream.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

                var p = JsonConvert.DeserializeObject<ReproveRequest>(payload);

                return await mediator.Send(new ReproveGoalsPlanningCommand(p.Reason, fileBytes, fileName, p.GoalsPlanningIntegrationIds.ToList()));

            }).RequireAuthorization("Omega").Accepts<IFormFile>("application/pdf");

            app.MapGet("api/approval/brands/{goalsPlanningId}/seeds", async (Guid goalsPlanningId, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetBrandSeedsGoalsPlanningQuery()
                {
                    GoalsPlanningId = goalsPlanningId
                }); ;
            });


            app.MapGet("api/approval/goals-planning/crop/{cropintegrationid}", async (string? partnerType, string? name, Guid cropintegrationid, string? status, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetGoalsPlanningsQuery()
                {
                    CropIntegrationId = cropintegrationid,
                    Status = status, 
                    Name = name,
                    PartnerType = partnerType
                }); 
            });

            app.MapGet("api/approval/history/{goalsplanningintegrationId}", async (Guid goalsPlanningIntegrationId, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(new GetApprovalHistoryQuery(goalsPlanningIntegrationId)); 
            });

            app.MapGet("api/approval/{goalsplanningIntegrationId}/document/download/{fileName}", async (Guid goalsPlanningIntegrationId, string fileName, [FromServices] IMediator mediator) =>
            {
                var file =  await mediator.Send(new DownloadApprovalDocumentQuery(fileName, goalsPlanningIntegrationId));

                if (file is null)
                    return Results.NotFound();

                return Results.File(file.FileStream, file.ContentType, file.FileDownloadName);

            }).RequireAuthorization("Omega");

            app.MapGet("api/approval/{goalsplanningIntegrationId}/partner/{partnerIntegrationId}/export", async (Guid goalsPlanningIntegrationId, Guid partnerIntegrationId, [FromServices] IMediator mediator) =>
            {
                var file = await mediator.Send(new ExportExcelModelQuery(goalsPlanningIntegrationId, partnerIntegrationId));

                if (file is null)
                    return Results.NotFound();

                file.FileStream.Position = 0;
                return Results.File(file.FileStream, file.ContentType, file.FileDownloadName);

            });
        }
    }
}

