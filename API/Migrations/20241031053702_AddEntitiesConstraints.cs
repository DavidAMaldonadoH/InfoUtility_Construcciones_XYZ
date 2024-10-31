using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitiesConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Project_State",
                schema: "construcciones_xyz",
                table: "Project",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Type",
                schema: "construcciones_xyz",
                table: "Project",
                column: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectState",
                schema: "construcciones_xyz",
                table: "Project",
                column: "State",
                principalSchema: "construcciones_xyz",
                principalTable: "ProjectState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectType",
                schema: "construcciones_xyz",
                table: "Project",
                column: "Type",
                principalSchema: "construcciones_xyz",
                principalTable: "ProjectType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectState",
                schema: "construcciones_xyz",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectType",
                schema: "construcciones_xyz",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_State",
                schema: "construcciones_xyz",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_Type",
                schema: "construcciones_xyz",
                table: "Project");
        }
    }
}
