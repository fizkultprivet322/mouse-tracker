using MouseMovementTracking.Application.Interfaces;
using MouseMovementTracking.Domain.Entities;
namespace MouseMovementTracking.Infrastructure.Persistence.Repositories;

public class MouseTrackingRepository : IMouseTrackingRepository
{
    private readonly ApplicationDbContext _context;

    public MouseTrackingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MouseTrackingData data)
    {
        await _context.MouseTrackingData.AddAsync(data);
        await _context.SaveChangesAsync();
    }
}