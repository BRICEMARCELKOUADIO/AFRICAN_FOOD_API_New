using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_coreapi.Migrations
{
    public partial class ClientNumberInShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientNumber",
                table: "ShoppingCartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientNumber",
                table: "ShoppingCartItems");
        }
    }
}
