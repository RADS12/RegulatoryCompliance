using Xunit;
using SqlManager.Interfaces;
using System.Data;
using Moq;

public class IDbConnectionFactoryTests
{
    [Fact]
    public void CreateConnection_ReturnsIDbConnection()
    {
        // Arrange
        var mockConn = new Mock<IDbConnection>();
        var factory = new TestDbConnectionFactory(mockConn.Object);

        // Act
        var conn = factory.CreateConnection();

        // Assert
        Assert.NotNull(conn);
        Assert.IsAssignableFrom<IDbConnection>(conn);
    }

    private class TestDbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDbConnection _conn;
        public TestDbConnectionFactory(IDbConnection conn) { _conn = conn; }
        public IDbConnection CreateConnection() => _conn;
    }
}
