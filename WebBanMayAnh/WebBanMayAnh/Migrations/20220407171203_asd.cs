using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanMayAnh.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CatID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CatID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CatID",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CatID",
                table: "Posts",
                column: "CatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CatID",
                table: "Posts",
                column: "CatID",
                principalTable: "Categories",
                principalColumn: "CatID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
