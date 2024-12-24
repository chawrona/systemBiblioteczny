using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace systemBiblioteczny.Migrations
{
    /// <inheritdoc />
    public partial class _241220241 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookStatuses_BookStatusesId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookStatusesId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookStatusesId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookStatusesId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookStatusesId",
                table: "Books",
                column: "BookStatusesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookStatuses_BookStatusesId",
                table: "Books",
                column: "BookStatusesId",
                principalTable: "BookStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
