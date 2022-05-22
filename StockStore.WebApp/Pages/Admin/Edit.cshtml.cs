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
    public class EditModel : PageModel
    {
        private readonly StockStoreContext _context;

        public EditModel(StockStoreContext stockStoreContext)
        {
            _context = stockStoreContext;
        }

        [BindProperty]
        public AddAndEditProductViewModel ProductVM { get; set; }
        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public List<int> CategoriesProduct { get; set; }

        public void OnGet(int productId)
        {
            ProductVM = _context.Products
                .Where(p => p.Id == productId)
                .Include(p => p.Item)
                .Select(p => new AddAndEditProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Item.Price,
                    QuantityInStock = p.Item.QuantityInStock,
                    Categories = _context.Categories.ToList()
                }).FirstOrDefault();

                CategoriesProduct = _context.CategoryToProducts.Where(c => c.ProductId == productId)
                .Select(s => s.CategoryId).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = _context.Products.Find(ProductVM.Id);
            var item = _context.Items.Find(product.ItemId);

            product.Name = ProductVM.Name;
            product.Description = ProductVM.Description;
            item.Price = ProductVM.Price;
            item.QuantityInStock = ProductVM.QuantityInStock;

            _context.SaveChanges();

            if (ProductVM.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "img",
                product.Id +
                Path.GetExtension(ProductVM.Picture.FileName));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProductVM.Picture.CopyTo(fileStream);
                }
            }

            _context.CategoryToProducts.Where(c => c.ProductId == ProductVM.Id).ToList()
                            .ForEach(g => _context.CategoryToProducts.Remove(g));
            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = gr,
                        ProductId = product.Id
                    });
                }
                _context.SaveChanges();
            }

            return RedirectToPage("index");
        }
    }
}