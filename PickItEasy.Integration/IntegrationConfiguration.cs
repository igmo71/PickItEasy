namespace PickItEasy.Integration
{
    public class IntegrationConfiguration
    {
        public const string Section = "Integration";
        public ConnectorConfig[]? Connectors { get; set; }
    }
    public class ConnectorConfig
    {
        public string Name { get; set; } = null!;
        public string BaseAddress { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public ServiceConfig[]? Services { get; set; }
    }

    public class ServiceConfig
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public bool? IsUse { get; set; }
        public string[]? Options { get; set; }
    }
}
