using Moq;
using MouseMovementTracking.Application.Interfaces;
using MouseMovementTracking.Application.Services;
using MouseMovementTracking.Domain.Entities;

namespace MouseMovementTrackingTests;

public class MouseTrackingServiceTest
{
    [Fact]
    public async Task SaveMouseTrackingDataAsync_Should_Call_Repository_AddAsync()
    {
        // Arrange
        var mockRepository = new Mock<IMouseTrackingRepository>();
        var service = new MouseTrackingService(mockRepository.Object);
        var jsonData = "[[100,200,1672531200000],[150,250,1672531201000]]";

        // Act
        await service.SaveMouseTrackingDataAsync(jsonData);

        // Assert
        mockRepository.Verify(repo => repo.AddAsync(It.Is<MouseTrackingData>(data => data.Data == jsonData)), Times.Once);
    }

    [Fact]
    public async Task SaveMouseTrackingDataAsync_Should_Not_Call_Repository_AddAsync_When_Data_Is_Null()
    {
        // Arrange
        var mockRepository = new Mock<IMouseTrackingRepository>();
        var service = new MouseTrackingService(mockRepository.Object);
        string jsonData = null;

        // Act
        await service.SaveMouseTrackingDataAsync(jsonData);

        // Assert
        mockRepository.Verify(repo => repo.AddAsync(It.IsAny<MouseTrackingData>()), Times.Never);
    }

    [Fact]
    public async Task SaveMouseTrackingDataAsync_Should_Not_Call_Repository_AddAsync_When_Data_Is_Empty()
    {
        // Arrange
        var mockRepository = new Mock<IMouseTrackingRepository>();
        var service = new MouseTrackingService(mockRepository.Object);
        string jsonData = "";

        // Act
        await service.SaveMouseTrackingDataAsync(jsonData);

        // Assert
        mockRepository.Verify(repo => repo.AddAsync(It.IsAny<MouseTrackingData>()), Times.Never);
    }
}