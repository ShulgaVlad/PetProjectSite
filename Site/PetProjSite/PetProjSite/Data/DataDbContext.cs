using Microsoft.EntityFrameworkCore;
using PetProjSite.Models;

namespace PetProjSite.Data
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions <DataDbContext> options):base(options) {
        }

        public DbSet<AdminProfile> AdminProfile { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<WishList> WishList { get; set; }
    }
}
