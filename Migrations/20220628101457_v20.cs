using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "x",
                table: "Sto");

            migrationBuilder.DropColumn(
                name: "y",
                table: "Sto");

            migrationBuilder.DropColumn(
                name: "m",
                table: "Kafic");

            migrationBuilder.RenameColumn(
                name: "n",
                table: "Kafic",
                newName: "BrojStolova");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrojStolova",
                table: "Kafic",
                newName: "n");

            migrationBuilder.AddColumn<float>(
                name: "x",
                table: "Sto",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "y",
                table: "Sto",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "m",
                table: "Kafic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
