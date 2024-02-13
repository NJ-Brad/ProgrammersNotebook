using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersNotebook.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MigrationTest",
                table: "Pages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MigrationTest",
                table: "Pages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
