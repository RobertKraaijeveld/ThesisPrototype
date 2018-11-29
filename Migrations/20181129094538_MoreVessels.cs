using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisPrototype.Migrations
{
    public partial class MoreVessels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vessels",
                columns: new[] { "VesselId", "CountryName", "ImageName", "ImoNumber", "Name", "UserId", "UserId1" },
                values: new object[] { 4L, "Italy", "ship4.jpg", 1111114, "Mandritto", 3L, null });

            migrationBuilder.InsertData(
                table: "Vessels",
                columns: new[] { "VesselId", "CountryName", "ImageName", "ImoNumber", "Name", "UserId", "UserId1" },
                values: new object[] { 5L, "Italy", "ship5.jpg", 1111115, "Sottani", 3L, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vessels",
                keyColumn: "VesselId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Vessels",
                keyColumn: "VesselId",
                keyValue: 5L);
        }
    }
}
