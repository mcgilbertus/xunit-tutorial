using Xunit.Abstractions;

namespace TestProject1;

public class TestOutput
{
    private readonly ITestOutputHelper _output;

    public TestOutput(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void TestOutput1()
    {
        _output.WriteLine("Starting the test");
        Thread.Sleep(1000);
        _output.WriteLine("Finishing the test");
    }
}