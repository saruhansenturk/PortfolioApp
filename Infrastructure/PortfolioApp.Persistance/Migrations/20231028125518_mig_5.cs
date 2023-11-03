using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkToUrl",
                table: "Articles",
                newName: "Introduction");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Articles",
                newName: "Conclusion");

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "Articles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Articles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "Articles",
                newName: "LinkToUrl");

            migrationBuilder.RenameColumn(
                name: "Conclusion",
                table: "Articles",
                newName: "Content");
        }
    }
}
