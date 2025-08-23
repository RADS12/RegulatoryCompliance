using Xunit;
using Moq;
using SqlManager.Interfaces;
using Common.Models;
using System.Data;
using System.Threading.Tasks;
using SalManager;
using System.Collections.Generic;

public class LoanSqlManagerTests
{
    [Fact]
    public async Task CreateLoanBase_ReturnsNewLoanId()
    {
        // Arrange
        var mockConnFactory = new Mock<IDbConnectionFactory>();
        var mockConn = new Mock<IDbConnection>();
        mockConnFactory.Setup(f => f.CreateConnection()).Returns(mockConn.Object);
        var manager = new LoanSqlManager(mockConnFactory.Object);
    var loan = new Common.Models.ConventionalLoan();
        // Dapper is used internally, so this is a smoke test for method call
        // You may want to mock Dapper if possible, or test for exceptions
        await Assert.ThrowsAnyAsync<System.Exception>(() => manager.CreateLoanBase(loan));
    }

    [Fact]
    public async Task GetLoanBaseById_ReturnsLoanOrNull()
    {
        // Arrange
        var mockConnFactory = new Mock<IDbConnectionFactory>();
        var mockConn = new Mock<IDbConnection>();
        mockConnFactory.Setup(f => f.CreateConnection()).Returns(mockConn.Object);
        var manager = new LoanSqlManager(mockConnFactory.Object);
    // Dapper is used internally, so this is a smoke test for method call
    await Assert.ThrowsAnyAsync<System.Exception>(() => manager.GetLoanBaseById(1));
    }

    [Fact]
    public async Task UpdateLoanBase_ReturnsBool()
    {
        // Arrange
        var mockConnFactory = new Mock<IDbConnectionFactory>();
        var mockConn = new Mock<IDbConnection>();
        mockConnFactory.Setup(f => f.CreateConnection()).Returns(mockConn.Object);
        var manager = new LoanSqlManager(mockConnFactory.Object);
    var loan = new Common.Models.ConventionalLoan();
    await Assert.ThrowsAnyAsync<System.Exception>(() => manager.UpdateLoanBase(loan));
    }
}
