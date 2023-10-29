using Microsoft.EntityFrameworkCore.Migrations;
using symphony2.Helpers;

#nullable disable

namespace symphony2.Database.Migrations
{
    public partial class CreateExamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.CreateCommonColumns(migrationBuilder, "Exam");

            migrationBuilder.AddColumn<string>(
                name: "Term",
                table: "Exam",
                type: "varchar(255)",
                nullable: false
            );

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Exam",
                type: "varchar(255)",
                nullable: false
            );

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Exam",
                type: "varchar(255)",
                nullable: false
            );

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Exam",
                type: "int",
                nullable: false
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exam");
        }
    }
}
