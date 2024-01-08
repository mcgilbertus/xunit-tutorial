using TestProject1.fixtures;

namespace TestProject1;

[Collection("TestSet1")]
public class UnitTest1
{
    public UnitTest1(SharedStateFixture fixture)
    {
        // initialize state for tests in this class
    }

    [Fact]
    public void Test1()
    {
        Thread.Sleep(1000);
        Assert.True(true);
    }
    
    [Fact]
    public void Test2()
    {
        Thread.Sleep(1000);
        Assert.True(true);
    }
}