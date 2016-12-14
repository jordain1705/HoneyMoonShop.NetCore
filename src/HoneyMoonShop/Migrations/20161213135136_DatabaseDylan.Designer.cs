using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HoneymoonShop.Models;

namespace HoneymoonShop.Migrations
{
    [DbContext(typeof(HoneyMoonShopContext))]
    [Migration("20161213135136_DatabaseDylan")]
    partial class DatabaseDylan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoneymoonShop.Models.Jurk", b =>
                {
                    b.Property<int>("ArtikelnummerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Artikelnummer");

                    b.Property<string>("Materiaal");

                    b.Property<string>("Neklijn");

                    b.Property<string>("Silhouette");

                    b.Property<string>("Stijl");

                    b.HasKey("ArtikelnummerId");

                    b.HasIndex("Artikelnummer");

                    b.ToTable("JurkDbSet");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Kleding", b =>
                {
                    b.Property<int>("Artikelnummer")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Merk");

                    b.Property<string>("Omschrijving");

                    b.Property<int>("Prijs");

                    b.HasKey("Artikelnummer");

                    b.ToTable("KledingDbSet");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Jurk", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Kleding", "Kleding")
                        .WithMany("Jurken")
                        .HasForeignKey("Artikelnummer");
                });
        }
    }
}
