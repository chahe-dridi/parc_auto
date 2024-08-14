using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace parc_auto_v1.Migrations
{
    /// <inheritdoc />
    public partial class update_attruibtes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0087cca3-27c8-4a15-ba0b-3b14fb3aa040", null, "agent", "agent" },
                    { "470c9b05-a498-4000-9566-9852dcb11957", null, "admin", "admin" },
                    { "4ebcd55e-bb05-4b7f-a4cf-6e726e6b3372", null, "utilisateur", "utilisateur" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0087cca3-27c8-4a15-ba0b-3b14fb3aa040");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "470c9b05-a498-4000-9566-9852dcb11957");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ebcd55e-bb05-4b7f-a4cf-6e726e6b3372");

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
    }
}
