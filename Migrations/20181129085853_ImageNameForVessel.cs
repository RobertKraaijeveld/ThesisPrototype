using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisPrototype.Migrations
{
    public partial class ImageNameForVessel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Vessels",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "VesselId",
                keyValue: 1L,
                column: "ImageName",
                value: "ship1.jpg");

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "VesselId",
                keyValue: 2L,
                column: "ImageName",
                value: "ship2.jpg");

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "VesselId",
                keyValue: 3L,
                column: "ImageName",
                value: "ship3.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Vessels");
        }
    }
}
