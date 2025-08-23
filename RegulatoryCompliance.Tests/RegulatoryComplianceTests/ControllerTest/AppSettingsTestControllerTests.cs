using Xunit;
using RegulatoryCompliance.Controllers;
using Moq;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RegulatoryCompliance.Tests
{
    public class AppSettingsTestControllerTests
    {
        [Fact]
        public void GetSettingsTest_ReturnsOkResult_WithAppSettings()
        {
            // Arrange
            var mockService = new Mock<IAppSettingsService>();
            mockService.Setup(s => s.AppId).Returns(123);
            mockService.Setup(s => s.AppName).Returns("TestAppName");
            var controller = new AppSettingsTestController(mockService.Object);

            // Act
            var result = controller.GetSettingsTest();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value;
            var valueType = value.GetType();
            Assert.Equal(123, (int)valueType.GetProperty("appId").GetValue(value));
            Assert.Equal("TestAppName", (string)valueType.GetProperty("appName").GetValue(value));
        }
        [Fact]
        public void GetSettingsTest_ReturnsOkResult_WhenAppIdIsDefault()
        {
            // Arrange
            var mockService = new Mock<IAppSettingsService>();
            mockService.Setup(s => s.AppId).Returns(0); // default int value
            mockService.Setup(s => s.AppName).Returns("TestAppName");
            var controller = new AppSettingsTestController(mockService.Object);

            // Act
            var result = controller.GetSettingsTest();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value;
            var valueType = value.GetType();
            Assert.Equal(0, (int)valueType.GetProperty("appId").GetValue(value));
            Assert.Equal("TestAppName", (string)valueType.GetProperty("appName").GetValue(value));
        }

        [Fact]
        public void GetSettingsTest_ReturnsOkResult_WhenAppNameIsNull()
        {
            // Arrange
            var mockService = new Mock<IAppSettingsService>();
            mockService.Setup(s => s.AppId).Returns(123);
            mockService.Setup(s => s.AppName).Returns((string)null);
            var controller = new AppSettingsTestController(mockService.Object);

            // Act
            var result = controller.GetSettingsTest();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value;
            var valueType = value.GetType();
            Assert.Equal(123, (int)valueType.GetProperty("appId").GetValue(value));
            Assert.Null(valueType.GetProperty("appName").GetValue(value));
        }

        [Fact]
        public void GetSettingsTest_ThrowsException_WhenServiceThrows()
        {
            // Arrange
            var mockService = new Mock<IAppSettingsService>();
            mockService.Setup(s => s.AppId).Throws(new System.Exception("Service error"));
            mockService.Setup(s => s.AppName).Returns("TestAppName");
            var controller = new AppSettingsTestController(mockService.Object);

            // Act & Assert
            Assert.Throws<System.Exception>(() => controller.GetSettingsTest());
        }
    }
}
