using Xunit.Abstractions;


namespace TestProject1;

public class TestSorter: ITestCollectionOrderer
{
    public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
    {
        // sort the tests by name in descending order
        return testCollections.OrderByDescending(col => col.DisplayName);
    }
}