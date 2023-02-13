using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.Common.PipelineBehaviours;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Approval.Infrastructure.Services.Crop;
using PX.Approval.Infrastructure.Services.GoalsPlanning;
using PX.Library.Common.OmegaServices;
using System.Reflection;

namespace PX.Approval.Crosscutting;

public static class DependencyInjectionExtensionMethods
{
    private const string applicationProjectName = "PX.Approval.Application";

    public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.Load(applicationProjectName);
        //services.AddAutoMapper(assembly);

        services.AddScoped<IResponse, Response>();
        services.AddScoped<IGoalsPlanningClient, GoalsPlanningGrpcClient>();
        services.AddScoped<ICropServiceClient, CropGrpcClient>();
        services.AddHttpContextAccessor();
        services.AddMediatr();
        services.AddHttpContextAccessor();

        #region "Pipeline"
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthorizeBehaviour<,>));   //1st


        #endregion
        return services;
    }

    public static void AddMediatr(this IServiceCollection services)
    {
        var assembly = Assembly.Load(applicationProjectName);

        //Fluent Validation Validators
        AssemblyScanner
            .FindValidatorsInAssembly(assembly)
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

        //IDomainValidationHandlers Validators
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo<IDomainValidationHandler>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.AddMediatR(assembly);
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOmegaDependencyInjection(services => {
            services.Configure<OmegaConfiguration>(configuration.GetSection(OmegaConfiguration.Omega));
        });

        return services;
    }

    public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GoalsPlanningClientConfiguration>(configuration.GetSection(GoalsPlanningClientConfiguration.GoalsPlanningOptions));
        services.Configure<CropClientConfiguration>(configuration.GetSection(CropClientConfiguration.CropClientOptions));
        return services;
    }


}