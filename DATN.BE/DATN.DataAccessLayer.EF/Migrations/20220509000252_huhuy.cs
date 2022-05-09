using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.DataAccessLayer.EF.Migrations
{
    public partial class huhuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceInput",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ToltalCost",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceInput",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ToltalCost",
                table: "Orders");
        }
    }
}
