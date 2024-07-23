using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slike",
                table: "Kafic");

            migrationBuilder.CreateTable(
                name: "KaficSlike",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: false),
                    KaficID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KaficSlike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KaficSlike_Kafic_KaficID",
                        column: x => x.KaficID,
                        principalTable: "Kafic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KaficSlike_KaficID",
                table: "KaficSlike",
                column: "KaficID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KaficSlike");

            migrationBuilder.AddColumn<string>(
                name: "Slike",
                table: "Kafic",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
