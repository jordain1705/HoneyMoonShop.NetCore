using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HoneymoonShop.Models;

namespace HoneymoonShop.Migrations
{
    [DbContext(typeof(HoneyMoonShopContext))]
    [Migration("20161220230204_database")]
    partial class database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoneymoonShop.Models.Accessoire", b =>
                {
                    b.Property<int>("AccessoireId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessoireCode");

                    b.Property<string>("Categorie");

                    b.Property<string>("Geslacht");

                    b.Property<string>("LinkNaarWebshop");

                    b.Property<string>("Merk");

                    b.HasKey("AccessoireId");

                    b.ToTable("Accessoire");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Afbeelding", b =>
                {
                    b.Property<string>("AfbeeldingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccessoireId");

                    b.Property<string>("Artikelnummer");

                    b.Property<int?>("JurkId");

                    b.Property<int?>("PakId");

                    b.Property<string>("SourcePath");

                    b.HasKey("AfbeeldingId");

                    b.HasIndex("AccessoireId");

                    b.HasIndex("JurkId");

                    b.HasIndex("PakId");

                    b.ToTable("Afbeeldingen");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Afspraak", b =>
                {
                    b.Property<int>("AfspraakId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Achternaam");

                    b.Property<DateTime>("DatumTijd");

                    b.Property<string>("EmailAdres");

                    b.Property<string>("SoortAfspraak");

                    b.Property<int>("TelefoonNummer");

                    b.Property<DateTime>("Trouwdatum");

                    b.Property<string>("Voornaam");

                    b.HasKey("AfspraakId");

                    b.ToTable("Afspraak");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Jurk", b =>
                {
                    b.Property<int>("JurkId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Artikelnummer");

                    b.Property<string>("Materiaal");

                    b.Property<int>("MaxPrijs");

                    b.Property<string>("Merk");

                    b.Property<int>("MinPrijs");

                    b.Property<string>("Neklijn");

                    b.Property<string>("Omschrijving");

                    b.Property<string>("Silhouette");

                    b.Property<string>("Stijl");

                    b.HasKey("JurkId");

                    b.ToTable("Jurken");
                });

            modelBuilder.Entity("HoneymoonShop.Models.JurkAccessoire", b =>
                {
                    b.Property<int>("JurkId");

                    b.Property<int>("AccessoireId");

                    b.Property<int?>("AccessoireId1");

                    b.HasKey("JurkId", "AccessoireId");

                    b.HasIndex("AccessoireId");

                    b.HasIndex("AccessoireId1");

                    b.ToTable("JurkAccessoire");
                });

            modelBuilder.Entity("HoneymoonShop.Models.JurkAfspraak", b =>
                {
                    b.Property<int>("JurkId");

                    b.Property<int>("Id");

                    b.HasKey("JurkId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("JurkAfspraak");
                });

            modelBuilder.Entity("HoneymoonShop.Models.JurkKleur", b =>
                {
                    b.Property<int>("JurkId");

                    b.Property<int>("KleurId");

                    b.HasKey("JurkId", "KleurId");

                    b.HasIndex("KleurId");

                    b.ToTable("JurkKleur");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Kleur", b =>
                {
                    b.Property<int>("KleurId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artikelnummer");

                    b.Property<string>("Hexacode");

                    b.Property<string>("KleurNaam");

                    b.HasKey("KleurId");

                    b.ToTable("Kleuren");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Pak", b =>
                {
                    b.Property<int>("PakId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Artikelnummer");

                    b.Property<int>("MaxPrijs");

                    b.Property<string>("Merk");

                    b.Property<int>("MinPrijs");

                    b.Property<string>("Model");

                    b.Property<string>("Omschrijving");

                    b.HasKey("PakId");

                    b.ToTable("Pakken");
                });

            modelBuilder.Entity("HoneymoonShop.Models.PakAccessoire", b =>
                {
                    b.Property<int>("PakId");

                    b.Property<int>("AccessoireId");

                    b.Property<int?>("AccessoireId1");

                    b.HasKey("PakId", "AccessoireId");

                    b.HasIndex("AccessoireId");

                    b.HasIndex("AccessoireId1");

                    b.ToTable("PakAccessoire");
                });

            modelBuilder.Entity("HoneymoonShop.Models.PakAfspraak", b =>
                {
                    b.Property<int>("PakId");

                    b.Property<int>("Id");

                    b.HasKey("PakId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("PakAfspraak");
                });

            modelBuilder.Entity("HoneymoonShop.Models.PakKleur", b =>
                {
                    b.Property<int>("PakId");

                    b.Property<int>("KleurId");

                    b.HasKey("PakId", "KleurId");

                    b.HasIndex("KleurId");

                    b.ToTable("PakKleur");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Afbeelding", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Accessoire", "Accessoire")
                        .WithMany("Afbeeldingen")
                        .HasForeignKey("AccessoireId");

                    b.HasOne("HoneymoonShop.Models.Jurk", "Jurk")
                        .WithMany("Afbeeldingen")
                        .HasForeignKey("JurkId");

                    b.HasOne("HoneymoonShop.Models.Pak", "Pak")
                        .WithMany("Afbeeldingen")
                        .HasForeignKey("PakId");
                });

            modelBuilder.Entity("HoneymoonShop.Models.JurkAccessoire", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Afspraak", "Accessoire")
                        .WithMany("JurkAccessoires")
                        .HasForeignKey("AccessoireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Accessoire")
                        .WithMany("JurkAccessoires")
                        .HasForeignKey("AccessoireId1");

                    b.HasOne("HoneymoonShop.Models.Jurk", "Jurk")
                        .WithMany("JurkAccessoires")
                        .HasForeignKey("JurkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.JurkAfspraak", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Afspraak", "Afspraak")
                        .WithMany("JurkAfspraken")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Jurk", "Jurk")
                        .WithMany("JurkAfspraken")
                        .HasForeignKey("JurkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.JurkKleur", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Jurk", "Jurk")
                        .WithMany("JurkKleuren")
                        .HasForeignKey("JurkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Kleur", "Kleur")
                        .WithMany("JurkKleuren")
                        .HasForeignKey("KleurId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.PakAccessoire", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Afspraak", "Accessoire")
                        .WithMany("PakAccessoires")
                        .HasForeignKey("AccessoireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Accessoire")
                        .WithMany("PakAccessoires")
                        .HasForeignKey("AccessoireId1");

                    b.HasOne("HoneymoonShop.Models.Pak", "Pak")
                        .WithMany("PakAccessoires")
                        .HasForeignKey("PakId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.PakAfspraak", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Afspraak", "Afspraak")
                        .WithMany("PakAfspraken")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Pak", "Pak")
                        .WithMany("PakAfspraken")
                        .HasForeignKey("PakId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.PakKleur", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Kleur", "Kleur")
                        .WithMany("PakKleuren")
                        .HasForeignKey("KleurId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.Pak", "Pak")
                        .WithMany("PakKleuren")
                        .HasForeignKey("PakId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
