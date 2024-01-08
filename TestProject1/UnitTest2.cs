using TestProject1.fixtures;

namespace TestProject1;

[Collection("TestSet1")]
public class UnitTest2
{
    public UnitTest2(SharedStateFixture fixture)
    {
        // initialize state for tests in this class
    }
    
    [Fact]
    public void Test3()
    {
        Thread.Sleep(1000);
    }
    
    [Fact]
    public void Test4()
    {
        Thread.Sleep(1000);
    }
}