using System.ComponentModel;
using System.Transactions;
namespace StockStore.WebApp.Models
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public Category Category { get; set; }
        public Product product { get; set; }
    }
}