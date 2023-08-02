using mexxar.Models;
using Microsoft.EntityFrameworkCore;

namespace mexxar.Data
{
    public class MexxarDbContext : DbContext
    {
        public MexxarDbContext(DbContextOptions<MexxarDbContext> options) : base(options)
        {   
        }

        public DbSet<Category> categories { get; set; }
    }
}
