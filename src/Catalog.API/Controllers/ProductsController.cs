using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetProducts")]
        [Authorize(Roles = "Administrator")]
        public IEnumerable<Product> Get()
        {
            List<Product> products = new();
            products.AddRange(new List<Product>
            {
                Product.Create(1,"Product1",100,"Description For Product 1","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg"),
                Product.Create(2,"Product1",200,"Description For Product 2","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg"),
                Product.Create(3,"Product1",300,"Description For Product 3","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg"),
                Product.Create(4,"Product1",400,"Description For Product 4","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg"),
                Product.Create(5,"Product1",500,"Description For Product 5","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg"),
                Product.Create(6,"Product1",600,"Description For Product 6","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg"),
                Product.Create(7,"Product1",700,"Description For Product 7","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg"),
                Product.Create(8,"Product1",800,"Description For Product 8","https://iranlusr.com/wp-content/uploads/2017/07/op-al-code8-300x300.jpg")
            });
            return products;
        }
    }
}
