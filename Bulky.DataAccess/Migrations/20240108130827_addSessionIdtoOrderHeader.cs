using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSessionIdtoOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "shoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "OrderHeaders");

            migrationBuilder.RenameTable(
                name: "shoppingCarts",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_ProductId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
