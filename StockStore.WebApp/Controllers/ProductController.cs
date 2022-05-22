using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockStore.WebApp.Data;

namespace StockStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly StockStoreContext _context;
        public ProductController(StockStoreContext stockStoreContext)
        {
            _context = stockStoreContext;
        }

        [Route("/Category/{categoryId}/{categoryName}")]
        public IActionResult ShowProductByCategoryId(int categoryId, string categoryName)
        {
            var products = _context.CategoryToProducts
            .Where(c=>c.CategoryId==categoryId)
            .Include(p=>p.product).Select(p=>p.product).ToList();

            ViewData["CategoryName"]=categoryName;
            
            return View(products);
        }
    }
}