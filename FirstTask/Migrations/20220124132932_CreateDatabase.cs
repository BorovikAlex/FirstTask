using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstTask.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Programmer",
                columns: table => new
                {
                    ProgrammerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmer", x => x.ProgrammerID);
                    table.ForeignKey(
                        name: "FK_Programmer_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programmer_PositionID",
                table: "Programmer",
                column: "PositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programmer");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
