using BlazorAppWSAM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWSAM.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<ImageLibrary> ImageLibrary { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
