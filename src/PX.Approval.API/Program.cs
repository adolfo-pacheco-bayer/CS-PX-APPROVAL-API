using PX.Approval.API.Routes;
using PX.Approval.Crosscutting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProjectServices(builder.Configuration);
builder.Services.AddMediatr();

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

app.MapEndPoints();

app.UseMiddleware();

app.Run();
