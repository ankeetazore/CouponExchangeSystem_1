using CouponExchangeSystemApi_1.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponExchangeSystemApi_1.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }
        public DbSet<CouponCategoryDetails> CouponCategoryDetails { get; set; }
        public DbSet<CouponDetails> CouponDetails { get; set; }
    }
}
