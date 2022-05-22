using System.Security.AccessControl;
using System.Collections.Generic;
using StockStore.WebApp.Models;
using StockStore.WebApp.Data.Repositories;
using System.Linq;

namespace StockStore.WebApp.Data.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StockStoreContext _context;
        public CategoryRepository(StockStoreContext stockStoreContext)
        {
            _context = stockStoreContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ProductCategoryViewModel> GetAllCategoriesForShow()
        {
            return _context.Categories.Select(C => new ProductCategoryViewModel()
            {
                CategoryId = C.Id,
                CategoryName = C.Name,
                ProductsCount = _context.CategoryToProducts.Count(g => g.CategoryId == C.Id)
            });
        }
    }
}