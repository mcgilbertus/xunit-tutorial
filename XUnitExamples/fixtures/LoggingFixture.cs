using System.Reflection;

namespace TestProject1.fixtures;

/// <summary>
/// Fixture to share a logging mechanism between tests
/// </summary>
public class LoggingFixture: IDisposable
{
    public StreamWriter Output;

    public LoggingFixture()
    {
        var logFile = $"..//..//..//sharedlogging_test.log"; 
        Output = new StreamWriter(logFile);
        Output.WriteLine($"** Logging file initialized: {logFile}");
    }
    
    public void Dispose()
    {
        Output.WriteLine("** Closing logging file");
        Output.Close();
        Output.Dispose();
    }
}