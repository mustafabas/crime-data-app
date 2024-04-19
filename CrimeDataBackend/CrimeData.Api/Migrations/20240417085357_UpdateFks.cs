using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeData.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crime_CrimeAgainstCategory_OffenseId",
                table: "Crime");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Offence",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_CrimeAgainstCategoryId",
                table: "Crime",
                column: "CrimeAgainstCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Crime_ParentGroupId",
                table: "Crime",
                column: "ParentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_CrimeAgainstCategory_CrimeAgainstCategoryId",
                table: "Crime",
                column: "CrimeAgainstCategoryId",
                principalTable: "CrimeAgainstCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_ParentGroup_ParentGroupId",
                table: "Crime",
                column: "ParentGroupId",
                principalTable: "ParentGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crime_CrimeAgainstCategory_CrimeAgainstCategoryId",
                table: "Crime");

            migrationBuilder.DropForeignKey(
                name: "FK_Crime_ParentGroup_ParentGroupId",
                table: "Crime");

            migrationBuilder.DropIndex(
                name: "IX_Crime_CrimeAgainstCategoryId",
                table: "Crime");

            migrationBuilder.DropIndex(
                name: "IX_Crime_ParentGroupId",
                table: "Crime");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Offence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crime_CrimeAgainstCategory_OffenseId",
                table: "Crime",
                column: "OffenseId",
                principalTable: "CrimeAgainstCategory",
                principalColumn: "Id");
        }
    }
}
