using System.Collections.Generic;

namespace StockStore.WebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CategoryToProduct> categoryToProuducts { get; set; }    
    }
}