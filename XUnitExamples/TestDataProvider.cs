namespace TestProject1;

public class TestDataProvider
{
    public static IEnumerable<object[]> ExternalTestPosNumberGenerator()
    {
        yield return new object[] { -3, 2 };
        yield return new object[] { -11, 2 };
        yield return new object[] { -17, 2 };
        yield return new object[] { -2, 4 };
        yield return new object[] { -4, 6 };
    }
}