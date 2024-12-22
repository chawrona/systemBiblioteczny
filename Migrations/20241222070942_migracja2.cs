using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace systemBiblioteczny.Migrations
{
    /// <inheritdoc />
    public partial class migracja2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdBookStatus",
                table: "Books",
                column: "IdBookStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookStatus_IdBookStatus",
                table: "Books",
                column: "IdBookStatus",
                principalTable: "BookStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookStatus_IdBookStatus",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookStatus");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdBookStatus",
                table: "Books");
        }
    }
}
