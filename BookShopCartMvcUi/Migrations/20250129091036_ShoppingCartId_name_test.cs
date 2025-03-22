using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmShopMVC.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartId_name_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId_test",
                table: "CartDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingCartId_test",
                table: "CartDetail");
        }
    }
}
