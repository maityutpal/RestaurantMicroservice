﻿namespace Restaurant.Services.ShoppingCartAPI.Models.DTO
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public List<CartDetailsDto> CartDetails { get; set; }
    }
}
