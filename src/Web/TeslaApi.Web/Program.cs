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

var serverVersion = new MySqlServerVersion(new Version(Configuration["MysqlVersion"]!));
builder.Services.AddDbContextPool<UserContext>(
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
builder.Services.AddTeslaApiLibary(Configuration);

builder.Services.AddHostedService<TeslaWebSocketClient>();
builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
{
    if (!int.TryParse(Configuration["QueueCapacity"], out var queueCapacity))
        queueCapacity = 100;
    return new BackgroundTaskQueue(queueCapacity);
});

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
app.MapGet("/vehicle/{vid}", async ([FromServices] IBackgroundTaskQueue queue, int vid) =>
{
    // TODO:check Vehicle state
    StreamRequest rquest = new()
    {
        Vin = "fake-tag-1126116947848350",
        Token = "fake-token-DC.eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJvcmdfaWQiOjI5NTM3NjU3OTk0LCJqdGkiOjcyNTQ3OTY0NTUxNzgyMzEzNzJ9.LWi3JiOfc_wl54880fmwEUJzwwsKCI5xkO3EPlj40lM",

    };
    // send to queue
    await queue.QueueBackgroundWorkItemAsync(ConnectVehicleStream, rquest);

    return vid;
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



app.Run();

static async ValueTask ConnectVehicleStream(IServiceProvider sp, CancellationToken stoppingToken, object state)
{
    using var scope = sp.CreateScope();
    var teslaStream = scope.ServiceProvider.GetRequiredService<ITeslaStream>();
    var _logger = scope.ServiceProvider.GetRequiredService<ILogger<ITeslaStream>>();
    await teslaStream.StartAsync(stoppingToken);

    try
    {
        StreamRequest rquest = (StreamRequest)state;
        await teslaStream.ReceiveAsync(rquest, stoppingToken);
    }
    catch (Exception ex)
    {
        _logger.LogError("{Message}", ex.Message);
    }

    await teslaStream.StopAsync(stoppingToken);
}
