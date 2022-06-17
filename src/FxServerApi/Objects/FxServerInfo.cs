namespace FxServerApi.Objects;

public class FxServerInfo
{

    public bool EnhancedHostSupport { get; set; }
    public string Icon { get; set; }
    public string[] Resources { get; set; }
    public string Server { get; set; }
    public Dictionary<string, string> Vars { get; set; }
    public long Version { get; set; }

}
