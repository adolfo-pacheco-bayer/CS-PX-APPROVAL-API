using MediatR;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.Application.GoalsPlanning.Queries;
using PX.Approval.Crosscutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOProjectServices(builder.Configuration);
builder.Services.AddMediatr();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/check", () =>
{
    return "Service is running!";
});

app.MapGet("/get-all-goals-planning", async ([FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetAllGoalsPlanningInActiveCropsQuery()
    {

    });
});
app.Run();
