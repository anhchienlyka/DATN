using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.DataAccessLayer.EF.Migrations
{
    public partial class InitialCreatedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Customers_CustomerId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CustomerId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CustomerId",
                table: "Roles",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Customers_CustomerId",
                table: "Roles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
