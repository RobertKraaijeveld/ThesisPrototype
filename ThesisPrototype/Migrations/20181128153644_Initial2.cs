using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisPrototype.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4c045321-415f-4e46-9e6f-34dad1f9befb", "18892a78-aa43-4208-85f3-107b8c8e07fa" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7085d8a8-ff70-4493-82c5-a5800a1a9b30", "ee349060-d501-4cc0-9994-bc7ad6994a57" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c86c97ed-a729-4fe0-92ed-59172777e394", "e3409cf9-ed75-4a7a-ab3e-43de1824334e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "c86c97ed-a729-4fe0-92ed-59172777e394", 0, "e3409cf9-ed75-4a7a-ab3e-43de1824334e", null, false, "Ott", "Judd", false, null, null, null, null, null, false, null, false, 1L, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "4c045321-415f-4e46-9e6f-34dad1f9befb", 0, "18892a78-aa43-4208-85f3-107b8c8e07fa", null, false, "Fabian", "von Auerswald", false, null, null, null, null, null, false, null, false, 2L, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "7085d8a8-ff70-4493-82c5-a5800a1a9b30", 0, "ee349060-d501-4cc0-9994-bc7ad6994a57", null, false, "Hans", "Talhoffer", false, null, null, null, null, null, false, null, false, 3L, null });
        }
    }
}
