using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastTask.TaskItems.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TaskItems");

            migrationBuilder.CreateTable(
                name: "TaskItems",
                schema: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(7)", precision: 7, nullable: false, defaultValueSql: "GetUtcDate()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2(7)", precision: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "TaskItems",
                table: "TaskItems",
                columns: new[] { "Id", "Description", "ItemId", "Status", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Create wireframes and technical specifications for user login, registration, and password reset functionality", new Guid("f7cb95b9-b1ed-48b8-82c2-bd2495e97d8e"), 0, "Design user authentication system", null },
                    { 2, "Develop REST API endpoints for user management and task operations", new Guid("b6781c6f-8dba-4ad9-b1f4-448d28e462b5"), 1, "Implement API endpoints", null },
                    { 3, "Configure automated testing and deployment pipeline using GitHub Actions", new Guid("157f3f13-3f09-4579-90bd-2964660f2a84"), 0, "Set up CI/CD pipeline", null },
                    { 4, "Write migration scripts to update production database schema", new Guid("69b46755-9d5a-4889-a491-b2611b11eb2c"), 2, "Database migration scripts", null },
                    { 5, "Review pull request #247 for payment processing implementation", new Guid("c9d595c4-d174-4566-af43-f2836d724f4a"), 0, "Code review for payment module", null },
                    { 6, "Revise API documentation to reflect recent endpoint changes", new Guid("a6bd6b37-4f5c-43d6-aeba-63faa69550c6"), 0, "Update documentation", null },
                    { 7, "Optimize database queries for the dashboard loading time", new Guid("f7d414ee-490e-4649-a732-d70dad1a6299"), 0, "Performance optimization", null },
                    { 8, "Conduct security review of authentication and authorization mechanisms", new Guid("cb63221d-6cf6-4aea-82b6-100fb690fb5d"), 0, "Security audit", null },
                    { 9, "Test mobile application on various devices and screen sizes", new Guid("2aaeab2e-5035-4eab-8c4a-688daa257294"), 0, "Mobile app testing", null },
                    { 10, "Prepare demo and presentation materials for upcoming client meeting", new Guid("5973cb0f-63c4-4c09-9f8b-8758dfda286a"), 0, "Client presentation preparation", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ItemId",
                schema: "TaskItems",
                table: "TaskItems",
                column: "ItemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems",
                schema: "TaskItems");
        }
    }
}
