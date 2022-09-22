namespace Rich.VirtualAssistant;

public static class VirtualAssistantDbProperties
{
    public static string DbTablePrefix { get; set; } = "VirtualAssistant";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "VirtualAssistant";
}
