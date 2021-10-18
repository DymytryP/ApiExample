using Billing.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Billing.Data
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BillingUser> BillingUsers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
