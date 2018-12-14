using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Glasses.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Brand_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Glassbrand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Brand_ID);
                });

            migrationBuilder.CreateTable(
                name: "Glasses",
                columns: table => new
                {
                    Glass_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Brand_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glasses", x => x.Glass_ID);
                    table.ForeignKey(
                        name: "FK_Glasses_Brands_Brand_ID",
                        column: x => x.Brand_ID,
                        principalTable: "Brands",
                        principalColumn: "Brand_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Glasses_Brand_ID",
                table: "Glasses",
                column: "Brand_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Glasses");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
