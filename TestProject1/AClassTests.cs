using System.Reflection;

// turn off parallelization for all tests in this assembly
// [assembly: CollectionBehavior(DisableTestParallelization = true)]

// create a single collection with all tests in the assembly, so they run sequentially
// does not apply to classes with Collection attribute
// [assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]

namespace TestProject1;


public class AClassTests
{
    [Fact]
    public void AClass_Test1()
    {
        // Thread.Sleep(1000);
        Assert.Equal("TestProject1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AssemblyName.GetAssemblyName("TestProject1.dll").ToString());
    } 
    
    [Fact]
    public void AClass_Test2()
    {
        Thread.Sleep(1000);
    }
}