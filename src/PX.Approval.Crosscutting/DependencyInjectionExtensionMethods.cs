using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Approval.Infrastructure.Services.Crop;
using PX.Approval.Infrastructure.Services.ElasticSearch;
using PX.Approval.Infrastructure.Services.GoalsPlanning;
using PX.Crop.Application.Common.PipelineBehaviours;
using System.Reflection;



namespace PX.Approval.Crosscutting;

public static class DependencyInjectionExtensionMethods
{
    private const string applicationProjectName = "PX.Approval.Application";

    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.Load("PX.Approval.Application");

        services.Configure<GoalsPlanningClientConfiguration>(configuration.GetSection(GoalsPlanningClientConfiguration.GoalsPlanningOptions));
        services.Configure<CropClientConfiguration>(configuration.GetSection(CropClientConfiguration.CropClientOptions));
        services.AddScoped<IResponse, Response>();
        services.AddScoped<IGoalsPlanningClient, GoalsPlanningGrpcClient>();
        services.AddScoped<ICropServiceClient, CropGrpcClient>();
        services.AddAutoMapper(assembly);



        //Not change order below. This order determines an logic sequence of a pipeline
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));          //1st

        return services;
    }

    public static void AddMediatr(this IServiceCollection services)
    {
        var assembly = Assembly.Load(applicationProjectName);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }

    public static void UseMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }


    public static IServiceCollection AddProjectRepository(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<IElasticSearchServiceClient, ElasticSearchService>();

        return services;
    }

}