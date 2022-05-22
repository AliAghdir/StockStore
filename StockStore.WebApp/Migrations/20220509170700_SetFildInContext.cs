using Microsoft.EntityFrameworkCore.Migrations;

namespace StockStore.WebApp.Migrations
{
    public partial class SetFildInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProduct_Categories_CategoryId",
                table: "CategoryToProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProduct_Product_ProductId",
                table: "CategoryToProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Item_ItemId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToProduct",
                table: "CategoryToProduct");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "CategoryToProduct",
                newName: "CategoryToProducts");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ItemId",
                table: "Products",
                newName: "IX_Products_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryToProduct_CategoryId",
                table: "CategoryToProducts",
                newName: "IX_CategoryToProducts_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Categories_CategoryId",
                table: "CategoryToProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Products_ProductId",
                table: "CategoryToProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Items_ItemId",
                table: "Products",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Categories_CategoryId",
                table: "CategoryToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Products_ProductId",
                table: "CategoryToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Items_ItemId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "CategoryToProducts",
                newName: "CategoryToProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ItemId",
                table: "Product",
                newName: "IX_Product_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryToProducts_CategoryId",
                table: "CategoryToProduct",
                newName: "IX_CategoryToProduct_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToProduct",
                table: "CategoryToProduct",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProduct_Categories_CategoryId",
                table: "CategoryToProduct",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProduct_Product_ProductId",
                table: "CategoryToProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Item_ItemId",
                table: "Product",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
