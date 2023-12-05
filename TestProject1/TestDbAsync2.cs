using System.Data.SqlClient;
using TestProject1.fixtures;

namespace TestProject1;

/// <summary>
/// Demonstrates a fixture that starts/stops a local SqlServer instance
/// Version 2: Asynchronous, writes output to a log file -only the tests
/// </summary>
public class TestDbAsync2 : IClassFixture<LocalServerOutputAsyncFixture>, IDisposable
{
    private readonly StreamWriter _output;
    private readonly SqlConnection _connection;

    public TestDbAsync2(LocalServerOutputAsyncFixture fixture)
    {
        _output = fixture.Output;
        _connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");
        _connection.Open();
        _output.WriteLine("Connection opened");
    }

    [Fact]
    public async Task ReadSystemViewAsync()
    {
        var cmd = new SqlCommand("select * from sys.databases", _connection);
        var count = 0;
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                count++;
                var name = reader.GetString(0);
                _output.WriteLine(name);
            }
        }

        Assert.Equal(4, count);
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}