using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEbayTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstNameToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ItemsOfInterest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EbayItemId = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsOfInterest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemOfInterestId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    PriceValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    PriceCurrency = table.Column<string>(type: "TEXT", nullable: false),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ListingUrl = table.Column<string>(type: "TEXT", nullable: false),
                    SellerUsername = table.Column<string>(type: "TEXT", nullable: false),
                    SellerFeedbackPercentage = table.Column<double>(type: "REAL", nullable: false),
                    SellerFeedbackScore = table.Column<int>(type: "INTEGER", nullable: false),
                    ShippingCostValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    ShippingCostCurrency = table.Column<string>(type: "TEXT", nullable: false),
                    MinEstimatedDeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaxEstimatedDeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnsAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReturnPeriodValue = table.Column<int>(type: "INTEGER", nullable: false),
                    ReturnPeriodUnit = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_ItemsOfInterest_ItemOfInterestId",
                        column: x => x.ItemOfInterestId,
                        principalTable: "ItemsOfInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserItemInterests",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ItemOfInterestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItemInterests", x => new { x.UserId, x.ItemOfInterestId });
                    table.ForeignKey(
                        name: "FK_UserItemInterests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItemInterests_ItemsOfInterest_ItemOfInterestId",
                        column: x => x.ItemOfInterestId,
                        principalTable: "ItemsOfInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ItemOfInterestId",
                table: "Listings",
                column: "ItemOfInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItemInterests_ItemOfInterestId",
                table: "UserItemInterests",
                column: "ItemOfInterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "UserItemInterests");

            migrationBuilder.DropTable(
                name: "ItemsOfInterest");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
