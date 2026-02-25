using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kviz.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    TipKorisnika = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Ispiti",
                columns: table => new
                {
                    Sifra = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: false),
                    ProfesorUsername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispiti", x => x.Sifra);
                    table.ForeignKey(
                        name: "FK_Ispiti_Korisnici_ProfesorUsername",
                        column: x => x.ProfesorUsername,
                        principalTable: "Korisnici",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pitanja",
                columns: table => new
                {
                    PitanjeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PitanjeTekst = table.Column<string>(type: "TEXT", nullable: false),
                    IspitId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipPitanja = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    OdgovorTocanJson = table.Column<string>(type: "TEXT", nullable: true),
                    OdgovorUnesen = table.Column<string>(type: "TEXT", nullable: true),
                    OdgovorTocan = table.Column<char>(type: "TEXT", nullable: true),
                    OdgovorUneseni = table.Column<char>(type: "TEXT", nullable: true),
                    PonudeniOdgJson = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanja", x => x.PitanjeId);
                    table.ForeignKey(
                        name: "FK_Pitanja_Ispiti_IspitId",
                        column: x => x.IspitId,
                        principalTable: "Ispiti",
                        principalColumn: "Sifra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezultati",
                columns: table => new
                {
                    RezultatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IspitId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentUsername = table.Column<string>(type: "TEXT", nullable: false),
                    BrojTocnihOdgovora = table.Column<int>(type: "INTEGER", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezultati", x => x.RezultatId);
                    table.ForeignKey(
                        name: "FK_Rezultati_Ispiti_IspitId",
                        column: x => x.IspitId,
                        principalTable: "Ispiti",
                        principalColumn: "Sifra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezultati_Korisnici_StudentUsername",
                        column: x => x.StudentUsername,
                        principalTable: "Korisnici",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Username", "Password", "TipKorisnika" },
                values: new object[,]
                {
                    { "profesor", "87654321", "Profesor" },
                    { "student", "12345678", "Student" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ispiti_ProfesorUsername",
                table: "Ispiti",
                column: "ProfesorUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanja_IspitId",
                table: "Pitanja",
                column: "IspitId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezultati_IspitId",
                table: "Rezultati",
                column: "IspitId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezultati_StudentUsername",
                table: "Rezultati",
                column: "StudentUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pitanja");

            migrationBuilder.DropTable(
                name: "Rezultati");

            migrationBuilder.DropTable(
                name: "Ispiti");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
