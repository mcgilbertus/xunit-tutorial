using System.Data.SqlClient;
using TestProject1.fixtures;

namespace TestProject1;

/// <summary>
/// Demonstrates a fixture that starts/stops a local SqlServer instance
/// Version 2: Asynchronous, writes output to a log file -both tests and fixture
/// </summary>
public class TestDbAsync3 : IClassFixture<LocalServerOutputAsyncFixture>, IAsyncLifetime
{
    private readonly StreamWriter _output;
    private readonly SqlConnection _connection;

    public TestDbAsync3(LocalServerOutputAsyncFixture fixture)
    {
        _output = fixture.Output;
        _connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");
    }

    public async Task InitializeAsync()
    {
        await _connection.OpenAsync();
        await _output.WriteLineAsync("Connection opened");
    }

    public async Task DisposeAsync()
    {
        await _connection.DisposeAsync();
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

}