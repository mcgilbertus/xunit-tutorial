using TestProject1.fixtures;

namespace TestProject1;

/// <summary>
/// Demostrates using more than one fixture in a test class
/// </summary>
public class TestLoggingAndStorage: IClassFixture<LoggingFixture>, IClassFixture<SharedStorageFixture>, IClassFixture<ConfigurationFixture>, IDisposable
{
    private readonly SharedStorageFixture _storageFixture;
    private readonly ConfigurationFixture _configFixture;
    private readonly LoggingFixture _loggingFixture;

    public TestLoggingAndStorage(LoggingFixture loggingFixture, SharedStorageFixture storageFixtureFixture, ConfigurationFixture configFixture)
    {
        _storageFixture = storageFixtureFixture;
        _configFixture = configFixture;
        _loggingFixture = loggingFixture;
        _loggingFixture.Output.WriteLine("TestCounterAndStorage constructor");
    }

    [Fact]
    public void TestCountAndStore1()
    {
        _loggingFixture.Output.WriteLine("Executing TestCountAndStore1");
        var testValue1 = _configFixture.GetValue("TestValue1", 1);
        _storageFixture.Storage["TestCountAndStore1"] = testValue1;
        Assert.Equal(testValue1, _storageFixture.Storage["TestCountAndStore1"]);
    }

    [Fact]
    public void TestCountAndStore2()
    {
        _loggingFixture.Output.WriteLine("Executing TestCountAndStore2");
        var testValue2 = _configFixture.GetValue("TestValue2", 2);
        _storageFixture.Storage["TestCountAndStore2"] = testValue2;
        Assert.Equal(testValue2, _storageFixture.Storage["TestCountAndStore2"]);
    }

    public void Dispose()
    {
        _loggingFixture.Output.WriteLine("Disposing TestCounterAndStorage");
        LogStorage();
    }

    private void LogStorage()
    {
        _loggingFixture.Output.WriteLine("Storage contents:");
        foreach (var entry in _storageFixture.Storage)
        {
            _loggingFixture.Output.WriteLine($"  {entry.Key} = {entry.Value}");
        }
        _loggingFixture.Output.WriteLine();
    }
}