using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeData.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crime_Offence_OffenseId",
                table: "Crime");

            migrationBuilder.DropTable(
                name: "Offence");

            migrationBuilder.DropIndex(
                name: "IX_Crime_OffenseId",
                table: "Crime");

            migrationBuilder.DropColumn(
                name: "OffenseId",
                table: "Crime");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ParentGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Offense",
                table: "Crime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ParentGroup");

            migrationBuilder.DropColumn(
                name: "Offense",
                table: "Crime");

            migrationBuilder.AddColumn<int>(
                name: "OffenseId",
                table: "Crime",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiSourceId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CredatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Crime_OffenseId",
                table: "Crime",
                column: "OffenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Offence_ApiSourceId",
                table: "Offence",
                column: "ApiSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_Offence_OffenseId",
                table: "Crime",
                column: "OffenseId",
                principalTable: "Offence",
                principalColumn: "Id");
        }
    }
}
