﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_proje.Models;

#nullable disable

namespace web_proje.Migrations
{
    [DbContext(typeof(HastaneContext))]
    [Migration("20231219190919_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("web_proje.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorId"));

                    b.Property<string>("AnaBilimDali")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PolikinlikId")
                        .HasColumnType("int");

                    b.HasKey("DoktorId");

                    b.HasIndex("PolikinlikId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("web_proje.Models.Hastane", b =>
                {
                    b.Property<int>("HastaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HastaneId"));

                    b.Property<string>("HastaneAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HastaneId");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("web_proje.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciId"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciSifre")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("KullaniciSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("web_proje.Models.Polikinlik", b =>
                {
                    b.Property<int>("PolikinlikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolikinlikId"));

                    b.Property<int>("HastaneId")
                        .HasColumnType("int");

                    b.HasKey("PolikinlikId");

                    b.HasIndex("HastaneId");

                    b.ToTable("Polikinlikler");
                });

            modelBuilder.Entity("web_proje.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuId"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RandevuTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("RandevuId");

                    b.HasIndex("DoktorId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("web_proje.Models.Doktor", b =>
                {
                    b.HasOne("web_proje.Models.Polikinlik", "Polikinlik")
                        .WithMany("Doktorlar")
                        .HasForeignKey("PolikinlikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Polikinlik");
                });

            modelBuilder.Entity("web_proje.Models.Polikinlik", b =>
                {
                    b.HasOne("web_proje.Models.Hastane", "Hastane")
                        .WithMany("Polikinlikler")
                        .HasForeignKey("HastaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("web_proje.Models.Randevu", b =>
                {
                    b.HasOne("web_proje.Models.Doktor", "Doktor")
                        .WithMany("Randevular")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_proje.Models.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("web_proje.Models.Doktor", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("web_proje.Models.Hastane", b =>
                {
                    b.Navigation("Polikinlikler");
                });

            modelBuilder.Entity("web_proje.Models.Polikinlik", b =>
                {
                    b.Navigation("Doktorlar");
                });
#pragma warning restore 612, 618
        }
    }
}
