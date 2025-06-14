using System;
using System.Text.Json.Serialization;

namespace FireLine.DataPlatform.Models.IncidentBasic;

public enum FireBehavior
{
    [JsonPropertyName("minimal")]
    Minimal,
    [JsonPropertyName("moderate")]
    Moderate,
    [JsonPropertyName("active")]
    Active,
    [JsonPropertyName("extreme")]
    Extreme
}

public enum WindDirection
{
    N,
    NE,
    E,
    SE,
    S,
    SW,
    W,
    NW
}

public enum ResourceType
{
    Engine,
    HandCrew,
    Helicopter,
    Bulldozer,
    WaterTender,
    AirTanker
}

public class GeographicLocation
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    // These properties are not in the JSON schema but may be useful for your application
    public string? Address { get; set; }
    public double? Elevation { get; set; }
}

public class FireStatus
{
    [JsonPropertyName("acres_burned")]
    public double AcresBurned { get; set; }

    [JsonPropertyName("percent_contained")]
    public int PercentContained { get; set; }

    [JsonPropertyName("fire_behavior")]
    public FireBehavior? FireBehavior { get; set; }

    // Additional properties not in schema but from your original model
    public DateTime? LastUpdated { get; set; }
    public double? PerimeterMiles { get; set; }
}

public class RedFlagWarning
{
    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("expires")]
    public DateTime? Expires { get; set; }

    // Additional property from your original model
    public string? IssuingOffice { get; set; }
}

public class WeatherConditions
{
    [JsonPropertyName("wind_speed")]
    public double? WindSpeed { get; set; }

    [JsonPropertyName("wind_direction")]
    public WindDirection? WindDirection { get; set; }

    [JsonPropertyName("red_flag_warning")]
    public RedFlagWarning? RedFlagWarning { get; set; }

    // Additional properties not in schema but from your original model
    public int? RelativeHumidity { get; set; }
    public double? TemperatureFahrenheit { get; set; }
    public DateTime? ObservationTime { get; set; }
}

public class IncidentBasic
{
    // Required properties per JSON schema
    [JsonPropertyName("incident_id")]
    public string IncidentId { get; set; } = string.Empty;

    [JsonPropertyName("incident_name")]
    public string IncidentName { get; set; } = string.Empty;

    [JsonPropertyName("location")]
    public GeographicLocation Location { get; set; } = new();

    [JsonPropertyName("fire_status")]
    public FireStatus FireStatus { get; set; } = new();

    [JsonPropertyName("weather")]
    public WeatherConditions Weather { get; set; } = new();

    // Additional properties from your original model (not in JSON schema)
    public string? IncidentType { get; set; }
    public DateTime? DiscoveryDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ControlledDate { get; set; } // Fixed typo from "ControlliedDate"
    public DateTime? ExtinguishedDate { get; set; }
    public string? State { get; set; }
    public string? County { get; set; }
    public string? ResponsibleAgency { get; set; }
    public string? IncidentCommanderName { get; set; }
    public string? CauseDescription { get; set; }
    public string? IncidentDescription { get; set; }
    public ResourceType? PrimaryResourceAssigned { get; set; }
    public string? CurrentStatus { get; set; }
    public int? PriorityLevel { get; set; }
}