using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.DataAccessLayer.EF.Migrations
{
    public partial class plp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desscription",
                table: "Products",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "TotalPrice",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Desscription");
        }
    }
}
