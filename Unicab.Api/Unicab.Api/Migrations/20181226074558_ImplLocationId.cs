using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class ImplLocationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationLocation",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "OriginLocation",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "DropOffLocation",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "PickUpLocation",
                table: "CabRequests");

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationId",
                table: "CarpoolOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginLocationId",
                table: "CarpoolOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DropOffLocationId",
                table: "CabRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationId",
                table: "CabRequests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "OriginLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "DropOffLocationId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "PickUpLocationId",
                table: "CabRequests");

            migrationBuilder.AddColumn<string>(
                name: "DestinationLocation",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginLocation",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DropOffLocation",
                table: "CabRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickUpLocation",
                table: "CabRequests",
                nullable: true);
        }
    }
}
