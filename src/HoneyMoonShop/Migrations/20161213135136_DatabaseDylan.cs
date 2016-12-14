using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneymoonShop.Migrations
{
    public partial class DatabaseDylan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "KledingDbSet",
                columns: table => new
                {
                    Artikelnummer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Merk = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true),
                    Prijs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KledingDbSet", x => x.Artikelnummer);
                });

            migrationBuilder.CreateTable(
                name: "JurkDbSet",
                columns: table => new
                {
                    ArtikelnummerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artikelnummer = table.Column<int>(nullable: true),
                    Materiaal = table.Column<string>(nullable: true),
                    Neklijn = table.Column<string>(nullable: true),
                    Silhouette = table.Column<string>(nullable: true),
                    Stijl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurkDbSet", x => x.ArtikelnummerId);
                    table.ForeignKey(
                        name: "FK_JurkDbSet_KledingDbSet_Artikelnummer",
                        column: x => x.Artikelnummer,
                        principalTable: "KledingDbSet",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JurkDbSet_Artikelnummer",
                table: "JurkDbSet",
                column: "Artikelnummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JurkDbSet");

            migrationBuilder.DropTable(
                name: "KledingDbSet");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phonenumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Example1 = table.Column<int>(nullable: false),
                    Example2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                });
        }
    }
}
