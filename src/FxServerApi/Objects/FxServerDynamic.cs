using System.Text.Json.Serialization;

namespace FxServerApi.Objects;

public class FxServerDynamic
{

    public int Clients { get; set; }

    [JsonPropertyName("gametype")]
    public string GameType { get; set; }

    [JsonPropertyName("hostname")]
    public string HostName { get; set; }
    public string Iv { get; set; }

    [JsonPropertyName("mapname")]
    public string MapName { get; set; }

    [JsonPropertyName("sv_maxclients")]
    public string MaxClients { get; set; }

}
