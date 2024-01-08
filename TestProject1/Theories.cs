namespace TestProject1;

public class Theories
{
    public Theories()
    {
        // test theories
    }

    [Theory]
    [InlineData(-3, 2)]
    [InlineData(-11, 2)]
    [InlineData(-17, 2)]
    [InlineData(-2, 4)]
    [InlineData(-4, 6)]
    public void NegNumberRaisedToEven_ProducesPos(int negNumber, int power)
    {
        Assert.True(negNumber < 0);
        Assert.True(power % 2 == 0);
        Assert.True((long)Math.Pow(negNumber, power) > 0);
    }

    [Theory]
    [MemberData(nameof(TestPosNumberGenerator))]
    public void NegNumberRaisedToEven_ProducesPos_Dynamic(int negNumber, int power)
    {
        Assert.True(negNumber < 0);
        Assert.True(power % 2 == 0);
        Assert.True((long)Math.Pow(negNumber, power) > 0);
    }

    [Theory]
    [MemberData(nameof(TestDataProvider.ExternalTestPosNumberGenerator), MemberType = typeof(TestDataProvider))]
    public void NegNumberRaisedToEven_ProducesPos_Dynamic_ExternalMethod(int negNumber, int power)
    {
        Assert.True(negNumber < 0);
        Assert.True(power % 2 == 0);
        Assert.True((long)Math.Pow(negNumber, power) > 0);
    }

    [Theory]
    [ClassData(typeof(TestDataEnumerator))]
    public void NegNumberRaisedToEven_ProducesPos_Dynamic_ExternalClass(int negNumber, int power)
    {
        Assert.True(negNumber < 0);
        Assert.True(power % 2 == 0);
        Assert.True((long)Math.Pow(negNumber, power) > 0);
    }

    public static IEnumerable<object[]> TestPosNumberGenerator()
    {
        yield return new object[] { -3, 2 };
        yield return new object[] { -11, 2 };
        yield return new object[] { -17, 2 };
        yield return new object[] { -2, 4 };
        yield return new object[] { -4, 6 };
    }

    public static IEnumerable<object[]> TestOpNumberGenerator() =>
        new List<object[]>()
        {
            new object[] { -3, 2, '+', -1 },
            new object[] { -11, 2, '*', -22 },
            new object[] { 17, 2, '-', 15 },
            new object[] { -4, 2,  '/', -2 },
        };

    [Theory]
    [MemberData(nameof(TestOpNumberGenerator))]
    public void CalcTestMember(int a, int b, char op, int expected)
    {
        var actual = op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => a / b,
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(-3, 2, '+', -1)]
    [InlineData(-11, 2, '*', -22)]
    [InlineData(17, 2, '-', 15)]
    [InlineData(-4, 2,  '/', -2)]
    public void CalcTestInline(int a, int b, char op, int expected)
    {
        var actual = op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => a / b,
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
        Assert.Equal(expected, actual);
    }
    
}