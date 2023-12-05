using TestProject1.fixtures;

namespace TestProject1;

// NO HACER ESTO!!! el resultado de los tests dependera del orden de ejecucion de los tests!!

public class TestCounterAndStorage: IClassFixture<SharedStateFixture>, IClassFixture<SharedStorageFixture>
{
    private readonly SharedStorageFixture _sharedStorage;
    private readonly SharedStateFixture _sharedState;

    public TestCounterAndStorage(SharedStateFixture sharedStateFixture, SharedStorageFixture sharedStorageFixture)
    {
        _sharedStorage = sharedStorageFixture;
        _sharedState = sharedStateFixture;
    }

    [Fact]
    public void TestCountAndStore1()
    {
        _sharedState.Counter++;
        _sharedStorage.Storage.Add("TestCountAndStore1");
        Assert.Equal(2, _sharedState.Counter);
        Assert.Equal(2, _sharedStorage.Storage.Count);
    }

    [Fact]
    public void TestCountAndStore2()
    {
        _sharedState.Counter++;
        _sharedStorage.Storage.Add("TestCountAndStore2");
        Assert.Equal(1, _sharedState.Counter);
        Assert.Single(_sharedStorage.Storage);
    }
}