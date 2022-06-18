using Microsoft.EntityFrameworkCore;
using StockStore.WebApp.Models;

namespace StockStore.WebApp.Data
{
    public class StockStoreContext : DbContext
    {
        public StockStoreContext(DbContextOptions<StockStoreContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });

            #region Seed Data

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "لپ تاپ",
                Description = "لپ تاپ"
            },
                new Category()
                {
                    Id = 2,
                    Name = "موبایل",
                    Description = "موبایل"
                },
                new Category()
                {
                    Id = 3,
                    Name = "ساعت هوشمند",
                    Description = "ساعت هوشمند"
                },
                new Category()
                {
                    Id = 4,
                    Name = "مانیتور",
                    Description = "مانیتور"
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    Price = 854.0M,
                    QuantityInStock = 5
                },
                new Item()
                {
                    Id = 2,
                    Price = 3302.0M,
                    QuantityInStock = 8
                },
                new Item()
                {
                    Id = 3,
                    Price = 2500,
                    QuantityInStock = 3
                },
                new Item()
                {
                    Id = 4,
                    Price = 4500,
                    QuantityInStock = 3
                });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemId = 1,
                Name = "لپ تاپ 15.6 اینچی ایسوس مدل X543MA-GQ1012",
                Description =
                        "لپ‌تاپ‌های سری X‌ «ایسوس» به‌نسبت کارایی و کیفیت، قیمت مناسبی دارند و جزو پرطرفدارترین محصولات این شرکت هستند. این محصولات معمولاً با مشخصات سخت‌افزاری مختلف و در طرح‌ها و رنگبندی‌های متنوعی عرضه می‌شوند تا پاسخ‌گوی نیاز کاربران مختلف باشند. یکی از این محصولات X543MA-GQ1012 است که مثل مدل‌های قبلی تماما از پلاستیک ساخته شده است؛ اما کیفیت و استحکام آن حس بدنه‌ی آلومینیومی را القا می‌کند. این لپ‌تاپ با وجود ضخامت بدنه‌ی تقریبا زیاد 27میلی‌متری، فقط حدود 2 کیلوگرم وزن دارد"
            },
                new Product()
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "لپ تاپ 15.6 اینچی لنوو مدل IdeaPad 3 15IGL05 - Z",
                    Description =
                        " IdeaPad 3 15IGL05 – Z یک سیستم با ظاهری خشک است. سیستمی که در طراحی آن در عین شیک بودن ظاهری بسیار خشک و بی روح را می‌توان مشاهده کرد. البته شاید این موضوع در رنگ‌های نقره‌ای و مشکی دیده شود و رنگ زرشکی این حس را کمتر منتقل کند. در ظاهر این سیستم می‌توان کیبورد این محصول را مشاهده کرد که با کلیدهای نرم پوشیده شده‌است. شاید این کیبورد back lit  نداشته باشد اما این موضوع به هیچ عنوان از قابلیت‌های خاص آن کم نمی‌کند. یکی از قابلیت‌های آن همان استاندارد بودن این کیبورد بوده که برای استفاده بسیار نرم و راحت است اما باید در نظر گرفت در زمان بازی شاید نتوان گفت کیبورد مناسبی است زیرا کیبوردهای مناسب برای بازی مقداری سخت‌تر هستند تا به راحتی زیر انگشت دست حس شوند. از دیگر موارد ظاهری می‌توان به وب‌کم این محصول توجه داشت که در بالای لپ‌تاپ قرار گرفته است و به راحتی قابل استفاده است."
                },
                new Product()
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "لپ تاپ 16.2 اینچی اپل مدل MacBook Pro Mk183 2021",
                    Description = "سری لپ‌تاپ‌های مک‌بوک شرکت اپل تا به امروز بدون هیچ تعریف اضافی توانسته‌اند با بهره بردن از مشخصات فنی قدرتمند، عملکرد بسیار خوب و قابل قبولی را ارائه کنند. یکی از لپ‌تاپ‌های قدرتمند این سری، مدل MacBook Pro Mk183 2021 است. این لپ‌تاپ به صفحه‌نمایش با ابعاد 16.2 اینچی با رزولوشن 2234×3456 پیکسل از نوع Liquid Retina XDR مجهز شده است که توانایی نمایش 254 پیکسل در هر اینچ را دارد."
                },
                new Product()
                {
                    Id = 4,
                    ItemId = 4,
                    Name = "iPhone 13 Pro Max A2644",
                    Description = "بالاخره بعد از شایعات، شاهد رونمایی جدید‌ترین گوشی‌های هوشمند اپل در قالب خانواده آیفون 13 بودیم. آیفون 13 پرو مکس، آیفون 13 پرو، آیفون 13 و آیفون 13 مینی به‌عنوان جدید‌ترین گوشی‌های هوشمند این شرکت معرفی شدند. آیفون 13 پرو مکس بدون شک به مشخصات فنی قدرتمند‌تری به نسبت ما‌بقی اعضای این خانواده مجهز شده است. از نظر طراحی تفاوت چندانی با نسل قبلی پرچمداران این شرکت شاهد نبودیم. تنها در نمای رو به رویی این بار اپل از ناچ با عرض کمتری به نسبت نسل قبلی بهره برده است."
                });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 4 }
                );
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}