using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Data
{
    public class CampusDbContext : DbContext
    {
        public CampusDbContext(
            DbContextOptions<CampusDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Complaint> Complaints { get; set; }
    }
}
