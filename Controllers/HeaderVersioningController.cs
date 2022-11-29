using Akhil_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Akhil_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HeaderVersioningController : Controller
    {
        private readonly ShopContext _shopContext;
        public HeaderVersioningController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("products")]
        //https://localhost:7007/api/v1.0/URLVersioning/products
        public IEnumerable<Product> GetProducts()
        {
            return _shopContext.products.Where(a => a.IsAvailable == true).ToList();
        }
    }

    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderVersioningNewController : Controller
    {
        private readonly ShopContext _shopContext;
        public HeaderVersioningNewController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("products")]
        //https://localhost:7007/api/v2.0/URLVersioningNew/products
        public IEnumerable<Product> GetProducts()
        {
            return _shopContext.products.Where(a => a.IsAvailable == false).ToList();
        }
    }
}
