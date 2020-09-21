using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiDataService.Migrations
{
    public partial class DataInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dataIntersection",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Objectindex = table.Column<int>(nullable: false),
                    Versionindex = table.Column<int>(nullable: false),
                    Intersection = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataIntersection", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dataIntersection");
        }
    }
}
