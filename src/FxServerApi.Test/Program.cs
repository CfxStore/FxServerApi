namespace FxServerApi.Test;

public class Program
{

    public static async Task Main(string[] _)
    {
        var client = new FxServerApiClient("https://dijkie263-rlvgdj.users.cfx.re");
        var players = await client.GetPlayersAsync();
        var info = await client.GetServerInfoAsync();
        var dynamic = await client.GetDynamicAsync();
    }

}
