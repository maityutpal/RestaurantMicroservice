namespace Restaurant.Web.Models
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public List<CartDetailsDto> CartDetails { get; set; }
    }
}
