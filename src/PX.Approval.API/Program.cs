using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using PX.Approval.API.Authorization;
using PX.Approval.API.Routes;
using PX.Approval.Crosscutting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

});

builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.MaxDepth = 1;
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});


builder.Services.AddProjectServices(builder.Configuration);
builder.Services.AddMediatr();
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("Omega", p => p.AddRequirements(new JwtAuthorizationRequirement()));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationHandler, JwtAuthorizationRequirementHandler>();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        ModifyConnectionSettings = x => x.ApiKeyAuthentication(new Elasticsearch.Net.ApiKeyAuthenticationCredentials(configuration["ElasticConfiguration:ApiKey"])),
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}-{DateTime.UtcNow:yyyy-MM}",
        FailureCallback = fc =>
        {
            Console.WriteLine($"Erro: {fc.Exception}");
        }
    })
    .WriteTo.Console(Serilog.Events.LogEventLevel.Verbose)
    .Enrich.WithProperty("Environment", environment)
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndPoints();

app.UseMiddleware();

app.Run();
