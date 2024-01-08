using System.Collections;

namespace TestProject1;

public class TestDataEnumerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        return new List<object[]>()
        {
            new object[] { -3, 2 },
            new object[] { -11, 2 },
            new object[] { -17, 2 },
            new object[] { -2, 4 },
            new object[] { -4, 6 },
        }.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}