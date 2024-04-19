﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeData.Api.Migrations
{
    /// <inheritdoc />
    public partial class CityColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "City");
        }
    }
}
