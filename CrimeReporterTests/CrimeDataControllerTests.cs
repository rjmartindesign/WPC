using System;
using System.Threading.Tasks;
using CrimeReporter.Controllers;
using CrimeReporter.Model;
using CrimeReporter.Model.Query;
using CrimeReporter.Services.Interfaces;
using CrimeReporterTests;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CrimeReporter.Tests.Controllers
{
    [TestFixture]
    public class CrimeDataControllerTests
    {

        private CrimeDataController _controller;
        private Mock<ICrimeDataService> _mockCrimeDataService;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _mockCrimeDataService = new Mock<ICrimeDataService>();
            _controller = new CrimeDataController(_mockCrimeDataService.Object);
        }

        [Test]
        public async Task Get_ValidData_ReturnsOk()
        {

            // Act
            var result = await _controller.Get(1, 50.0, 0.0);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.TypeOf<ApiResponse>());
            var response = (ApiResponse)okResult.Value;
            Assert.That(response.IsSuccess, Is.True);
            Assert.That(response.Result, Is.Not.Null); 
        }

        [Test]
        public async Task Get_InvalidLatitude_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.Get(1, 100.0, 0.0);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.That(badRequestResult.Value, Is.TypeOf<ApiResponse>());
            var response = (ApiResponse)badRequestResult.Value;
            Assert.That(response.IsSuccess, Is.False);
            Assert.That(response.Message, Is.EqualTo("Invalid data"));
        }

        [Test]
        public async Task Get_InvalidMonth_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.Get(13, 50.0, 0.0);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.That(badRequestResult.Value, Is.TypeOf<ApiResponse>());
            var response = (ApiResponse)badRequestResult.Value;
            Assert.That(response.IsSuccess, Is.False);
            Assert.That(response.Message, Is.EqualTo("Invalid data"));
        }

        [Test]
        public async Task Get_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var crimeDataService = new MockCrimeDataService(exceptionThrown: true);
            var controller = new CrimeDataController(crimeDataService);

            // Act
            var result = await controller.Get(1, 50.0, 0.0);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.That(badRequestResult.Value, Is.TypeOf<ApiResponse>());
            var response = (ApiResponse)badRequestResult.Value;
            Assert.That(response.IsSuccess, Is.False);
            Assert.That(response.Message, Is.EqualTo("Simulated exception for testing"));
        }

    }

    
}