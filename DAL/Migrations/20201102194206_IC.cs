using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class IC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WoodId = table.Column<int>(nullable: false),
                    MonkeyId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonkeyLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonkeyId = table.Column<int>(nullable: false),
                    MonkeyName = table.Column<string>(nullable: true),
                    WoodId = table.Column<int>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false),
                    TreeId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonkeyLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WoodId = table.Column<int>(nullable: false),
                    TreeId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropTable(
                name: "MonkeyLogs");

            migrationBuilder.DropTable(
                name: "TreeLogs");
        }
    }
}
