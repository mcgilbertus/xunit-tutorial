using System.Diagnostics;

namespace TestProject1.fixtures;

public class LocalServerOutputFixture : IDisposable
{
    public StreamWriter Output;

    public LocalServerOutputFixture()
    {
        Output = new StreamWriter("..\\..\\..\\sqllocal_test.log");
        Output.WriteLine("** Starting local SqlServer");
        using var process = Process.Start("sqllocaldb", "start MSSQLLocalDB");
        process.WaitForExit();
        Output.WriteLine("** Server started");
    }

    public void Dispose()
    {
        Output.WriteLine("** Stopping local SqlServer");
        using var process = Process.Start("sqllocaldb", "stop MSSQLLocalDB");
        process.WaitForExit();
        Output.WriteLine("** Server stopped");
        Output.Dispose();
    }
}