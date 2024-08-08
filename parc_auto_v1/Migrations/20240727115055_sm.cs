using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace parc_auto_v1.Migrations
{
    /// <inheritdoc />
    public partial class sm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d3b5fd3-a478-44a3-b14c-830d3cc862be", null, "admin", "admin" },
                    { "3e80db8d-8c58-48e8-9e60-2ba9f44dde4d", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3b5fd3-a478-44a3-b14c-830d3cc862be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e80db8d-8c58-48e8-9e60-2ba9f44dde4d");
        }
    }
}
