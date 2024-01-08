namespace TestProject1.fixtures;

public class SharedStateFixture: IDisposable
{
    public int Counter { get; set; }
    
    public SharedStateFixture()
    {
        // initialize shared state
        Counter = 0;
        Thread.Sleep(1000);
    }

    public void Dispose()
    {
        // dispose shared state
    }
}
