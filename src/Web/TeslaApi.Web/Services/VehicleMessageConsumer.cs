using System.Reflection;
using Domain;
using Extensions;
using MassTransit;

namespace Services;

public class VehicleMessageConsumer : IConsumer<VehicleMessage>
{
    private readonly ILogger<VehicleMessageConsumer> _logger;

    public VehicleMessageConsumer(ILogger<VehicleMessageConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<VehicleMessage> context)
    {
        var data = Util.ConvertStringToType<VehicleStreamData>(context.Message.Raw);
        _logger.LogError("Value: {Value}", data.ShiftState);
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
