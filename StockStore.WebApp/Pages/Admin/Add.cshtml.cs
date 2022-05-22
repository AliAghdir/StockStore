using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockStore.WebApp.Data;
using StockStore.WebApp.Models;

namespace StockStore.WebApp.Pages.Admin
{
    public class AddModel : PageModel
    {
        private readonly StockStoreContext _context;

        public AddModel(StockStoreContext stockStoreContext)
        {
            _context = stockStoreContext;

        }
        
        [BindProperty]
        public AddAndEditProductViewModel ProductVM { get; set; }
        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public void OnGet()
        {
            ProductVM = new AddAndEditProductViewModel()
            {
                Categories = _context.Categories.ToList()
            };
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var item = new Item()
            {
                Price = ProductVM.Price,
                QuantityInStock = ProductVM.QuantityInStock
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                Name = ProductVM.Name,
                Item = item,
                Description = ProductVM.Description,
                
            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();

            if (ProductVM.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "img",
                    pro.Id + Path.GetExtension(ProductVM.Picture.FileName));
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    ProductVM.Picture.CopyTo(stream);
                }
            }

            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = gr,
                        ProductId = pro.Id
                    });
                }
                _context.SaveChanges();
            }


            return RedirectToPage("Index");
        }
    }
}
