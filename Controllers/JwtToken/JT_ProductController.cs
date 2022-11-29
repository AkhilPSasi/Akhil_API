using Akhil_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Akhil_API.Controllers.JwtToken
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class JT_ProductController : Controller
    {
        private readonly ShopContext _shopContext;
        public JT_ProductController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }
        [HttpGet]
        [Route("products")]
        public IEnumerable<Product> GetProducts()
        {
            return _shopContext.products.ToList();
        }
    }
}
