using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisPrototype.Migrations
{
    public partial class AddedImportMeta_And_KpiType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KpiType",
                table: "Kpis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DataImportMetas",
                columns: table => new
                {
                    DataImportMetaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShipId = table.Column<long>(nullable: false),
                    ImportDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataImportMetas", x => x.DataImportMetaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataImportMetas");

            migrationBuilder.DropColumn(
                name: "KpiType",
                table: "Kpis");
        }
    }
}
