using Xunit;
using RegulatoryCompliance.Controllers;

namespace RegulatoryCompliance.Tests
{
    public class RegulatoryTestControllerTests
    {
        [Fact]
        public void RunTests_ReturnsBadRequest_WhenInputIsNull()
        {
            // Arrange
            var mockEngine = new Moq.Mock<RuleEngine.Interfaces.IRegulatoryRulesEngine>();
            var controller = new RegulatoryCompliance.Controllers.RegulatoryTestController(mockEngine.Object);

            // Act
            var result = controller.RunTests(null, new[] { Common.Enums.RegulatoryTestType.HighCost });

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(result);
        }

        [Fact]
        public void RunTests_ReturnsOkResult_WhenNoTestTypesProvided()
        {
            // Arrange
            var mockEngine = new Moq.Mock<RuleEngine.Interfaces.IRegulatoryRulesEngine>();
            var testResult = new Common.Models.RegulatoryTestResult {
                TestType = Common.Enums.RegulatoryTestType.HighCost,
                LoanNumber = 123,
                IsPassed = true,
                Message = "No tests run"
            };
            mockEngine.Setup(e => e.RunRegulatoryTests(
                Moq.It.IsAny<Common.Enums.RegulatoryTestType[]>(),
                Moq.It.IsAny<Common.Models.HighCostTestInput>()))
                .Returns(new[] { testResult });
            var controller = new RegulatoryCompliance.Controllers.RegulatoryTestController(mockEngine.Object);

            // Act
            var result = controller.RunTests(new Common.Models.HighCostTestInput(), Array.Empty<Common.Enums.RegulatoryTestType>());

            // Assert
            var okResult = Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
            var value = Assert.IsAssignableFrom<IEnumerable<Common.Models.RegulatoryTestResult>>(okResult.Value);
            Assert.Contains(value, r => r.Message == "No tests run");
        }
    
        [Fact]
        public void RunTests_ReturnsOkResult_WhenTestsPass()
        {
            // Arrange
            var mockEngine = new Moq.Mock<RuleEngine.Interfaces.IRegulatoryRulesEngine>();
            var testResult = new Common.Models.RegulatoryTestResult {
                TestType = Common.Enums.RegulatoryTestType.HighCost,
                LoanNumber = 123,
                IsPassed = true,
                Message = "Test Passed"
            };
            mockEngine.Setup(e => e.RunRegulatoryTests(
                Moq.It.IsAny<Common.Enums.RegulatoryTestType[]>(),
                Moq.It.IsAny<Common.Models.HighCostTestInput>()))
                .Returns(new[] { testResult });
            var controller = new RegulatoryCompliance.Controllers.RegulatoryTestController(mockEngine.Object);

            // Act
            var result = controller.RunTests(new Common.Models.HighCostTestInput(), new[] { Common.Enums.RegulatoryTestType.HighCost });

            // Assert
            var okResult = Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
            var value = Assert.IsAssignableFrom<IEnumerable<Common.Models.RegulatoryTestResult>>(okResult.Value);
            Assert.Contains(value, r => r.Message == "Test Passed" && r.IsPassed);
        }

        [Fact]
        public void RunTests_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var mockEngine = new Moq.Mock<RuleEngine.Interfaces.IRegulatoryRulesEngine>();
            mockEngine.Setup(e => e.RunRegulatoryTests(
                Moq.It.IsAny<Common.Enums.RegulatoryTestType[]>(),
                Moq.It.IsAny<Common.Models.HighCostTestInput>()))
                .Throws(new Exception("Test Exception"));
            var controller = new RegulatoryCompliance.Controllers.RegulatoryTestController(mockEngine.Object);

            // Act
            var result = controller.RunTests(new Common.Models.HighCostTestInput(), new[] { Common.Enums.RegulatoryTestType.HighCost });

            // Assert
            var errorResult = Assert.IsType<Microsoft.AspNetCore.Mvc.ObjectResult>(result);
            Assert.Equal(500, errorResult.StatusCode);
            Assert.Equal("Test Exception", errorResult.Value);
        }

        [Fact]
        public void RunTests_ReturnsOkResult_WithEmptyResults_WhenNoTests()
        {
            // Arrange
            var mockEngine = new Moq.Mock<RuleEngine.Interfaces.IRegulatoryRulesEngine>();
            mockEngine.Setup(e => e.RunRegulatoryTests(
                Moq.It.IsAny<Common.Enums.RegulatoryTestType[]>(),
                Moq.It.IsAny<Common.Models.HighCostTestInput>()))
                .Returns(Array.Empty<Common.Models.RegulatoryTestResult>());
            var controller = new RegulatoryCompliance.Controllers.RegulatoryTestController(mockEngine.Object);

            // Act
            var result = controller.RunTests(new Common.Models.HighCostTestInput(), Array.Empty<Common.Enums.RegulatoryTestType>());

            // Assert
            var okResult = Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
            var value = Assert.IsAssignableFrom<IEnumerable<Common.Models.RegulatoryTestResult>>(okResult.Value);
            Assert.Empty(value);
        }
    }
}
