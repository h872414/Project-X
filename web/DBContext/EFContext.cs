
using DicomLoaderWeb.Models;

using Microsoft.EntityFrameworkCore;

namespace DicomLoaderWeb.DBContext
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.//DB//users.db");
        }
    }
}
