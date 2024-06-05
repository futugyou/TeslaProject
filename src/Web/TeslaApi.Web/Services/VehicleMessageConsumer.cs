using Domain;
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
        var data = VehicleStreamData.ParseVehicleStreamData(context.Message.Raw);
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
    public double Speed { get; set; }

    /// <summary>
    /// The vehicle's odometer reading in kilometers.
    /// </summary>
    public int Odometer { get; set; }

    /// <summary>
    /// State of Charge of the vehicle's battery, in percentage.
    /// </summary>
    public double SOC { get; set; }

    /// <summary>
    /// Elevation above sea level in meters.
    /// </summary>
    public double Elevation { get; set; }

    /// <summary>
    /// Estimated heading of the vehicle in degrees from North.
    /// </summary>
    public double EstHeading { get; set; }

    /// <summary>
    /// Estimated latitude of the vehicle in decimal degrees.
    /// </summary>
    public double EstLat { get; set; }

    /// <summary>
    /// Estimated longitude of the vehicle in decimal degrees.
    /// </summary>
    public double EstLng { get; set; }

    /// <summary>
    /// Corrected estimated latitude of the vehicle after adjustments.
    /// </summary>
    public double EstCorrectedLat { get; set; }

    /// <summary>
    /// Corrected estimated longitude of the vehicle after adjustments.
    /// </summary>
    public double EstCorrectedLng { get; set; }

    /// <summary>
    /// Native GPS latitude of the vehicle.
    /// </summary>
    public double NativeLatitude { get; set; }

    /// <summary>
    /// Native GPS longitude of the vehicle.
    /// </summary>
    public double NativeLongitude { get; set; }

    /// <summary>
    /// Native heading of the vehicle based on GPS data in degrees.
    /// </summary>
    public double NativeHeading { get; set; }

    /// <summary>
    /// Type of the native location system used.
    /// </summary>
    public string NativeType { get; set; }

    /// <summary>
    /// Indicates whether the native location is supported.
    /// </summary>
    public bool NativeLocationSupported { get; set; }

    /// <summary>
    /// Power output of the vehicle in kilowatts.
    /// </summary>
    public double Power { get; set; }

    /// <summary>
    /// Current shift state of the vehicle (e.g., park, drive, reverse).
    /// </summary>
    public string ShiftState { get; set; }

    /// <summary>
    /// The current range of the vehicle on a full charge, in kilometers.
    /// </summary>
    public int Range { get; set; }

    /// <summary>
    /// The estimated range of the vehicle based on current driving conditions, in kilometers.
    /// </summary>
    public int EstRange { get; set; }

    /// <summary>
    /// The vehicle's current heading in degrees from North.
    /// </summary>
    public double Heading { get; set; }

    public static VehicleStreamData ParseVehicleStreamData(string data)
    {
        // Split the string by the comma delimiter
        string[] parts = data.Split(',');

        // Create a new instance of VehicleStreamData
        VehicleStreamData vehicleData = new()
        {
            // Assign each part to the corresponding property of VehicleStreamData
            // Note: You need to convert each part to the proper data type
            Speed = double.Parse(parts[0]),
            Odometer = int.Parse(parts[1]),
            SOC = double.Parse(parts[2]),
            Elevation = double.Parse(parts[3]),
            EstHeading = double.Parse(parts[4]),
            EstLat = double.Parse(parts[5]),
            EstLng = double.Parse(parts[6]),
            EstCorrectedLat = double.Parse(parts[7]),
            EstCorrectedLng = double.Parse(parts[8]),
            NativeLatitude = double.Parse(parts[9]),
            NativeLongitude = double.Parse(parts[10]),
            NativeHeading = double.Parse(parts[11]),
            NativeType = parts[12],
            NativeLocationSupported = bool.Parse(parts[13]),
            Power = double.Parse(parts[14]),
            ShiftState = parts[15],
            Range = int.Parse(parts[16]),
            EstRange = int.Parse(parts[17]),
            Heading = double.Parse(parts[18])
        };

        // Return the populated VehicleData instance
        return vehicleData;
    }
}

