using System.Runtime.CompilerServices;
using RestSharp;
using RestSharp.Serializers.Json;

using System.Text.Json;
using FxServerApi.Objects;

namespace FxServerApi;

public class FxServerApiClient
{

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    private readonly RestClient _client;

    public FxServerApiClient(string url)
    {
        _client = new RestClient(url)
            .UseSystemTextJson(JsonSerializerOptions);
    }

    public static async Task<FxServerApiClient> FromJoinTokenAsync(string token)
    {
        var url = await FxServerResolver.ResolveJoinTokenAsync(token).ConfigureAwait(false);
        return new FxServerApiClient(url);
    }

    public static async Task<FxServerApiClient> FromJoinUrlAsync(string joinUrl)
    {
        var url = await FxServerResolver.ResolveJoinUrlAsync(new Uri(joinUrl)).ConfigureAwait(false);
        return new FxServerApiClient(url);
    }

    public async Task<FxPlayer[]> GetPlayersAsync()
    {
        var request = new RestRequest("/players.json");
        var response = await _client.ExecuteAsync<FxPlayer[]>(request);
        EnsureSuccess(response);

        return response.Data;
    }

    public async Task<FxServerInfo> GetServerInfoAsync()
    {
        var request = new RestRequest("/info.json");
        var response = await _client.ExecuteAsync<FxServerInfo>(request);
        EnsureSuccess(response);

        return response.Data;
    }

    public async Task<FxServerDynamic> GetDynamicAsync()
    {
        var request = new RestRequest("/dynamic.json");
        var response = await _client.ExecuteAsync<FxServerDynamic>(request);
        EnsureSuccess(response);

        return response.Data;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void EnsureSuccess(RestResponseBase response)
    {
        if (!response.IsSuccessful)
            throw new Exception($"{response.Request?.Resource} returned unsuccessful status code: {response.StatusCode} ({(int) response.StatusCode})");
    }

}
