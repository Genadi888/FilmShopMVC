using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmShopMVC.Migrations
{
    /// <inheritdoc />
    public partial class added_UnitPrice_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitsPrice",
                table: "OrderDetails",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "CartDetail",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "CartDetail");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderDetails",
                newName: "UnitsPrice");
        }
    }
}
