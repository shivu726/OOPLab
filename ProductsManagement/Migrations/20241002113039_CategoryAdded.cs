using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsManagement.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tbl_Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Products_CategoryId",
                table: "tbl_Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Products_Categories_CategoryId",
                table: "tbl_Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Products_Categories_CategoryId",
                table: "tbl_Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Products_CategoryId",
                table: "tbl_Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tbl_Products");
        }
    }
}
