using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class IC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForestId",
                table: "ActionLogs");

            migrationBuilder.AddColumn<int>(
                name: "WoodId",
                table: "ActionLogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WoodId",
                table: "ActionLogs");

            migrationBuilder.AddColumn<int>(
                name: "ForestId",
                table: "ActionLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
