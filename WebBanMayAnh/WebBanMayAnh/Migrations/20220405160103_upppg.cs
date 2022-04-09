using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanMayAnh.Migrations
{
    public partial class upppg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeFlag",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HomeFlag",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
