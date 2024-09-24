using Microsoft.EntityFrameworkCore;
using IDoContent.Data.Entity;

namespace IDoContent.Data
{
    public class  APIContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<HotWheels> HotWheels { get; set; }

        public APIContext(DbContextOptions<APIContext> options)
            :base (options) 
        {
            Database.EnsureCreated();
        }

    }
}
