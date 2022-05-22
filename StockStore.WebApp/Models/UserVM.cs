using System;
using System.ComponentModel.DataAnnotations;

namespace StockStore.WebApp.Models
{
    public class UserVM
    {
        
        [Required]
        [MaxLength(50)]
        public string Password { get; private set; }
    }
}