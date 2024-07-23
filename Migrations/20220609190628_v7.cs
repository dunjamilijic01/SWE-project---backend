using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Korisnik_korisnikID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentar_Korisnik_PosetilacID",
                table: "Komentar");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Korisnik_PosetilacID",
                table: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Nalog");

            migrationBuilder.RenameColumn(
                name: "PosetilacID",
                table: "Rezervacija",
                newName: "PosetilacId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_PosetilacID",
                table: "Rezervacija",
                newName: "IX_Rezervacija_PosetilacId");

            migrationBuilder.RenameColumn(
                name: "PosetilacID",
                table: "Komentar",
                newName: "PosetilacId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentar_PosetilacID",
                table: "Komentar",
                newName: "IX_Komentar_PosetilacId");

            migrationBuilder.RenameColumn(
                name: "korisnikID",
                table: "AspNetUsers",
                newName: "KaficID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_korisnikID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_KaficID");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Kafic",
                type: "varchar(50) CHARACTER SET utf8mb4",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Kafic",
                type: "varchar(30) CHARACTER SET utf8mb4",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pozicija",
                table: "AspNetUsers",
                type: "varchar(30) CHARACTER SET utf8mb4",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Vlasnik",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Kafic_KaficID",
                table: "AspNetUsers",
                column: "KaficID",
                principalTable: "Kafic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentar_AspNetUsers_PosetilacId",
                table: "Komentar",
                column: "PosetilacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_AspNetUsers_PosetilacId",
                table: "Rezervacija",
                column: "PosetilacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Kafic_KaficID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentar_AspNetUsers_PosetilacId",
                table: "Komentar");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_AspNetUsers_PosetilacId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Kafic");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Kafic");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pozicija",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Vlasnik",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PosetilacId",
                table: "Rezervacija",
                newName: "PosetilacID");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_PosetilacId",
                table: "Rezervacija",
                newName: "IX_Rezervacija_PosetilacID");

            migrationBuilder.RenameColumn(
                name: "PosetilacId",
                table: "Komentar",
                newName: "PosetilacID");

            migrationBuilder.RenameIndex(
                name: "IX_Komentar_PosetilacId",
                table: "Komentar",
                newName: "IX_Komentar_PosetilacID");

            migrationBuilder.RenameColumn(
                name: "KaficID",
                table: "AspNetUsers",
                newName: "korisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_KaficID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_korisnikID");

            migrationBuilder.CreateTable(
                name: "Nalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: false),
                    NalogFK = table.Column<int>(type: "int", nullable: true),
                    Prezime = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    KaficID = table.Column<int>(type: "int", nullable: true),
                    Pozicija = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: true),
                    Vlasnik = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Kafic_KaficID",
                        column: x => x.KaficID,
                        principalTable: "Kafic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_Nalog_NalogFK",
                        column: x => x.NalogFK,
                        principalTable: "Nalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_KaficID",
                table: "Korisnik",
                column: "KaficID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_NalogFK",
                table: "Korisnik",
                column: "NalogFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Korisnik_korisnikID",
                table: "AspNetUsers",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentar_Korisnik_PosetilacID",
                table: "Komentar",
                column: "PosetilacID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Korisnik_PosetilacID",
                table: "Rezervacija",
                column: "PosetilacID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
