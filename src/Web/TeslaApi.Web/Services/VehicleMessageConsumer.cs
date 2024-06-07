using System.Reflection;
using Domain;
using Extensions;
using MassTransit;
using TeslaApi.Contract.Vehicle.State.Data;

namespace Services;

public class VehicleMessageConsumer : IConsumer<VehicleMessage>
{
    readonly string[] ShiftWithoutP = ["D", "N", "R"];
    private readonly ILogger<VehicleMessageConsumer> _logger;
    private readonly IPositionRepository _positionRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IDriveRepository _driveRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VehicleMessageConsumer(ILogger<VehicleMessageConsumer> logger,
    IPositionRepository positionRepository,
    IVehicleRepository vehicleRepository,
    IDriveRepository driveRepository,
    IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _positionRepository = positionRepository;
        _vehicleRepository = vehicleRepository;
        _driveRepository = driveRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<VehicleMessage> context)
    {
        var data = Util.ConvertStringToType<VehicleStreamData>(context.Message.Raw);
        if (data == null)
        {
            return;
        }

        // TODO: get last vehicle state. it may cached in db or redis
        VehicleDataDetail detail = new() { State = "online" };

        var vehicle = await _vehicleRepository.GetByVid(detail.Id);
        if (vehicle == null)
        {
            return;
        }

        switch (detail.State)
        {
            case "online":
                await HandleOnline(vehicle, detail, data, context.Message, context.CancellationToken);
                break;
        }

        _logger.LogError("Value: {Value}", data.ShiftState);
    }

    private async Task HandleOnline(Vehicle vehicle, VehicleDataDetail detail, VehicleStreamData data, VehicleMessage message, CancellationToken cancellation)
    {
        // get tesla state 
        if (ShiftWithoutP.Contains(data.ShiftState))
        {
            var position = await StartDrive(vehicle, detail, data, cancellation);
        }
        // other case
    }

    private async Task<(Drive, Position)> StartDrive(Vehicle vehicle, VehicleDataDetail detail, VehicleStreamData stream_data, CancellationToken cancellation)
    {
        // fill other data when stop
        Drive drive = new()
        {
            VehicleId = vehicle,
        };

        // TODO: fill flied
        Position position = new()
        {
            VehicleId = vehicle,
            // Date = stream_data.Time,
            Latitude = (decimal)stream_data.EstLat,
            Longitude = (decimal)stream_data.EstLng,
            Power = (decimal)stream_data.Power,
            Speed = (decimal)stream_data.Speed,
            BatteryLevel = (decimal)stream_data.SOC,
            Elevation = (decimal)stream_data.Elevation,
            Odometer = stream_data.Odometer
        };

        await _driveRepository.Add(drive);
        await _positionRepository.Add(position);
        await _unitOfWork.CommitAsync(cancellation);

        return (drive, position);
    }
}


/// <summary>
/// Represents the vehicle's telemetry data.
/// </summary>
public class VehicleStreamData
{
    /// <summary>
    /// Vehicle speed in kilometers per hour.
    /// </summary>
    [DataPosition(0)]
    public double Speed { get; set; }

    /// <summary>
    /// The vehicle's odometer reading in kilometers.
    /// </summary>
    [DataPosition(1)]
    public int Odometer { get; set; }

    /// <summary>
    /// State of Charge of the vehicle's battery, in percentage.
    /// </summary>
    [DataPosition(2)]
    public double SOC { get; set; }

    /// <summary>
    /// Elevation above sea level in meters.
    /// </summary>
    [DataPosition(3)]
    public double Elevation { get; set; }

    /// <summary>
    /// Estimated heading of the vehicle in degrees from North.
    /// </summary>
    [DataPosition(4)]
    public double EstHeading { get; set; }

    /// <summary>
    /// Estimated latitude of the vehicle in decimal degrees.
    /// </summary>
    [DataPosition(5)]
    public double EstLat { get; set; }

    /// <summary>
    /// Estimated longitude of the vehicle in decimal degrees.
    /// </summary>
    [DataPosition(6)]
    public double EstLng { get; set; }

    /// <summary>
    /// Corrected estimated latitude of the vehicle after adjustments.
    /// </summary>
    [DataPosition(7)]
    public double EstCorrectedLat { get; set; }

    /// <summary>
    /// Corrected estimated longitude of the vehicle after adjustments.
    /// </summary>
    [DataPosition(8)]
    public double EstCorrectedLng { get; set; }

    /// <summary>
    /// Native GPS latitude of the vehicle.
    /// </summary>
    [DataPosition(9)]
    public double NativeLatitude { get; set; }

    /// <summary>
    /// Native GPS longitude of the vehicle.
    /// </summary>
    [DataPosition(10)]
    public double NativeLongitude { get; set; }

    /// <summary>
    /// Native heading of the vehicle based on GPS data in degrees.
    /// </summary>
    [DataPosition(11)]
    public double NativeHeading { get; set; }

    /// <summary>
    /// Type of the native location system used.
    /// </summary>
    [DataPosition(12)]
    public string NativeType { get; set; }

    /// <summary>
    /// Indicates whether the native location is supported.
    /// </summary>
    [DataPosition(13)]
    public bool NativeLocationSupported { get; set; }

    /// <summary>
    /// Power output of the vehicle in kilowatts.
    /// </summary>
    [DataPosition(14)]
    public double Power { get; set; }

    /// <summary>
    /// Current shift state of the vehicle (e.g., park, drive, reverse).
    /// </summary>
    [DataPosition(15)]
    public string ShiftState { get; set; }

    /// <summary>
    /// The current range of the vehicle on a full charge, in kilometers.
    /// </summary>
    [DataPosition(16)]
    public int Range { get; set; }

    /// <summary>
    /// The estimated range of the vehicle based on current driving conditions, in kilometers.
    /// </summary>
    [DataPosition(17)]
    public int EstRange { get; set; }

    /// <summary>
    /// The vehicle's current heading in degrees from North.
    /// </summary>
    [DataPosition(18)]
    public double Heading { get; set; }
}
