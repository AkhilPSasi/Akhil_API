using Akhil_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Akhil_API.Controllers.IdentityToken
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    [ApiController]
    public class IT_ProductController : Controller
    {
        private readonly ShopContext _shopContext;
        public IT_ProductController(ShopContext shopContext)
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
