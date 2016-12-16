using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneymoonShop.Migrations
{
    public partial class DatabaseV16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessoire",
                columns: table => new
                {
                    AccessoireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categorie = table.Column<string>(nullable: true),
                    Geslacht = table.Column<string>(nullable: true),
                    LinkNaarWebshop = table.Column<string>(nullable: true),
                    Merk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessoire", x => x.AccessoireId);
                });

            migrationBuilder.CreateTable(
                name: "Afspraak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Achternaam = table.Column<string>(nullable: true),
                    DatumTijd = table.Column<DateTime>(nullable: false),
                    EmailAdres = table.Column<string>(nullable: true),
                    SoortAfspraak = table.Column<string>(nullable: true),
                    TelefoonNummer = table.Column<int>(nullable: false),
                    Trouwdatum = table.Column<DateTime>(nullable: false),
                    Voornaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afspraak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kleding",
                columns: table => new
                {
                    Artikelnummer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kleding_type = table.Column<string>(nullable: false),
                    Merk = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true),
                    Prijs = table.Column<int>(nullable: false),
                    Materiaal = table.Column<string>(nullable: true),
                    Neklijn = table.Column<string>(nullable: true),
                    Silhouette = table.Column<string>(nullable: true),
                    Stijl = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kleding", x => x.Artikelnummer);
                });

            migrationBuilder.CreateTable(
                name: "AccessoireAfbeeldingenen",
                columns: table => new
                {
                    AccessoireAfbeelding = table.Column<string>(nullable: false),
                    AccessoireId = table.Column<int>(nullable: false),
                    SourceLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoireAfbeeldingenen", x => x.AccessoireAfbeelding);
                    table.UniqueConstraint("AK_AccessoireAfbeeldingenen_AccessoireId", x => x.AccessoireId);
                    table.ForeignKey(
                        name: "FK_AccessoireAfbeeldingenen_Accessoire_AccessoireId",
                        column: x => x.AccessoireId,
                        principalTable: "Accessoire",
                        principalColumn: "AccessoireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KledingAccessoire",
                columns: table => new
                {
                    Artikelnummer = table.Column<int>(nullable: false),
                    AccessoireId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KledingAccessoire", x => new { x.Artikelnummer, x.AccessoireId });
                    table.ForeignKey(
                        name: "FK_KledingAccessoire_Accessoire_AccessoireId",
                        column: x => x.AccessoireId,
                        principalTable: "Accessoire",
                        principalColumn: "AccessoireId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KledingAccessoire_Kleding_Artikelnummer",
                        column: x => x.Artikelnummer,
                        principalTable: "Kleding",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KledingAfbeeldingenen",
                columns: table => new
                {
                    Artikelnummer = table.Column<int>(nullable: false),
                    KledingAfbeelding = table.Column<string>(nullable: false),
                    SourceLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KledingAfbeeldingenen", x => x.Artikelnummer);
                    table.UniqueConstraint("AK_KledingAfbeeldingenen_KledingAfbeelding", x => x.KledingAfbeelding);
                    table.ForeignKey(
                        name: "FK_KledingAfbeeldingenen_Kleding_Artikelnummer",
                        column: x => x.Artikelnummer,
                        principalTable: "Kleding",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KledingAfspraak",
                columns: table => new
                {
                    Artikelnummer = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KledingAfspraak", x => new { x.Artikelnummer, x.Id });
                    table.ForeignKey(
                        name: "FK_KledingAfspraak_Kleding_Artikelnummer",
                        column: x => x.Artikelnummer,
                        principalTable: "Kleding",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KledingAfspraak_Afspraak_Id",
                        column: x => x.Id,
                        principalTable: "Afspraak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KledingKleurenen",
                columns: table => new
                {
                    Artikelnummer = table.Column<int>(nullable: false),
                    KledingKleur = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KledingKleurenen", x => x.Artikelnummer);
                    table.UniqueConstraint("AK_KledingKleurenen_KledingKleur", x => x.KledingKleur);
                    table.ForeignKey(
                        name: "FK_KledingKleurenen_Kleding_Artikelnummer",
                        column: x => x.Artikelnummer,
                        principalTable: "Kleding",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KledingAccessoire_AccessoireId",
                table: "KledingAccessoire",
                column: "AccessoireId");

            migrationBuilder.CreateIndex(
                name: "IX_KledingAfspraak_Id",
                table: "KledingAfspraak",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoireAfbeeldingenen");

            migrationBuilder.DropTable(
                name: "KledingAccessoire");

            migrationBuilder.DropTable(
                name: "KledingAfbeeldingenen");

            migrationBuilder.DropTable(
                name: "KledingAfspraak");

            migrationBuilder.DropTable(
                name: "KledingKleurenen");

            migrationBuilder.DropTable(
                name: "Accessoire");

            migrationBuilder.DropTable(
                name: "Afspraak");

            migrationBuilder.DropTable(
                name: "Kleding");
        }
    }
}
