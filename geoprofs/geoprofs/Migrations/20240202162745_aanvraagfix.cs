using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace geoprofs.Migrations
{
    public partial class aanvraagfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Persoonlijk",
                table: "Aanvraag");

            migrationBuilder.DropColumn(
                name: "Vakantie",
                table: "Aanvraag");

            migrationBuilder.DropColumn(
                name: "Ziek",
                table: "Aanvraag");

            migrationBuilder.AddColumn<string>(
                name: "SelectionType",
                table: "Aanvraag",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectionType",
                table: "Aanvraag");

            migrationBuilder.AddColumn<bool>(
                name: "Persoonlijk",
                table: "Aanvraag",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vakantie",
                table: "Aanvraag",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ziek",
                table: "Aanvraag",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
