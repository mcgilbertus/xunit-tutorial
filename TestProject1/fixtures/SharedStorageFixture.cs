using System.Collections.Concurrent;

namespace TestProject1.fixtures;

public class SharedStorageFixture: IDisposable
{
    public ConcurrentBag<string> Storage { get; set; } = new();

    public SharedStorageFixture()
    {
    }

    public void Dispose()
    {
        
    }
}