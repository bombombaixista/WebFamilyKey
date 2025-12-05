using Microsoft.EntityFrameworkCore;
using Microsoft.Online.SharePoint.TenantAdministration;
using WebFamilyKey2.Models;

namespace WebFamilyKey2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }
}
