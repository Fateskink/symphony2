using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace symphony2.Database.Migrations
{
    public partial class CreateCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                MySqlValueGenerationStrategy.IdentityColumn
                            ),
                        CourseName = table.Column<string>(nullable: false),
                        Major = table.Column<string>(nullable: true),
                        Description = table.Column<string>(nullable: true),
                        CreatedAt = table
                            .Column<DateTime>(nullable: false)
                            .Annotation("MySql:ValueGenerationStrategy", "CURRENT_TIMESTAMP"),
                        UpdatedAt = table
                            .Column<DateTime>(nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"
                            ),
                        DeletedAt = table.Column<DateTime>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {}
    }
}
