using MouseMovementTracking.Domain.Entities;

namespace MouseMovementTracking.Application.Interfaces;

public interface IMouseTrackingRepository
{
    Task AddAsync(MouseTrackingData data);
}