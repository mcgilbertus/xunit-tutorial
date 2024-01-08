using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace TestProject1.fixtures;

/// <summary>
/// Reads configurations from testsettings.json
/// </summary>
public class ConfigurationFixture
{
    public IConfiguration Configuration { get; set; }
    
    public ConfigurationFixture()
    {
        var testSettingsFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
                                            ?? string.Empty, "testsettings.json");
        var config = new ConfigurationBuilder().AddJsonFile(testSettingsFile, optional:true).Build();
        Configuration = config;
    }

    public object GetValue(string key, object defaultValue)
    {
        return Configuration.GetValue(key, defaultValue);
    }
}