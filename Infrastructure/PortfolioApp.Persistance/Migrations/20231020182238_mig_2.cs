using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProgrammingLanguageTechs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProgrammingLanguages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProgrammingLanguageTechs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProgrammingLanguages");
        }
    }
}
