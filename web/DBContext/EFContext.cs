
using DicomLoaderWeb.Models;

using Microsoft.EntityFrameworkCore;

namespace DicomLoaderWeb.DBContext
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Record> Records { get; set; }

        /// <summary>
        /// Configure connection to MSQL database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:dicomloaderwebdbserver.database.windows.net,1433;Initial Catalog=DicomLoaderWeb_db;Persist Security Info=False;User ID=sqladmin;Password=Dereske77;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
