using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_coreapi.Migrations
{
    public partial class NewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Pies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Pies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PositionGeo",
                table: "Pies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhone",
                table: "Pies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "PositionGeo",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "UserPhone",
                table: "Pies");
        }
    }
}
