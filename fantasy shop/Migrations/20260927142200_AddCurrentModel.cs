using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fantasy_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orderss_OrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderss",
                table: "Orderss");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Orderss",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orderss");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderss",
                table: "Orderss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orderss_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orderss",
                principalColumn: "Id");
        }
    }
}
