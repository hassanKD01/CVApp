using Microsoft.EntityFrameworkCore.Migrations;

namespace CVApp.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "Passwrod",
                table: "CVs",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "CVs",
                newName: "BirthDate");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "CVs",
                newName: "Passwrod");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "CVs",
                newName: "Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                columns: new[] { "Language", "CVId" });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => new { x.nationality, x.CVId });
                    table.ForeignKey(
                        name: "FK_Nationalities_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_CVId",
                table: "Nationalities",
                column: "CVId");
        }
    }
}
