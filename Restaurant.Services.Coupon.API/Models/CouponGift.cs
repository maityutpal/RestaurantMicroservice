using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.Coupon.API.Models
{
    public class CouponGift
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
