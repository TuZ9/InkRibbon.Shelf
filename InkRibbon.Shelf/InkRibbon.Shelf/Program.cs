using InkRibbon.Shelf.Application.Static;
using InkRibbon.Shelf.Infra.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
RunTimeConfig.SetConfigs(builder.Configuration);
builder.Services.AddHttpClients();
builder.Services.AddServices();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("All", opt => opt
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed(hostname => true)));

builder.WebHost.UseKestrel(so =>
{
    so.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(10000);
    so.Limits.MaxRequestBodySize = 52428800;
    so.Limits.MaxConcurrentConnections = 100;
    so.Limits.MaxConcurrentConnections = 100;
});
builder.Services.AddEndpointsApiExplorer();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] - {Message}{NewLine}{Exception}")
    .Enrich.WithDemystifiedStackTraces()
    .Enrich.FromLogContext()
    .CreateLogger();

var app = builder.Build();
var serviceProvider = builder.Services.BuildServiceProvider();
HangireJobs.RunHangFireJob(serviceProvider);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
