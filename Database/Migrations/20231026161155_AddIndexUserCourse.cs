using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace symphony2.Database.Migrations
{
    public partial class AddIndexUserCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserId_CourseId",
                table: "UserCourse",
                columns: new[] { "UserId", "CourseId" },
                unique: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
