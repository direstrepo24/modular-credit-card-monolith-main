namespace CrediCard.Api;

internal static class ModuleConfigurationExtensions
{
    internal static void AddModuleConfiguration(this IConfigurationBuilder configurationBuilder, string[] modules)
    {
        foreach (string module in modules)
        {
            configurationBuilder.AddJsonFile($"appsettings.{module}.json", false, true);
            configurationBuilder.AddJsonFile($"appsettings.{module}.Development.json", true, true);
        }
    }
}