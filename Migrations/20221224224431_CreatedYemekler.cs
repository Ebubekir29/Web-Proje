using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWebProje.Migrations
{
    public partial class CreatedYemekler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yemekler",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    yemekIsmi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    yemeginKategorisi = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    YemekTarifi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yemekler", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yemekler");
        }
    }
}
