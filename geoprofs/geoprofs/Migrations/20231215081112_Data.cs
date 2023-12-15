using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace geoprofs.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositieNaam = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Werknemer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Wachtwoord = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DatumIndienst = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoVerlof = table.Column<int>(type: "int", nullable: false),
                    Vakantie = table.Column<int>(type: "int", nullable: false),
                    Persoonlijk = table.Column<int>(type: "int", nullable: false),
                    Ziek = table.Column<int>(type: "int", nullable: false),
                    PositieId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Werknemer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Werknemer_Positie_PositieId",
                        column: x => x.PositieId,
                        principalTable: "Positie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Aanvraag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WerknemersId = table.Column<int>(type: "int", nullable: false),
                    VanafDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vakantie = table.Column<int>(type: "int", nullable: false),
                    Persoonlijk = table.Column<int>(type: "int", nullable: false),
                    Ziek = table.Column<int>(type: "int", nullable: false),
                    Goedkeuring = table.Column<int>(type: "int", nullable: false),
                    OndersteundDoor = table.Column<int>(type: "int", nullable: false),
                    WerknemerId = table.Column<int>(type: "int", nullable: false),
                    OndersteundDoorWerknemerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanvraag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aanvraag_Werknemer_OndersteundDoorWerknemerId",
                        column: x => x.OndersteundDoorWerknemerId,
                        principalTable: "Werknemer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Aanvraag_Werknemer_WerknemerId",
                        column: x => x.WerknemerId,
                        principalTable: "Werknemer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_OndersteundDoorWerknemerId",
                table: "Aanvraag",
                column: "OndersteundDoorWerknemerId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_WerknemerId",
                table: "Aanvraag",
                column: "WerknemerId");

            migrationBuilder.CreateIndex(
                name: "IX_Werknemer_PositieId",
                table: "Werknemer",
                column: "PositieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aanvraag");

            migrationBuilder.DropTable(
                name: "Werknemer");

            migrationBuilder.DropTable(
                name: "Positie");
        }
    }
}
