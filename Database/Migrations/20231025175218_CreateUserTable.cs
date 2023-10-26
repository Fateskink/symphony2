using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pomelo.EntityFrameworkCore.MySql.Metadata;

#nullable disable

namespace symphony2.Database.Migrations
{
    public partial class CreateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                MySqlValueGenerationStrategy.IdentityColumn
                            ),
                        FirstName = table.Column<string>(nullable: true),
                        LastName = table.Column<string>(nullable: true),
                        Number = table
                            .Column<string>(nullable: true)
                            .Annotation("MySql:ValueGenerationStrategy", "UNIQUE"),
                        Birthday = table.Column<DateTime>(nullable: true),
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
                    table.PrimaryKey("PK_User", x => x.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
