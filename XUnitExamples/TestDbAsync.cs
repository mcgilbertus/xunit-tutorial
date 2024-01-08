using System.Data.SqlClient;
using TestProject1.fixtures;
using Xunit.Abstractions;

namespace TestProject1;

/// <summary>
/// Demonstrates a fixture that starts/stops a local SqlServer instance
/// Version 2: Asynchronous, writes output to the console
/// </summary>
public class TestDbAsync : IClassFixture<LocalServerFixture>, IDisposable
{
    private readonly ITestOutputHelper _output;
    private readonly SqlConnection _connection;

    public TestDbAsync(LocalServerFixture fixture, ITestOutputHelper output)
    {
        _output = output;
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