namespace FxServerApi.Objects;

public class FxPlayer
{

    public string Endpoint { get; set; }
    public int Id { get; set; }
    public string[] Identifiers { get; set; }
    public string Name { get; set; }
    public int Ping { get; set; }

}
