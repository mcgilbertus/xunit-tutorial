using System.Diagnostics;

namespace TestProject1.fixtures;

public class LocalServerFixture: IDisposable
{
    public LocalServerFixture()
    {
        using var process = Process.Start("sqllocaldb", "start MSSQLLocalDB");
        process.WaitForExit();
    }

    public void Dispose()
    {
        using var process = Process.Start("sqllocaldb", "stop MSSQLLocalDB");
        process.WaitForExit();
    }
}