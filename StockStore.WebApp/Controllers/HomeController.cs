using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockStore.WebApp.Data;
using StockStore.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ZarinpalSandbox;

namespace StockStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StockStoreContext _context;
        
        public HomeController(ILogger<HomeController> logger, StockStoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Detail(int productId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            var categories = _context.Products
                    .Where(p => p.Id == productId)
                    .SelectMany(p => p.categoryToProuducts)
                    .Select(c => c.Category).ToList();

            var vm = new DetailsViewModel()
            {
                Categories = categories,
                Product = product
            };
            return View(vm);
        }

        [Authorize]
        public IActionResult AddToOrder(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product == null)
                return NotFound();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);

            if (order != null)
            {
                var orderDetail = _context.OrderDetails
                .FirstOrDefault(o=>o.OrderId==order.OrderId&&o.ProductId==product.Id);

                if (orderDetail!=null)
                {
                    orderDetail.Count +=1;
                }
                else
                {
                    var newOrderDetail = new OrderDetail(order.OrderId, product.Id, product.Item.Price);
                    _context.Add(newOrderDetail);
                }
            }
            else
            {
                var newOrder = new Order(userId);
                _context.Add(newOrder);
                _context.SaveChanges();

                var newOrderDetail = new OrderDetail(newOrder.OrderId, product.Id, product.Item.Price);
                _context.Add(newOrderDetail);
            }

            _context.SaveChanges();
            return RedirectToAction("ShowOrder");
        }

        [Authorize]
        public IActionResult ShowOrder()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o=>o.UserId==userId&&!o.IsFinaly)
            .Include(o=>o.OrderDetails)
            .ThenInclude(o=>o.Product).FirstOrDefault();
            
            return View(order);
        }

        [Authorize]
        public IActionResult RemoveOrderDetail(int detailId)
        {
            var orderDetail = _context.OrderDetails.Find(detailId);
            if (orderDetail.Count > 1)
            {
                orderDetail.Count -= 1;
            }
            else
            {
                _context.Remove(orderDetail);
            }
            _context.SaveChanges();

            return RedirectToAction("ShowOrder");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Payment()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var order = _context.Orders
                .Include(o=>o.OrderDetails)
                .FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
            if (order == null)
                return NotFound();

            var payment = new Payment((int)order.OrderDetails.Sum(d=>d.Price));
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.OrderId}",
                "http://localhost:5000/Home/OnlinePayment/" + order.OrderId, "Ali@gmail.com", "09195050505");
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }

        }

        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _context.Orders.Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.OrderId == id);
                var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }
            }

            return NotFound();
        }
    }
}
