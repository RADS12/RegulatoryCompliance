using Xunit;
using SqlManager.Interfaces;
using Common.Models;
using Moq;
using System.Threading.Tasks;

public class ILoanSqlManagerTests
{
    [Fact]
    public async Task CreateLoanBase_CanBeCalled()
    {
        // Arrange
        var mock = new Mock<ILoanSqlManager>();
        mock.Setup(m => m.CreateLoanBase(It.IsAny<Loan>())).ReturnsAsync(1);
    var loan = new Common.Models.ConventionalLoan();

        // Act
        var result = await mock.Object.CreateLoanBase(loan);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetLoanBaseById_CanBeCalled()
    {
        // Arrange
        var mock = new Mock<ILoanSqlManager>();
    var loan = new Common.Models.ConventionalLoan();
        mock.Setup(m => m.GetLoanBaseById(It.IsAny<int>())).ReturnsAsync(loan);

        // Act
        var result = await mock.Object.GetLoanBaseById(1);

        // Assert
        Assert.Equal(loan, result);
    }

    [Fact]
    public async Task UpdateLoanBase_CanBeCalled()
    {
        // Arrange
        var mock = new Mock<ILoanSqlManager>();
        mock.Setup(m => m.UpdateLoanBase(It.IsAny<Loan>())).ReturnsAsync(true);
    var loan = new Common.Models.ConventionalLoan();

        // Act
        var result = await mock.Object.UpdateLoanBase(loan);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteLoanBase_CanBeCalled()
    {
        // Arrange
        var mock = new Mock<ILoanSqlManager>();
        mock.Setup(m => m.DeleteLoanBase(It.IsAny<int>())).ReturnsAsync(true);

        // Act
        var result = await mock.Object.DeleteLoanBase(1);

        // Assert
        Assert.True(result);
    }
}
