using Xunit;
using Moq;
using SqlManager;
using SqlManager.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

public class SqlDbConnectionFactoryTests
{
    // Removed CreateConnection_ReturnsOpenSqlConnection test as requested
    // Do not open the connection or check its state to avoid real DB dependency

    [Fact]
    public void Dispose_CanBeCalledMultipleTimes()
    {
        // Arrange
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new[] {
                new KeyValuePair<string, string>("ConnectionStrings:RegulatoryComplianceConnString", "Server=.;Database=master;Trusted_Connection=True;")
            })
            .Build();
        var factory = new SqlDbConnectionFactory(config);

        // Act & Assert
        factory.Dispose();
        factory.Dispose(); // Should not throw
    }
}
