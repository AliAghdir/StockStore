using Microsoft.EntityFrameworkCore.Migrations;

namespace StockStore.WebApp.Migrations
{
    public partial class ChangeSeedDataInStockStoreContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "مانیتور", "مانیتور" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[] { 4, 4500m, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "لپ‌تاپ‌های سری X‌ «ایسوس» به‌نسبت کارایی و کیفیت، قیمت مناسبی دارند و جزو پرطرفدارترین محصولات این شرکت هستند. این محصولات معمولاً با مشخصات سخت‌افزاری مختلف و در طرح‌ها و رنگبندی‌های متنوعی عرضه می‌شوند تا پاسخ‌گوی نیاز کاربران مختلف باشند. یکی از این محصولات X543MA-GQ1012 است که مثل مدل‌های قبلی تماما از پلاستیک ساخته شده است؛ اما کیفیت و استحکام آن حس بدنه‌ی آلومینیومی را القا می‌کند. این لپ‌تاپ با وجود ضخامت بدنه‌ی تقریبا زیاد 27میلی‌متری، فقط حدود 2 کیلوگرم وزن دارد", "لپ تاپ 15.6 اینچی ایسوس مدل X543MA-GQ1012" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { " IdeaPad 3 15IGL05 – Z یک سیستم با ظاهری خشک است. سیستمی که در طراحی آن در عین شیک بودن ظاهری بسیار خشک و بی روح را می‌توان مشاهده کرد. البته شاید این موضوع در رنگ‌های نقره‌ای و مشکی دیده شود و رنگ زرشکی این حس را کمتر منتقل کند. در ظاهر این سیستم می‌توان کیبورد این محصول را مشاهده کرد که با کلیدهای نرم پوشیده شده‌است. شاید این کیبورد back lit  نداشته باشد اما این موضوع به هیچ عنوان از قابلیت‌های خاص آن کم نمی‌کند. یکی از قابلیت‌های آن همان استاندارد بودن این کیبورد بوده که برای استفاده بسیار نرم و راحت است اما باید در نظر گرفت در زمان بازی شاید نتوان گفت کیبورد مناسبی است زیرا کیبوردهای مناسب برای بازی مقداری سخت‌تر هستند تا به راحتی زیر انگشت دست حس شوند. از دیگر موارد ظاهری می‌توان به وب‌کم این محصول توجه داشت که در بالای لپ‌تاپ قرار گرفته است و به راحتی قابل استفاده است.", "لپ تاپ 15.6 اینچی لنوو مدل IdeaPad 3 15IGL05 - Z" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "سری لپ‌تاپ‌های مک‌بوک شرکت اپل تا به امروز بدون هیچ تعریف اضافی توانسته‌اند با بهره بردن از مشخصات فنی قدرتمند، عملکرد بسیار خوب و قابل قبولی را ارائه کنند. یکی از لپ‌تاپ‌های قدرتمند این سری، مدل MacBook Pro Mk183 2021 است. این لپ‌تاپ به صفحه‌نمایش با ابعاد 16.2 اینچی با رزولوشن 2234×3456 پیکسل از نوع Liquid Retina XDR مجهز شده است که توانایی نمایش 254 پیکسل در هر اینچ را دارد.", "لپ تاپ 16.2 اینچی اپل مدل MacBook Pro Mk183 2021" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 4, "بالاخره بعد از شایعات، شاهد رونمایی جدید‌ترین گوشی‌های هوشمند اپل در قالب خانواده آیفون 13 بودیم. آیفون 13 پرو مکس، آیفون 13 پرو، آیفون 13 و آیفون 13 مینی به‌عنوان جدید‌ترین گوشی‌های هوشمند این شرکت معرفی شدند. آیفون 13 پرو مکس بدون شک به مشخصات فنی قدرتمند‌تری به نسبت ما‌بقی اعضای این خانواده مجهز شده است. از نظر طراحی تفاوت چندانی با نسل قبلی پرچمداران این شرکت شاهد نبودیم. تنها در نمای رو به رویی این بار اپل از ناچ با عرض کمتری به نسبت نسل قبلی بهره برده است.", 4, "iPhone 13 Pro Max A2644" });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "ProductId", "CategoryId" },
                values: new object[] { 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "ProductId", "CategoryId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "تلویزیون", "تلویزیون" });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "ProductId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "آموزش Asp.Net Core 3 پروژه محور ASP.NET Core بر پایه‌ی NET Core.استوار است و نگارشی از NET.محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند.ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری(Cloud) هم بتوانند میزبانی(Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET.را افزایش داده است.به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.", "آموزش Asp.Net Core 3 پروژه محور" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "در سال های گذشته ، کمپانی مایکروسافت با معرفی تکنولوژی های جدید و حرفه ای در زمینه های مختلف ، عرصه را برای سایر کمپانی ها تنگ تر کرده است. اخیرا این غول فناوری با معرفی فریم ورک های ASP.NET Core و همینطور Blazor قدرت خود در زمینه ی وب را به اثبات رسانده است.", "آموزش Blazor از مقدماتی تا پیشرفته" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "آموزش اپلیکیشن های وب پیش رونده ( PWA ) آموزش PWA از مقدماتی تا پیشرفته وب اپلیکیشن‌های پیش رونده(PWA) نسل جدید اپلیکیشن‌های تحت وب هستند که می‌توانند آینده‌ی اپلیکیشن‌های موبایل را متحول کنند.در این دوره به طور جامع به بررسی آن‌ها خواهیم پرداخت. مزایا و فاکتور هایی که یک وب اپلیکیشن دارا می باشد به صورت زیر می باشد : ریسپانسیو :  رکن اصلی سایت برای PWA ریسپانسیو بودن اپلیکیشن هستش که برای صفحه نمایش کاربران مختلف موبایل و تبلت خود را وفق دهند.", "آموزش اپلیکیشن های وب پیش رونده ( PWA )" });
        }
    }
}
