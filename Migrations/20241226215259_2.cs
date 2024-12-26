using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace systemBiblioteczny.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Books_BookId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_BookId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Rentals");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdBook",
                table: "Rentals",
                column: "IdBook");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Books_IdBook",
                table: "Rentals",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Books_IdBook",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_IdBook",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BookId",
                table: "Rentals",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Books_BookId",
                table: "Rentals",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
