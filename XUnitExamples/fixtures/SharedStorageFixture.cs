using System.Collections.Concurrent;

namespace TestProject1.fixtures;

public class SharedStorageFixture
{
    public ConcurrentDictionary<string, object> Storage { get; set; } = new();

}