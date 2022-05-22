using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StockStore.WebApp.Data;
using StockStore.WebApp.Models;

namespace StockStore.WebApp.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly StockStoreContext _context;

        public IndexModel(StockStoreContext stockStoreContext)
        {
            _context = stockStoreContext;
        }

        public IList<User> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
