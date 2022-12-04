using Akhil_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Akhil_API.Controllers
{
    public class SqlController : Controller
    {
        private readonly CoreDbContext _coreContext;
        public SqlController(CoreDbContext coreContext)
        {
            _coreContext = coreContext;
        }
        [HttpGet]
        [Route("users")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_coreContext.Users.ToList());
        }
    }
}
