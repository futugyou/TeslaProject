namespace Api;

public static class VehicleEndpoints
{
    public static void UseVehicleEndpoints(this IEndpointRouteBuilder app)
    {
        var vehicleGroup = app.MapGroup("/vehicle")
                .WithName("vehicle")
                .WithOpenApi();

        vehicleGroup.MapPost("/sync", VehicleSync).WithName("sync").WithDescription("This API sync data from tesla api");
        vehicleGroup.MapGet("/{vin}", VehicleInfo).WithName("local").WithDescription("This API only get vehicle data from local db");
        vehicleGroup.MapGet("/{vin}/state", VehicleState).WithName("state");
        vehicleGroup.MapPost("/{vin}/ws", VehicleWebSocket).WithName("ws");
    }

    static async Task<IResult> VehicleSync([FromServices] IVehicleRepository repo, [FromServices] IVehicleState state, [FromServices] IUnitOfWork unitOfWork)
    {
        var token = "";//TODO get token
        var vehcileList = await state.GetUserVehicles(token);
        if (vehcileList == null || vehcileList.Count < 1)
        {
            return TypedResults.NotFound();
        }

        var taskList = new List<Task>();
        foreach (var item in vehcileList.Response)
        {
            var vehicle = await repo.GetByVin(item.Vin);
            if (vehicle == null)
            {
                vehicle = new Vehicle
                {
                    Vid = item.Id,
                    Vin = item.Vin
                };
                taskList.Add(repo.Add(vehicle));
            }
            else
            {
                vehicle.Name = item.DisplayName;
                taskList.Add(repo.Update(vehicle));
            }
        }

        await unitOfWork.CommitAsync(CancellationToken.None);
        // await Task.WhenAll(taskList);
        return TypedResults.Ok();
    }

    static async Task<IResult> VehicleInfo([FromServices] IVehicleRepository repo, string vin)
    {
        var vehicle = await repo.GetByVin(vin);
        if (vehicle == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(vehicle);
    }

    static async Task<IResult> VehicleState([FromServices] IVehicleRepository repo, [FromServices] IVehicleState state, string vin)
    {
        var vehicle = await repo.GetByVin(vin);
        if (vehicle == null)
        {
            return TypedResults.NotFound();
        }

        var token = "";//TODO get token
        var vehicleState = await state.GetUserVehicleById(vehicle.Vid.ToString(), token);

        // TODO: store the data
        if (vehicleState == null || vehicleState.Response == null)
        {
            return TypedResults.NotFound();
        }

        if (vehicleState.Response.State != "online")
        {
            return TypedResults.Ok(vehicleState.Response);
        }

        // TODO: call this api may wakeup car, need some limit
        // TODO: store the data
        var vehicleData = await state.GetVehicleData(vehicle.Vid.ToString(), token);
        return TypedResults.Ok(vehicleData?.Response);
    }

    static async Task<IResult> VehicleWebSocket([FromServices] IVehicleRepository repo, [FromServices] IBackgroundTaskQueue queue, string vin)
    {
        var vehicle = await repo.GetByVin(vin);
        if (vehicle == null)
        {
            return TypedResults.NotFound();
        }

        var token = "";//TODO get token
        StreamRequest rquest = new()
        {
            VinID = vehicle.Vid,
            Token = token,
        };
        var pararmeter = new TaskQueueParameter
        {
            IdentityKey = vin,
            Parameter = rquest,
        };
        // send to queue
        await queue.QueueBackgroundWorkItemAsync(ConnectVehicleStream, pararmeter);
        return TypedResults.Ok();
    }

    static async ValueTask ConnectVehicleStream(IServiceProvider sp, object state, CancellationToken stoppingToken)
    {
        using var scope = sp.CreateScope();
        var redis = scope.ServiceProvider.GetRequiredService<IRedisClient>();
        var service = scope.ServiceProvider.GetRequiredService<IVehicleStreamService>();

        StreamRequest request = (StreamRequest)state;

        try
        {
            await service.HandleStreamRequest(request, stoppingToken);
        }
        finally
        {
            await redis.UnLock(request.Vin, request.Vin);
        }
    }
}