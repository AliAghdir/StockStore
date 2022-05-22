using System.Collections.Generic;
using System.Security.AccessControl;
using System.Reflection.PortableExecutable;
namespace StockStore.WebApp.Models
{
    public class DetailsViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}