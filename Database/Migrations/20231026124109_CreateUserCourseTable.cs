using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace symphony2.Database.Migrations
{
    public partial class CreateUserCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                MySqlValueGenerationStrategy.IdentityColumn
                            ),
                        UserId = table.Column<int>(nullable: false),
                        CourseId = table.Column<int>(nullable: false),
                        CreatedAt = table
                            .Column<DateTime>(nullable: false)
                            .Annotation("MySql:ValueGenerationStrategy", "CURRENT_TIMESTAMP"),
                        UpdatedAt = table
                            .Column<DateTime>(nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"
                            ),
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => x.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { }
    }
}
