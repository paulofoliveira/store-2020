using System.Collections.Generic;

namespace ShoppingCartService.Models
{
    public class Cart
    {
        public Cart()
        {
        }

        public int Id { get; set; }
        public List<Product> Items { get; set; }
    }
}
