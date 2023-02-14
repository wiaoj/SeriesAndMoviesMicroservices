using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class asdasyt932ırghbs15124124 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password_Salt",
                schema: "identity",
                table: "Users",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "Password_Hash",
                schema: "identity",
                table: "Users",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                schema: "identity",
                table: "Users",
                newName: "Password_Salt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                schema: "identity",
                table: "Users",
                newName: "Password_Hash");
        }
    }
}
