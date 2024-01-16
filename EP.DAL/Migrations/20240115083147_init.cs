using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EP.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationPrice = table.Column<double>(type: "float", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "EducationUsers",
                columns: table => new
                {
                    EducationUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    PersonCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationUserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationUsers", x => x.EducationUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "EducationUsers");
        }
    }
}
