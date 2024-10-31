using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class CreateEngineerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineerId",
                schema: "construcciones_xyz",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Engineer",
                schema: "construcciones_xyz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_EngineerId",
                schema: "construcciones_xyz",
                table: "Project",
                column: "EngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Engineer",
                schema: "construcciones_xyz",
                table: "Project",
                column: "EngineerId",
                principalSchema: "construcciones_xyz",
                principalTable: "Engineer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Engineer",
                schema: "construcciones_xyz",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Engineer",
                schema: "construcciones_xyz");

            migrationBuilder.DropIndex(
                name: "IX_Project_EngineerId",
                schema: "construcciones_xyz",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "EngineerId",
                schema: "construcciones_xyz",
                table: "Project");
        }
    }
}
