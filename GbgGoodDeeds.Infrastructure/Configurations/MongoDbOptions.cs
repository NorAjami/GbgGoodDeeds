namespace GbgGoodDeeds.Infrastructure.Configurations;

public class MongoDbOptions
{
    public const string SectionName = "MongoDb";

    public string Host { get; set; } = default!;
    public string Port { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Database { get; set; } = default!;
    public string Collection { get; set; } = default!;

    public string GetConnectionString()
    {
        return $"mongodb://{Username}:{Password}@{Host}:{Port}";
    }
}
