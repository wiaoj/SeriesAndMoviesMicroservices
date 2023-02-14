using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CategoryService.Persistence.Migrations;

/// <inheritdoc />
public partial class init : Migration {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder) {
        migrationBuilder.EnsureSchema(
            name: "category");

        migrationBuilder.CreateTable(
            name: "category",
            schema: "category",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_category", x => x.Id);
            });

        migrationBuilder.InsertData(
            schema: "category",
            table: "category",
            columns: new[] { "Id", "description", "name" },
            values: new object[,]
            {
                { new Guid("c9cd89eb-3ea9-489c-b19f-7c8b65f156bc"), "Bilim kurgu kategorisi", "Bilim Kurgu" },
                { new Guid("ecb2303c-7161-4db5-ab46-10df4b1fc409"), "Korku kategorisi", "Korku" }
            });

        migrationBuilder.CreateIndex(
            name: "IX_category_Id",
            schema: "category",
            table: "category",
            column: "Id",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder) {
        migrationBuilder.DropTable(
            name: "category",
            schema: "category");
    }
}
