using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "TEXT", nullable: true),
                    GitHubUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Email", "Comments", "CreatedAt", "CreatedBy", "FirstName", "GitHubUrl", "LastModified", "LastModifiedBy", "LastName", "LinkedInUrl" },
                values: new object[,]
                {
                    { "jane.doe@example.com", "Another comment", new DateTime(2024, 5, 24, 0, 17, 21, 620, DateTimeKind.Utc).AddTicks(1329), "admin", "Jane", "https://github.com/janedoe", new DateTime(2024, 5, 24, 0, 17, 21, 620, DateTimeKind.Utc).AddTicks(1331), "admin", "Doe", "https://www.linkedin.com/in/janedoe" },
                    { "john.doe@example.com", "Sample comment", new DateTime(2024, 5, 24, 0, 17, 21, 618, DateTimeKind.Utc).AddTicks(6275), "admin", "John", "https://github.com/johndoe", new DateTime(2024, 5, 24, 0, 17, 21, 618, DateTimeKind.Utc).AddTicks(6280), "admin", "Doe", "https://www.linkedin.com/in/johndoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
