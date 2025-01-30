using MouseMovementTracking.Application.Interfaces;
using MouseMovementTracking.Domain.Entities;

namespace MouseMovementTracking.Application.Services;

public class MouseTrackingService : IMouseTrackingService
{
    private readonly IMouseTrackingRepository _repository;

    public MouseTrackingService(IMouseTrackingRepository repository)
    {
        _repository = repository;
    }

    public async Task SaveMouseTrackingDataAsync(string jsonData)
    {
        var data = new MouseTrackingData { Data = jsonData };
        await _repository.AddAsync(data);
    }
}