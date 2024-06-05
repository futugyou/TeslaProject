using TeslaApi.Web;
using Microsoft.EntityFrameworkCore;
using Infrastruct;
using Domain;
using Extensions;
using TeslaApi.Extensions.DependencyInjection;
using Api;
using Services;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddRedisExtension(Configuration);
builder.Services.AddBackgroundTaskQueue(Configuration);

var serverVersion = new MySqlServerVersion(new Version(Configuration["MysqlVersion"]!));
builder.Services.AddDbContextPool<TeslaContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(Configuration.GetConnectionString("Default"), serverVersion)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// NOTES: do not use in prod
builder.Services.AddHostedService<RecreateDatabaseHostedService<TeslaContext>>();
builder.Services.AddMQMassTransit(Configuration);

builder.Services.AddScoped<IVehicleStreamService, VehicleStreamService>();

builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IWeixinRepository, WeixinRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IChargesDetailRepository, ChargesDetailRepository>();
builder.Services.AddScoped<IChargesRepository, ChargesRepository>();
builder.Services.AddScoped<IDriveRepository, DriveRepository>();
builder.Services.AddScoped<IGeofenceRepository, GeofenceRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IVehicleMessageRepository, VehicleMessageRepository>();

builder.Services.AddScoped<RefreshTokenHandler>();

builder.Services.AddTeslaApiLibary(Configuration, option =>
{
    option.AddPolicyHandler(PolicyExtensions.GetTokenRefresher);
    option.AddHttpMessageHandler<RefreshTokenHandler>();
});

builder.Services.AddHostedService<TeslaWebSocketClient>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWeixinRequest();

app.MapRazorPages();

app.UseVehicleEndpoints();

// this is test
app.UseTestEndpoints();

app.Run();
