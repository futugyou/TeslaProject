using Microsoft.AspNetCore.Mvc;
using TeslaApi.Web;
using Microsoft.EntityFrameworkCore;
using Infrastruct;
using Domain;
using Extensions;
using TeslaApi.Extensions.DependencyInjection;
using TeslaApi.Contract;
using TeslaApi.Abstractions;
using TeslaApi.Contract.Authentication;

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

builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IWeixinRepository, WeixinRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IChargesDetailRepository, ChargesDetailRepository>();
builder.Services.AddScoped<IChargesRepository, ChargesRepository>();
builder.Services.AddScoped<IDriveRepository, DriveRepository>();
builder.Services.AddScoped<IGeofenceRepository, GeofenceRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();

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
app.MapGet("/vehicle", async ([FromServices] IBackgroundTaskQueue queue, [FromQuery] string vin, [FromQuery] string token) =>
{
    // TODO:check Vehicle state
    StreamRequest rquest = new()
    {
        Vin = vin,
        Token = token,

    };
    var pararmeter = new TaskQueueParameter
    {
        IdentityKey = vin,
        Parameter = rquest,
    };
    // send to queue
    await queue.QueueBackgroundWorkItemAsync(ConnectVehicleStream, pararmeter);

    return vin;
})
.WithName("vehicle")
.WithOpenApi();

// this is test
app.MapGet("/token", async ([FromServices] ITeslaAuthentication tesla, [FromQuery] string code, [FromQuery] string verifier) =>
{
    var request = new AccessTokenRequest
    {
        Code = code,
        CodeVerifier = verifier,
    };
    var result = await tesla.GetAccessToken(request);
    return result;
})
.WithName("token")
.WithOpenApi();


// this is test
app.MapGet("/user", async ([FromServices] IUser tesla, [FromQuery] string token) =>
{
    var result = await tesla.UserInformation(token);
    return result;
})
.WithName("user")
.WithOpenApi();

// this is test
app.MapGet("/check", ([FromQuery] string token) =>
{
    var result = TokenParse.CheckTokenLocal(token);
    return result;
})
.WithName("check")
.WithOpenApi();


app.Run();

static async ValueTask ConnectVehicleStream(IServiceProvider sp, object state, CancellationToken stoppingToken)
{
    using var scope = sp.CreateScope();
    var teslaStream = scope.ServiceProvider.GetRequiredService<ITeslaStream>();
    var redis = scope.ServiceProvider.GetRequiredService<IRedisClient>();
    var _logger = scope.ServiceProvider.GetRequiredService<ILogger<ITeslaStream>>();
    await teslaStream.StartAsync(stoppingToken);

    StreamRequest rquest = (StreamRequest)state;
    try
    {
        await teslaStream.ReceiveAsync(rquest, stoppingToken);
    }
    catch (Exception ex)
    {
        _logger.LogError("{Message}", ex.Message);
    }
    finally
    {
        await redis.UnLock(rquest.Vin, rquest.Vin);
    }

    await teslaStream.StopAsync(stoppingToken);
}
