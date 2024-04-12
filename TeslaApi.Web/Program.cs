using Microsoft.AspNetCore.Mvc;
using TeslaApi;
using TeslaApi.Abstractions;
using TeslaApi.Web;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddHostedService<TeslaWebSocketClient>();
builder.Services.AddTransient<ITeslaStream, TeslaStream>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/vehicle/{vid}", async ([FromServices] IBackgroundTaskQueue queue, int vid) =>
{
    // TODO:check Vehicle state
    Console.WriteLine(vid);
    // send queue
    await queue.QueueBackgroundWorkItemAsync(ConnectVehicleStream);

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("vehicle")
.WithOpenApi();

app.Run();

static async ValueTask ConnectVehicleStream(IServiceProvider sp, CancellationToken stoppingToken)
{
    using var scope = sp.CreateScope();
    var teslaStream = scope.ServiceProvider.GetRequiredService<ITeslaStream>();
    var _logger = scope.ServiceProvider.GetRequiredService<ILogger<ITeslaStream>>();
    await teslaStream.StartAsync(stoppingToken);

    if (!stoppingToken.IsCancellationRequested)
    {
        try
        {
            await teslaStream.ReceiveAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    await teslaStream.StopAsync(stoppingToken);
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

