using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEbayTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtColumnToItemsOfInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ItemsOfInterest",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ItemsOfInterest",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ItemsOfInterest");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ItemsOfInterest",
                newName: "Title");
        }
    }
}
