using Lamps.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lamps.Infrastructure
{
    public class LampsDbContext : DbContext
    {
        public DbSet<Lamp> Lamps { get; set; }

        public LampsDbContext(DbContextOptions<LampsDbContext> options) : base(options)
        {

        }
    }
}