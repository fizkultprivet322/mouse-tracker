using Microsoft.EntityFrameworkCore;
using MouseMovementTracking.Domain.Entities;

namespace MouseMovementTracking.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<MouseTrackingData> MouseTrackingData { get; set; }
}