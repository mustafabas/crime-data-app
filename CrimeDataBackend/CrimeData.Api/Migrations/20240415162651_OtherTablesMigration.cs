using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeData.Api.Migrations
{
    /// <inheritdoc />
    public partial class OtherTablesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CredatedAt",
                table: "ApiSource",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiSourceId = table.Column<int>(type: "int", nullable: false),
                    CredatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_ApiSource_ApiSourceId",
                        column: x => x.ApiSourceId,
                        principalTable: "ApiSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrimeAgainstCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiSourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CredatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeAgainstCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrimeAgainstCategory_ApiSource_ApiSourceId",
                        column: x => x.ApiSourceId,
                        principalTable: "ApiSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiSourceId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CredatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offence_ApiSource_ApiSourceId",
                        column: x => x.ApiSourceId,
                        principalTable: "ApiSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiSourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CredatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentGroup_ApiSource_ApiSourceId",
                        column: x => x.ApiSourceId,
                        principalTable: "ApiSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiSourceId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    OffenseId = table.Column<int>(type: "int", nullable: true),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true),
                    CrimeAgainstCategoryId = table.Column<int>(type: "int", nullable: true),
                    ReportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffenseStartDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Longtitde = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CredatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crime_ApiSource_ApiSourceId",
                        column: x => x.ApiSourceId,
                        principalTable: "ApiSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crime_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Crime_CrimeAgainstCategory_OffenseId",
                        column: x => x.OffenseId,
                        principalTable: "CrimeAgainstCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Crime_Offence_OffenseId",
                        column: x => x.OffenseId,
                        principalTable: "Offence",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_ApiSourceId",
                table: "City",
                column: "ApiSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_ApiSourceId",
                table: "Crime",
                column: "ApiSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_CityId",
                table: "Crime",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_OffenseId",
                table: "Crime",
                column: "OffenseId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeAgainstCategory_ApiSourceId",
                table: "CrimeAgainstCategory",
                column: "ApiSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Offence_ApiSourceId",
                table: "Offence",
                column: "ApiSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentGroup_ApiSourceId",
                table: "ParentGroup",
                column: "ApiSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crime");

            migrationBuilder.DropTable(
                name: "ParentGroup");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CrimeAgainstCategory");

            migrationBuilder.DropTable(
                name: "Offence");

            migrationBuilder.DropColumn(
                name: "CredatedAt",
                table: "ApiSource");
        }
    }
}
