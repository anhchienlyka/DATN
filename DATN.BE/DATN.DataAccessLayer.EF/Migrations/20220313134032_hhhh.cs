using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.DataAccessLayer.EF.Migrations
{
    public partial class hhhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ViewProduct",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewProduct",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
