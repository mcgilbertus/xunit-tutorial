namespace TestProject1;

public class TestExceptions
{
    [Fact]
    public void Exception_Basic()
    {
        var action = new Action(() => throw new Exception("Test"));
        var ex = Assert.Throws<Exception>(action);
        Assert.Equal("Test", ex.Message);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void Exception_IndexOutOfBounds(int idx)
    {
        var data = new int[] { 1, 2, 3 };
        var ex = Assert.Throws<IndexOutOfRangeException>(() => GetItem(data, idx));
        Assert.Equal("Index was outside the bounds of the array.", ex.Message);
    }

    private int GetItem(int[] data, int index)
    {
        if (index < 0 || index >= data.Length)
        {
            throw new IndexOutOfRangeException();
        }

        return data[index];
    }
}