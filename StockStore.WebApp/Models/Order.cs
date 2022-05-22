using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockStore.WebApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsFinaly { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Order(){}
        public Order(int userId)
        {
            UserId=userId;
            CreateDate = DateTime.Now;
            IsFinaly= false;
        }
    }
}