using System.Security.Principal;

namespace Catalog.API
{
    public class Product
    {
        public Product(long id, string name, decimal price, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        internal static Product Create(long id, string name, decimal price, string description, string imageUrl)
        {
            Product product = new(id, name, price, description, imageUrl);
            return product;
        }
    }
}
