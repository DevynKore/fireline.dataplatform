using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FireLine.DataPlatform.Models.IncidentBasic;

namespace FireLine.DataPlatform.Services;

public class FireLineJsonSerializer
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Converters = {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        }
    };

    public static async Task<IncidentBasic?> DeserializeAsync(string json, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(json))
            return null;
        try
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            return await JsonSerializer.DeserializeAsync<IncidentBasic>(stream, _options, cancellationToken);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Failed to deserialize incident JSON: {ex.Message}", ex);
        }
    }

    public static async Task<string> SerializeAsync(IncidentBasic incident, CancellationToken cancellationToken = default)
    {
        if (incident == null)
            throw new ArgumentNullException(nameof(incident));
        try
        {
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, incident, _options, cancellationToken);
            return System.Text.Encoding.UTF8.GetString(stream.ToArray());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to serialize incident: {ex.Message}", ex);
        }
    }
}