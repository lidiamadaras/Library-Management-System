using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mentorp.Migrations
{
    /// <inheritdoc />
    public partial class FourthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryID",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryID",
                table: "Books",
                column: "LibraryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libraries_LibraryID",
                table: "Books",
                column: "LibraryID",
                principalTable: "Libraries",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libraries_LibraryID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LibraryID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LibraryID",
                table: "Books");
        }
    }
}
