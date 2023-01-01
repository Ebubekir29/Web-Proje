using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWebProje.Migrations
{
    public partial class updatecommendsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "commends",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "commends",
                newName: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "commends",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "commends",
                newName: "Email");
        }
    }
}
