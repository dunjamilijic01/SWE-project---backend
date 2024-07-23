﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Back.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Ime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Prezime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("Models.Dogadjaj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("KaficID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.Property<string>("Opis")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4");

                    b.Property<string>("Vreme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("VrstaDogadjaja")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("KaficID");

                    b.ToTable("Dogadjaj");
                });

            modelBuilder.Entity("Models.Kafic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrojMesta")
                        .HasMaxLength(500)
                        .HasColumnType("int");

                    b.Property<int>("BrojStolova")
                        .HasColumnType("int");

                    b.Property<string>("BrojTelefona")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4");

                    b.Property<string>("Facebook")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("Instagram")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4");

                    b.Property<string>("Lokacija")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("RadnoVreme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<bool>("VrseRezervacije")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("srednjaOcena")
                        .HasColumnType("double");

                    b.HasKey("ID");

                    b.ToTable("Kafic");
                });

            modelBuilder.Entity("Models.KaficSlike", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("KaficID")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("KaficID");

                    b.ToTable("KaficSlike");
                });

            modelBuilder.Entity("Models.Komentar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("KaficID")
                        .HasColumnType("int");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<int>("PosetilacId")
                        .HasColumnType("int");

                    b.Property<string>("TextKomentara")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("KaficID");

                    b.HasIndex("PosetilacId");

                    b.ToTable("Komentar");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("KaficID")
                        .HasColumnType("int");

                    b.Property<bool>("Obradjen")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PosetilacId")
                        .HasColumnType("int");

                    b.Property<int?>("StoFK")
                        .HasColumnType("int");

                    b.Property<string>("VremeIsteka")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4");

                    b.Property<string>("ZakazanoVreme")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("KaficID");

                    b.HasIndex("PosetilacId");

                    b.HasIndex("StoFK");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("Models.Sto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrojLjudi")
                        .HasColumnType("int");

                    b.Property<int?>("KaficID")
                        .HasColumnType("int");

                    b.Property<bool>("Slobodan")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Zauzet")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("display")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ID");

                    b.HasIndex("KaficID");

                    b.ToTable("Sto");
                });

            modelBuilder.Entity("Models.Posetilac", b =>
                {
                    b.HasBaseType("Models.AppUser");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime(6)");

                    b.HasDiscriminator().HasValue("Posetilac");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.HasBaseType("Models.AppUser");

                    b.Property<int>("KaficId")
                        .HasColumnType("int");

                    b.Property<string>("Pozicija")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4");

                    b.Property<bool>("Vlasnik")
                        .HasColumnType("tinyint(1)");

                    b.HasIndex("KaficId");

                    b.HasDiscriminator().HasValue("Radnik");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Dogadjaj", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("Dogadjaji")
                        .HasForeignKey("KaficID");

                    b.Navigation("Kafic");
                });

            modelBuilder.Entity("Models.KaficSlike", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("slike")
                        .HasForeignKey("KaficID");

                    b.Navigation("Kafic");
                });

            modelBuilder.Entity("Models.Komentar", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("Komentari")
                        .HasForeignKey("KaficID");

                    b.HasOne("Models.Posetilac", "Posetilac")
                        .WithMany("Komentari")
                        .HasForeignKey("PosetilacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kafic");

                    b.Navigation("Posetilac");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KaficID");

                    b.HasOne("Models.Posetilac", "Posetilac")
                        .WithMany("Rezervacije")
                        .HasForeignKey("PosetilacId");

                    b.HasOne("Models.Sto", "Sto")
                        .WithMany("Rezervacija")
                        .HasForeignKey("StoFK");

                    b.Navigation("Kafic");

                    b.Navigation("Posetilac");

                    b.Navigation("Sto");
                });

            modelBuilder.Entity("Models.Sto", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("Stolovi")
                        .HasForeignKey("KaficID");

                    b.Navigation("Kafic");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("Radnici")
                        .HasForeignKey("KaficId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kafic");
                });

            modelBuilder.Entity("Models.Kafic", b =>
                {
                    b.Navigation("Dogadjaji");

                    b.Navigation("Komentari");

                    b.Navigation("Radnici");

                    b.Navigation("Rezervacije");

                    b.Navigation("slike");

                    b.Navigation("Stolovi");
                });

            modelBuilder.Entity("Models.Sto", b =>
                {
                    b.Navigation("Rezervacija");
                });

            modelBuilder.Entity("Models.Posetilac", b =>
                {
                    b.Navigation("Komentari");

                    b.Navigation("Rezervacije");
                });
#pragma warning restore 612, 618
        }
    }
}
