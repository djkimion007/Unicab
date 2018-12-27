using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class CarpoolOfferUpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DriverCancelledDateTime",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "DriverHasCancelled",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PassengerCancelledDateTime",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PassengerHasCancelled",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverCancelledDateTime",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "DriverHasCancelled",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "PassengerCancelledDateTime",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "PassengerHasCancelled",
                table: "CarpoolOfferFulfillments");
        }
    }
}
