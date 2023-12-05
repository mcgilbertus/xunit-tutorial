using System.Diagnostics;

namespace TestProject1.fixtures;

public class LocalServerOutputAsyncFixture : IDisposable, IAsyncLifetime
{
    public StreamWriter Output;

    public LocalServerOutputAsyncFixture()
    {
        Output = new StreamWriter("..\\..\\..\\sqllocal_testasync.log");
        Output.WriteLine("** Async fixture constructor");
    }

    public async Task InitializeAsync()
    {
        await Output.WriteLineAsync("** Async fixture - InitializeAsync");
        await Output.WriteLineAsync("   Starting local SqlServer");
        using var process = Process.Start("sqllocaldb", "start MSSQLLocalDB");
        await process.WaitForExitAsync();
        await Output.WriteLineAsync("   Server started");
    }

    public void Dispose()
    {
        Output.WriteLine("** Async fixture - dispose");
        Output.Dispose();
    }

    public async Task DisposeAsync()
    {
        await Output.WriteLineAsync("** Async fixture - DisposeAsync");
        await Output.WriteLineAsync("   Stopping local SqlServer");
        using var process = Process.Start("sqllocaldb", "stop MSSQLLocalDB");
        await process.WaitForExitAsync();
        await Output.WriteLineAsync("   Server stopped");
        // await Output.WriteLineAsync("   Disposing output");
        // await Output.DisposeAsync();
    }
}