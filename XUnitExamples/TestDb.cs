using System.Data.SqlClient;
using TestProject1.fixtures;

namespace TestProject1;

/// <summary>
/// Demonstrates a fixture that starts/stops a local SqlServer instance
/// Version 1: Synchronous, writes output to a log file
/// </summary>
public class TestDb : IClassFixture<LocalServerOutputFixture>, IDisposable
{
    private readonly LocalServerOutputFixture _outputFixture;
    private readonly SqlConnection _connection;

    public TestDb(LocalServerOutputFixture outputFixture)
    {
        _outputFixture = outputFixture;
        _connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");
        _connection.Open();
        _outputFixture.Output.WriteLine("Connection opened");
    }

    [Fact]
    public void ReadSystemView()
    {
        var cmd = new SqlCommand("select * from sys.databases", _connection);
        var count = 0;
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                count++;
                var name = reader.GetString(0);
                _outputFixture.Output.WriteLine(name);
            }
        }

        Assert.Equal(4, count);
    }

    [Fact]
    public void ReadSystemView_BadColumn_Throws()
    {
        var action = new Action(()=> {
            var cmd = new SqlCommand("select * from sys.databases", _connection);
            var count = 0;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    count++;
                    var name = reader.GetString(1);
                    _outputFixture.Output.WriteLine(name);
                }
            }
        });
        Assert.Throws<Exception>(action);
    }
    
    public void Dispose()
    {
        _connection.Dispose();
        _outputFixture.Output.WriteLine("Connection disposed");
    }
}