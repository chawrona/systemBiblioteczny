using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace systemBiblioteczny.Migrations
{
    /// <inheritdoc />
    public partial class nowa3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BooksStatuses_BookStatusId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookStatusId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookStatusId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdBookStatus",
                table: "Books",
                column: "IdBookStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BooksStatuses_IdBookStatus",
                table: "Books",
                column: "IdBookStatus",
                principalTable: "BooksStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BooksStatuses_IdBookStatus",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdBookStatus",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookStatusId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookStatusId",
                table: "Books",
                column: "BookStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BooksStatuses_BookStatusId",
                table: "Books",
                column: "BookStatusId",
                principalTable: "BooksStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
