using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisPrototype.Migrations
{
    public partial class RenamedSomeThingsAndAddedIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vessels");

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    ShipId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    ImoNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.ShipId);
                    table.ForeignKey(
                        name: "FK_Ships_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "ShipId", "CountryName", "ImageName", "ImoNumber", "Name", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1L, "Germany", "ship1.jpg", 1111111, "Waage", 1L, null },
                    { 2L, "Germany", "ship2.jpg", 1111112, "Grüblein", 2L, null },
                    { 3L, "Germany", "ship3.jpg", 1111113, "Schlauer Fuchs", 3L, null },
                    { 4L, "Italy", "ship4.jpg", 1111114, "Mandritto", 3L, null },
                    { 5L, "Italy", "ship5.jpg", 1111115, "Sottani", 3L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ships_UserId1",
                table: "Ships",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    VesselId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    ImoNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.VesselId);
                    table.ForeignKey(
                        name: "FK_Vessels_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Vessels",
                columns: new[] { "VesselId", "CountryName", "ImageName", "ImoNumber", "Name", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1L, "Germany", "ship1.jpg", 1111111, "Waage", 1L, null },
                    { 2L, "Germany", "ship2.jpg", 1111112, "Grüblein", 2L, null },
                    { 3L, "Germany", "ship3.jpg", 1111113, "Schlauer Fuchs", 3L, null },
                    { 4L, "Italy", "ship4.jpg", 1111114, "Mandritto", 3L, null },
                    { 5L, "Italy", "ship5.jpg", 1111115, "Sottani", 3L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_UserId1",
                table: "Vessels",
                column: "UserId1");
        }
    }
}
