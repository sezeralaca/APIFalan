using Microsoft.EntityFrameworkCore;
using IDoContent.Models;

namespace IDoContent.Data
{
    public class  APIContext : DbContext
    {
        public DbSet<ContentModel> Contents { get; set; }

        public APIContext(DbContextOptions<APIContext> options)
            :base (options) 
        {
            Database.EnsureCreated();
        }

    }
}
