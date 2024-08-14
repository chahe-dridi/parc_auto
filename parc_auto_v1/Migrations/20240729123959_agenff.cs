using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace parc_auto_v1.Migrations
{
    /// <inheritdoc />
    public partial class agenff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04e3d0e9-2fb3-400d-8ce8-0dcb44b4e081");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115b538d-f3ef-4c7d-8a34-27b946dc2ae6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaa8e2f0-57a5-4573-b920-bc8390f80c64");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ba2359d-fdea-4ab4-8674-fbd7377aaeab", null, "admin", "admin" },
                    { "9b17ad74-c3ad-457f-9f4d-6bdc4cc8da4b", null, "utilisateur", "utilisateur" },
                    { "e3bc8525-8a07-49d6-b3a7-0fbf62a4e114", null, "agent", "agent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba2359d-fdea-4ab4-8674-fbd7377aaeab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b17ad74-c3ad-457f-9f4d-6bdc4cc8da4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3bc8525-8a07-49d6-b3a7-0fbf62a4e114");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04e3d0e9-2fb3-400d-8ce8-0dcb44b4e081", null, "agent", "agent" },
                    { "115b538d-f3ef-4c7d-8a34-27b946dc2ae6", null, "admin", "admin" },
                    { "eaa8e2f0-57a5-4573-b920-bc8390f80c64", null, "utilisateur", "utilisateur" }
                });
        }
    }
}
