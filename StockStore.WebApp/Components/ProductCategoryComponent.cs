using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockStore.WebApp.Data;
using StockStore.WebApp.Models;
using StockStore.WebApp.Data.Repositories;

namespace StockStore.WebApp.Components
{
    public class ProductCategoryComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public ProductCategoryComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductCategoryComponent.cshtml", _categoryRepository.GetAllCategoriesForShow());
        }
    }
}