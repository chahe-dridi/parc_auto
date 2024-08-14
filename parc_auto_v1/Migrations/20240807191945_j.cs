using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace parc_auto_v1.Migrations
{
    /// <inheritdoc />
    public partial class j : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Kilometrage",
                table: "Demandes",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "406f9a41-1c7c-4400-ac74-e532a32f7e47", null, "admin", "admin" },
                    { "a66949c4-ee87-42dd-b22e-d0f597b3df30", null, "utilisateur", "utilisateur" },
                    { "b945b991-2acd-4b96-b013-7b5701b7eba1", null, "agent", "agent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "406f9a41-1c7c-4400-ac74-e532a32f7e47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a66949c4-ee87-42dd-b22e-d0f597b3df30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b945b991-2acd-4b96-b013-7b5701b7eba1");

            migrationBuilder.DropColumn(
                name: "Kilometrage",
                table: "Demandes");

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
    }
}
