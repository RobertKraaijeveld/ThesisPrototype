using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisPrototype.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Kpis",
                columns: table => new
                {
                    KpiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KpiEnum = table.Column<int>(nullable: false),
                    KpiType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kpis", x => x.KpiId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    ShipId = table.Column<long>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "SensorValuesRows",
                columns: table => new
                {
                    EfSensorValuesRowId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImportTimestamp = table.Column<DateTime>(nullable: false),
                    RowTimestamp = table.Column<long>(nullable: false),
                    ShipId = table.Column<long>(nullable: false),
                    sensor1 = table.Column<double>(nullable: false),
                    sensor2 = table.Column<double>(nullable: false),
                    sensor3 = table.Column<double>(nullable: false),
                    sensor4 = table.Column<double>(nullable: false),
                    sensor5 = table.Column<double>(nullable: false),
                    sensor6 = table.Column<double>(nullable: false),
                    sensor7 = table.Column<double>(nullable: false),
                    sensor8 = table.Column<double>(nullable: false),
                    sensor9 = table.Column<double>(nullable: false),
                    sensor10 = table.Column<double>(nullable: false),
                    sensor11 = table.Column<double>(nullable: false),
                    sensor12 = table.Column<double>(nullable: false),
                    sensor13 = table.Column<double>(nullable: false),
                    sensor14 = table.Column<double>(nullable: false),
                    sensor15 = table.Column<double>(nullable: false),
                    sensor16 = table.Column<double>(nullable: false),
                    sensor17 = table.Column<double>(nullable: false),
                    sensor18 = table.Column<double>(nullable: false),
                    sensor19 = table.Column<double>(nullable: false),
                    sensor20 = table.Column<double>(nullable: false),
                    sensor21 = table.Column<double>(nullable: false),
                    sensor22 = table.Column<double>(nullable: false),
                    sensor23 = table.Column<double>(nullable: false),
                    sensor24 = table.Column<double>(nullable: false),
                    sensor25 = table.Column<double>(nullable: false),
                    sensor26 = table.Column<double>(nullable: false),
                    sensor27 = table.Column<double>(nullable: false),
                    sensor28 = table.Column<double>(nullable: false),
                    sensor29 = table.Column<double>(nullable: false),
                    sensor30 = table.Column<double>(nullable: false),
                    sensor31 = table.Column<double>(nullable: false),
                    sensor32 = table.Column<double>(nullable: false),
                    sensor33 = table.Column<double>(nullable: false),
                    sensor34 = table.Column<double>(nullable: false),
                    sensor35 = table.Column<double>(nullable: false),
                    sensor36 = table.Column<double>(nullable: false),
                    sensor37 = table.Column<double>(nullable: false),
                    sensor38 = table.Column<double>(nullable: false),
                    sensor39 = table.Column<double>(nullable: false),
                    sensor40 = table.Column<double>(nullable: false),
                    sensor41 = table.Column<double>(nullable: false),
                    sensor42 = table.Column<double>(nullable: false),
                    sensor43 = table.Column<double>(nullable: false),
                    sensor44 = table.Column<double>(nullable: false),
                    sensor45 = table.Column<double>(nullable: false),
                    sensor46 = table.Column<double>(nullable: false),
                    sensor47 = table.Column<double>(nullable: false),
                    sensor48 = table.Column<double>(nullable: false),
                    sensor49 = table.Column<double>(nullable: false),
                    sensor50 = table.Column<double>(nullable: false),
                    sensor51 = table.Column<double>(nullable: false),
                    sensor52 = table.Column<double>(nullable: false),
                    sensor53 = table.Column<double>(nullable: false),
                    sensor54 = table.Column<double>(nullable: false),
                    sensor55 = table.Column<double>(nullable: false),
                    sensor56 = table.Column<double>(nullable: false),
                    sensor57 = table.Column<double>(nullable: false),
                    sensor58 = table.Column<double>(nullable: false),
                    sensor59 = table.Column<double>(nullable: false),
                    sensor60 = table.Column<double>(nullable: false),
                    sensor61 = table.Column<double>(nullable: false),
                    sensor62 = table.Column<double>(nullable: false),
                    sensor63 = table.Column<double>(nullable: false),
                    sensor64 = table.Column<double>(nullable: false),
                    sensor65 = table.Column<double>(nullable: false),
                    sensor66 = table.Column<double>(nullable: false),
                    sensor67 = table.Column<double>(nullable: false),
                    sensor68 = table.Column<double>(nullable: false),
                    sensor69 = table.Column<double>(nullable: false),
                    sensor70 = table.Column<double>(nullable: false),
                    sensor71 = table.Column<double>(nullable: false),
                    sensor72 = table.Column<double>(nullable: false),
                    sensor73 = table.Column<double>(nullable: false),
                    sensor74 = table.Column<double>(nullable: false),
                    sensor75 = table.Column<double>(nullable: false),
                    sensor76 = table.Column<double>(nullable: false),
                    sensor77 = table.Column<double>(nullable: false),
                    sensor78 = table.Column<double>(nullable: false),
                    sensor79 = table.Column<double>(nullable: false),
                    sensor80 = table.Column<double>(nullable: false),
                    sensor81 = table.Column<double>(nullable: false),
                    sensor82 = table.Column<double>(nullable: false),
                    sensor83 = table.Column<double>(nullable: false),
                    sensor84 = table.Column<double>(nullable: false),
                    sensor85 = table.Column<double>(nullable: false),
                    sensor86 = table.Column<double>(nullable: false),
                    sensor87 = table.Column<double>(nullable: false),
                    sensor88 = table.Column<double>(nullable: false),
                    sensor89 = table.Column<double>(nullable: false),
                    sensor90 = table.Column<double>(nullable: false),
                    sensor91 = table.Column<double>(nullable: false),
                    sensor92 = table.Column<double>(nullable: false),
                    sensor93 = table.Column<double>(nullable: false),
                    sensor94 = table.Column<double>(nullable: false),
                    sensor95 = table.Column<double>(nullable: false),
                    sensor96 = table.Column<double>(nullable: false),
                    sensor97 = table.Column<double>(nullable: false),
                    sensor98 = table.Column<double>(nullable: false),
                    sensor99 = table.Column<double>(nullable: false),
                    sensor100 = table.Column<double>(nullable: false),
                    sensor101 = table.Column<double>(nullable: false),
                    sensor102 = table.Column<double>(nullable: false),
                    sensor103 = table.Column<double>(nullable: false),
                    sensor104 = table.Column<double>(nullable: false),
                    sensor105 = table.Column<double>(nullable: false),
                    sensor106 = table.Column<double>(nullable: false),
                    sensor107 = table.Column<double>(nullable: false),
                    sensor108 = table.Column<double>(nullable: false),
                    sensor109 = table.Column<double>(nullable: false),
                    sensor110 = table.Column<double>(nullable: false),
                    sensor111 = table.Column<double>(nullable: false),
                    sensor112 = table.Column<double>(nullable: false),
                    sensor113 = table.Column<double>(nullable: false),
                    sensor114 = table.Column<double>(nullable: false),
                    sensor115 = table.Column<double>(nullable: false),
                    sensor116 = table.Column<double>(nullable: false),
                    sensor117 = table.Column<double>(nullable: false),
                    sensor118 = table.Column<double>(nullable: false),
                    sensor119 = table.Column<double>(nullable: false),
                    sensor120 = table.Column<double>(nullable: false),
                    sensor121 = table.Column<double>(nullable: false),
                    sensor122 = table.Column<double>(nullable: false),
                    sensor123 = table.Column<double>(nullable: false),
                    sensor124 = table.Column<double>(nullable: false),
                    sensor125 = table.Column<double>(nullable: false),
                    sensor126 = table.Column<double>(nullable: false),
                    sensor127 = table.Column<double>(nullable: false),
                    sensor128 = table.Column<double>(nullable: false),
                    sensor129 = table.Column<double>(nullable: false),
                    sensor130 = table.Column<double>(nullable: false),
                    sensor131 = table.Column<double>(nullable: false),
                    sensor132 = table.Column<double>(nullable: false),
                    sensor133 = table.Column<double>(nullable: false),
                    sensor134 = table.Column<double>(nullable: false),
                    sensor135 = table.Column<double>(nullable: false),
                    sensor136 = table.Column<double>(nullable: false),
                    sensor137 = table.Column<double>(nullable: false),
                    sensor138 = table.Column<double>(nullable: false),
                    sensor139 = table.Column<double>(nullable: false),
                    sensor140 = table.Column<double>(nullable: false),
                    sensor141 = table.Column<double>(nullable: false),
                    sensor142 = table.Column<double>(nullable: false),
                    sensor143 = table.Column<double>(nullable: false),
                    sensor144 = table.Column<double>(nullable: false),
                    sensor145 = table.Column<double>(nullable: false),
                    sensor146 = table.Column<double>(nullable: false),
                    sensor147 = table.Column<double>(nullable: false),
                    sensor148 = table.Column<double>(nullable: false),
                    sensor149 = table.Column<double>(nullable: false),
                    sensor150 = table.Column<double>(nullable: false),
                    sensor151 = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorValuesRows", x => x.EfSensorValuesRowId);
                    table.ForeignKey(
                        name: "FK_SensorValuesRows_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SensorValuesRows_ShipId",
                table: "SensorValuesRows",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_UserId1",
                table: "Ships",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DataImportMetas");

            migrationBuilder.DropTable(
                name: "Kpis");

            migrationBuilder.DropTable(
                name: "SensorValuesRows");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
