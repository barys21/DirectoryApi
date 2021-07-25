using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectoryApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectoryAPLs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryAPLs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectoryOnes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryOnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectoryTwos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryTwos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectoryAplCommandPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DirectoryAplId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryAplCommandPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectoryAplCommandPlayers_DirectoryAPLs_DirectoryAplId",
                        column: x => x.DirectoryAplId,
                        principalTable: "DirectoryAPLs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryAplCommandPlayers_DirectoryAplId",
                table: "DirectoryAplCommandPlayers",
                column: "DirectoryAplId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectoryAplCommandPlayers");

            migrationBuilder.DropTable(
                name: "DirectoryOnes");

            migrationBuilder.DropTable(
                name: "DirectoryTwos");

            migrationBuilder.DropTable(
                name: "DirectoryAPLs");
        }
    }
}
