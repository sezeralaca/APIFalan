using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDoContent.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentDate",
                table: "Contents");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Contents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Contents");

            migrationBuilder.AddColumn<int>(
                name: "ContentDate",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
