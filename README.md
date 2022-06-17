<div align="center">
 
 # FxServerApi
 
FxServer API wrapper for .NET 6

</div>

## Example
```cs
// using an url or ip address.
var client = new FxServerApiClient("https://dijkie263-rlvgdj.users.cfx.re/");

// If you don't have an url like this, you can also create a client with a join token, ex: https://cfx.re/join/rlvgdj
// Although this is not very stable, sometimes cfx.re returns an ip address which can fail. 
var client = await FxServerApiClient.FromJoinTokenAsync("rlvgdj");

// the rest is pretty self explanatory.
var players = await client.GetPlayersAsync();
```

### NuGet
Soon.

### Contribution
Any type of contribution is greatly appreciated.
