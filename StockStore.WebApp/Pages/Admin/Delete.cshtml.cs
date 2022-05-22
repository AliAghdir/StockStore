using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StockStore.WebApp.Data;
using StockStore.WebApp.Models;

namespace StockStore.WebApp.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly StockStoreContext _context;

        public DeleteModel(StockStoreContext stockStoreContext)
        {
            _context = stockStoreContext;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int productId)
        {
            Product = _context.Products
                .FirstOrDefault(p=>p.Id==productId);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.Find(product.ItemId);

            _context.Items.Remove(item);
            _context.Products.Remove(product);
            _context.SaveChanges();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot",
            "img",
            product.Id+ ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("index");
        }
    }
}