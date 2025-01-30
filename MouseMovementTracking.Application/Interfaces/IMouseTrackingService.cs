namespace MouseMovementTracking.Application.Interfaces;

public interface IMouseTrackingService
{
    Task SaveMouseTrackingDataAsync(string jsonData);
}