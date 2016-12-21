using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneymoonShop.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessoire",
                columns: table => new
                {
                    AccessoireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessoireCode = table.Column<int>(nullable: false),
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
                    AfspraakId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Afspraak", x => x.AfspraakId);
                });

            migrationBuilder.CreateTable(
                name: "Jurken",
                columns: table => new
                {
                    JurkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artikelnummer = table.Column<int>(nullable: false),
                    Materiaal = table.Column<string>(nullable: true),
                    MaxPrijs = table.Column<int>(nullable: false),
                    Merk = table.Column<string>(nullable: true),
                    MinPrijs = table.Column<int>(nullable: false),
                    Neklijn = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true),
                    Silhouette = table.Column<string>(nullable: true),
                    Stijl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurken", x => x.JurkId);
                });

            migrationBuilder.CreateTable(
                name: "Kleuren",
                columns: table => new
                {
                    KleurId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artikelnummer = table.Column<string>(nullable: true),
                    Hexacode = table.Column<string>(nullable: true),
                    KleurNaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kleuren", x => x.KleurId);
                });

            migrationBuilder.CreateTable(
                name: "Pakken",
                columns: table => new
                {
                    PakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artikelnummer = table.Column<int>(nullable: false),
                    MaxPrijs = table.Column<int>(nullable: false),
                    Merk = table.Column<string>(nullable: true),
                    MinPrijs = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pakken", x => x.PakId);
                });

            migrationBuilder.CreateTable(
                name: "JurkAccessoire",
                columns: table => new
                {
                    JurkId = table.Column<int>(nullable: false),
                    AccessoireId = table.Column<int>(nullable: false),
                    AccessoireId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurkAccessoire", x => new { x.JurkId, x.AccessoireId });
                    table.ForeignKey(
                        name: "FK_JurkAccessoire_Afspraak_AccessoireId",
                        column: x => x.AccessoireId,
                        principalTable: "Afspraak",
                        principalColumn: "AfspraakId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JurkAccessoire_Accessoire_AccessoireId1",
                        column: x => x.AccessoireId1,
                        principalTable: "Accessoire",
                        principalColumn: "AccessoireId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JurkAccessoire_Jurken_JurkId",
                        column: x => x.JurkId,
                        principalTable: "Jurken",
                        principalColumn: "JurkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JurkAfspraak",
                columns: table => new
                {
                    JurkId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurkAfspraak", x => new { x.JurkId, x.Id });
                    table.ForeignKey(
                        name: "FK_JurkAfspraak_Afspraak_Id",
                        column: x => x.Id,
                        principalTable: "Afspraak",
                        principalColumn: "AfspraakId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JurkAfspraak_Jurken_JurkId",
                        column: x => x.JurkId,
                        principalTable: "Jurken",
                        principalColumn: "JurkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JurkKleur",
                columns: table => new
                {
                    JurkId = table.Column<int>(nullable: false),
                    KleurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurkKleur", x => new { x.JurkId, x.KleurId });
                    table.ForeignKey(
                        name: "FK_JurkKleur_Jurken_JurkId",
                        column: x => x.JurkId,
                        principalTable: "Jurken",
                        principalColumn: "JurkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JurkKleur_Kleuren_KleurId",
                        column: x => x.KleurId,
                        principalTable: "Kleuren",
                        principalColumn: "KleurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Afbeeldingen",
                columns: table => new
                {
                    AfbeeldingId = table.Column<string>(nullable: false),
                    AccessoireId = table.Column<int>(nullable: true),
                    Artikelnummer = table.Column<string>(nullable: true),
                    JurkId = table.Column<int>(nullable: true),
                    PakId = table.Column<int>(nullable: true),
                    SourcePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afbeeldingen", x => x.AfbeeldingId);
                    table.ForeignKey(
                        name: "FK_Afbeeldingen_Accessoire_AccessoireId",
                        column: x => x.AccessoireId,
                        principalTable: "Accessoire",
                        principalColumn: "AccessoireId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afbeeldingen_Jurken_JurkId",
                        column: x => x.JurkId,
                        principalTable: "Jurken",
                        principalColumn: "JurkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afbeeldingen_Pakken_PakId",
                        column: x => x.PakId,
                        principalTable: "Pakken",
                        principalColumn: "PakId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PakAccessoire",
                columns: table => new
                {
                    PakId = table.Column<int>(nullable: false),
                    AccessoireId = table.Column<int>(nullable: false),
                    AccessoireId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PakAccessoire", x => new { x.PakId, x.AccessoireId });
                    table.ForeignKey(
                        name: "FK_PakAccessoire_Afspraak_AccessoireId",
                        column: x => x.AccessoireId,
                        principalTable: "Afspraak",
                        principalColumn: "AfspraakId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PakAccessoire_Accessoire_AccessoireId1",
                        column: x => x.AccessoireId1,
                        principalTable: "Accessoire",
                        principalColumn: "AccessoireId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PakAccessoire_Pakken_PakId",
                        column: x => x.PakId,
                        principalTable: "Pakken",
                        principalColumn: "PakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PakAfspraak",
                columns: table => new
                {
                    PakId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PakAfspraak", x => new { x.PakId, x.Id });
                    table.ForeignKey(
                        name: "FK_PakAfspraak_Afspraak_Id",
                        column: x => x.Id,
                        principalTable: "Afspraak",
                        principalColumn: "AfspraakId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PakAfspraak_Pakken_PakId",
                        column: x => x.PakId,
                        principalTable: "Pakken",
                        principalColumn: "PakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PakKleur",
                columns: table => new
                {
                    PakId = table.Column<int>(nullable: false),
                    KleurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PakKleur", x => new { x.PakId, x.KleurId });
                    table.ForeignKey(
                        name: "FK_PakKleur_Kleuren_KleurId",
                        column: x => x.KleurId,
                        principalTable: "Kleuren",
                        principalColumn: "KleurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PakKleur_Pakken_PakId",
                        column: x => x.PakId,
                        principalTable: "Pakken",
                        principalColumn: "PakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afbeeldingen_AccessoireId",
                table: "Afbeeldingen",
                column: "AccessoireId");

            migrationBuilder.CreateIndex(
                name: "IX_Afbeeldingen_JurkId",
                table: "Afbeeldingen",
                column: "JurkId");

            migrationBuilder.CreateIndex(
                name: "IX_Afbeeldingen_PakId",
                table: "Afbeeldingen",
                column: "PakId");

            migrationBuilder.CreateIndex(
                name: "IX_JurkAccessoire_AccessoireId",
                table: "JurkAccessoire",
                column: "AccessoireId");

            migrationBuilder.CreateIndex(
                name: "IX_JurkAccessoire_AccessoireId1",
                table: "JurkAccessoire",
                column: "AccessoireId1");

            migrationBuilder.CreateIndex(
                name: "IX_JurkAfspraak_Id",
                table: "JurkAfspraak",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JurkKleur_KleurId",
                table: "JurkKleur",
                column: "KleurId");

            migrationBuilder.CreateIndex(
                name: "IX_PakAccessoire_AccessoireId",
                table: "PakAccessoire",
                column: "AccessoireId");

            migrationBuilder.CreateIndex(
                name: "IX_PakAccessoire_AccessoireId1",
                table: "PakAccessoire",
                column: "AccessoireId1");

            migrationBuilder.CreateIndex(
                name: "IX_PakAfspraak_Id",
                table: "PakAfspraak",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PakKleur_KleurId",
                table: "PakKleur",
                column: "KleurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afbeeldingen");

            migrationBuilder.DropTable(
                name: "JurkAccessoire");

            migrationBuilder.DropTable(
                name: "JurkAfspraak");

            migrationBuilder.DropTable(
                name: "JurkKleur");

            migrationBuilder.DropTable(
                name: "PakAccessoire");

            migrationBuilder.DropTable(
                name: "PakAfspraak");

            migrationBuilder.DropTable(
                name: "PakKleur");

            migrationBuilder.DropTable(
                name: "Jurken");

            migrationBuilder.DropTable(
                name: "Accessoire");

            migrationBuilder.DropTable(
                name: "Afspraak");

            migrationBuilder.DropTable(
                name: "Kleuren");

            migrationBuilder.DropTable(
                name: "Pakken");
        }
    }
}
