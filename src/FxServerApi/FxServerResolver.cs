using RestSharp;

namespace FxServerApi;

public static class FxServerResolver
{

    public static Task<string> ResolveJoinTokenAsync(string token)
    {
        var url = new Uri($"https://cfx.re/join/{token}");
        return ResolveJoinUrlAsync(url);
    }

    public static async Task<string> ResolveJoinUrlAsync(Uri uri)
    {
        var client = new RestClient();
        var request = new RestRequest(uri);
        var response = await client.ExecuteAsync(request).ConfigureAwait(false);
        if (!response.IsSuccessful)
            throw new Exception($"Failed to resolve join token. Status Code: {response.StatusCode} ({(int)response.StatusCode})");

        var header = response.Headers?
            .FirstOrDefault(x => x.Name?.Equals("X-Citizenfx-Url", StringComparison.CurrentCultureIgnoreCase) ?? false);
        if (header == null || header.Value == null)
            throw new Exception("Could not find the 'X-Citizenfx-Url' header.");

        return header.Value as string;
    }

}
