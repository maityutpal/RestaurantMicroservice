using Microsoft.EntityFrameworkCore;
using Restaurant.Services.Coupon.API.Models;

namespace Restaurant.Services.Coupon.API.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CouponGift> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CouponGift>().HasData(new CouponGift
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10
            });
            modelBuilder.Entity<CouponGift>().HasData(new CouponGift
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20
            });

        }
    }
}
