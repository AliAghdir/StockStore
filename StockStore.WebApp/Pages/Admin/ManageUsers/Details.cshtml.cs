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
    public class DetailsModel : PageModel
    {
        private readonly StockStoreContext _context;

        public DetailsModel(StockStoreContext stockStoreContext)
        {
            _context = stockStoreContext;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
