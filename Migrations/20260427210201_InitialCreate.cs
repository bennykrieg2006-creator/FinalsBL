using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalsBL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HobbyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HobbyName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    HoursPerWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillLevel = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    IsIndoor = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    CollegeProgram = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    YearInProgram = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    FavoriteMajorCourse = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    FavoriteElectiveCourse = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyItems");

            migrationBuilder.DropTable(
                name: "StudentProfiles");
        }
    }
}
