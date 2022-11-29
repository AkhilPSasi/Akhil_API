using Akhil_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Akhil_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopContext _shopContext;
        public ProductController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_shopContext.products.ToList());
        }

        [HttpGet]
        [Route("productslist")]
        public async Task<ActionResult> GetAllProducts([FromQuery] ProductQueryParameters queryParameters)
        {
            //load data
            IQueryable<Product> products = _shopContext.products.AsQueryable();

            //filter data
            if (!string.IsNullOrEmpty(queryParameters.filter_ProductName))
            {
                products = products.Where(a => a.Name == queryParameters.filter_ProductName);
            }
            if (!string.IsNullOrEmpty(queryParameters.filter_Description))
            {
                products = products.Where(a => a.Description.Contains(queryParameters.filter_Description));
            }
            if (!string.IsNullOrEmpty(queryParameters.filter_SearchTerm))
            {
                products = products.Where(a => a.Description.Contains(queryParameters.filter_SearchTerm) ||
                                                a.Name.Contains(queryParameters.filter_SearchTerm)
                );
            }
            if (queryParameters.filter_MinPrice != null)
            {
                products = products.Where(a => a.Price >= queryParameters.filter_MinPrice);
            }
            if (queryParameters.filter_MaxPrice != null)
            {
                products = products.Where(a => a.Price <= queryParameters.filter_MaxPrice);
            }
            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Product).GetProperty(queryParameters.SortBy) != null)
                {
                    products = products.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }
            //paging
            products = products.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);

            return Ok(await products.ToListAsync());
        }

        //[HttpGet("{ProductId}")]
        [HttpGet]
        [Route("getProduct/{ProductId}")]
        public async Task<ActionResult> GetProductById([FromRoute] int ProductId)
        {
            var product = await _shopContext.products.FindAsync(ProductId);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpGet]
        [Route("getProductQuery")]
        public async Task<ActionResult> GetProductByIdQuery([FromQuery] int ProductId)
        {
            var product = await _shopContext.products.FindAsync(ProductId);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpPost]
        [Route("addProduct")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            _shopContext.products.Add(product);
            await _shopContext.SaveChangesAsync();

            return CreatedAtAction("GetProductById", new { ProductId = product.Id }, product);
        }

        [HttpPost]
        [Route("addProductCustom")]
        public async Task<ActionResult> AddProductCustom(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _shopContext.products.Add(product);
            await _shopContext.SaveChangesAsync();

            return CreatedAtAction("GetProductById", new { ProductId = product.Id }, product);
        }
        [HttpPut]
        [Route("updateProduct/{ProductId}")]
        public async Task<ActionResult> UpdateProduct(int ProductId, Product product)
        {

            if (ProductId != product.Id)
            {
                return BadRequest();
            }
            _shopContext.Entry(product).State = EntityState.Modified;
            try
            {
                await _shopContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_shopContext.products.Any(a => a.Id == ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        [HttpDelete]
        [Route("deleteproduct/{ProductId}")]
        //[HttpDelete("{ProductId}")]
        public async Task<ActionResult<Product>> DeleteProduct(int ProductId)
        {
            var product = await _shopContext.products.FindAsync(ProductId);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _shopContext.products.Remove(product);
                await _shopContext.SaveChangesAsync();
                return product;
            }
            return Ok();
        }


        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<Product>> DeleteMultiple([FromQuery] int[] ProductIds)
        {
            var products = new List<Product>();
            foreach (var ProductId in ProductIds)
            {
                var product = await _shopContext.products.FindAsync(ProductId);
                if (product == null)
                {
                    return NotFound();
                }
                products.Add(product);
            }
            _shopContext.products.RemoveRange(products);
            await _shopContext.SaveChangesAsync();
            return Ok(products);
        }
    }
}
