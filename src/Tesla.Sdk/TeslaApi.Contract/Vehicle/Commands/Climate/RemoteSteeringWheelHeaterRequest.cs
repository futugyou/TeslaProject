﻿
namespace TeslaApi.Contract.Vehicle.Commands.Climate;

public class RemoteSteeringWheelHeaterRequest
{
    /// <summary>
    /// True to turn on, false to turn off.
    /// </summary>
    [JsonPropertyName("on")]
    public bool On { get; set; }
}
