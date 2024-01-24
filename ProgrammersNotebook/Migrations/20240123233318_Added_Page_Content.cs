using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersNotebook.Migrations
{
    /// <inheritdoc />
    public partial class Added_Page_Content : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageContent",
                table: "Pages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageContent",
                table: "Pages");
        }
    }
}
