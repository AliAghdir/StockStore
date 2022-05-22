using System.Collections.Generic;
using StockStore.WebApp.Models;

namespace StockStore.WebApp.Data.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ProductCategoryViewModel> GetAllCategoriesForShow();
    }
}