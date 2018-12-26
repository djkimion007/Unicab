using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class RenewModelRelatedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "OriginLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "AcceptedPassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "CarpoolOfferId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "DropOffLocationId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "PickUpLocationId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedDriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropColumn(
                name: "CabRequestId",
                table: "CabRequestFulfillments");

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationLocationId",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferDriverDriverId",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginLocationLocationId",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DropOffLocationLocationId",
                table: "CabRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationLocationId",
                table: "CabRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestPassengerPassengerId",
                table: "CabRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcceptedDriverDriverId",
                table: "CabRequestFulfillments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestCabCabRequestId",
                table: "CabRequestFulfillments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_DestinationLocationLocationId",
                table: "CarpoolOffers",
                column: "DestinationLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_OfferDriverDriverId",
                table: "CarpoolOffers",
                column: "OfferDriverDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_OriginLocationLocationId",
                table: "CarpoolOffers",
                column: "OriginLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOfferFulfillments_AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments",
                column: "AcceptedPassengerIdPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOfferFulfillments_OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                column: "OfferCarpoolCarpoolOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_DropOffLocationLocationId",
                table: "CabRequests",
                column: "DropOffLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_PickUpLocationLocationId",
                table: "CabRequests",
                column: "PickUpLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_RequestPassengerPassengerId",
                table: "CabRequests",
                column: "RequestPassengerPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequestFulfillments_AcceptedDriverDriverId",
                table: "CabRequestFulfillments",
                column: "AcceptedDriverDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequestFulfillments_RequestCabCabRequestId",
                table: "CabRequestFulfillments",
                column: "RequestCabCabRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequestFulfillments_Drivers_AcceptedDriverDriverId",
                table: "CabRequestFulfillments",
                column: "AcceptedDriverDriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_RequestCabCabRequestId",
                table: "CabRequestFulfillments",
                column: "RequestCabCabRequestId",
                principalTable: "CabRequests",
                principalColumn: "CabRequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Locations_DropOffLocationLocationId",
                table: "CabRequests",
                column: "DropOffLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Locations_PickUpLocationLocationId",
                table: "CabRequests",
                column: "PickUpLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Passengers_RequestPassengerPassengerId",
                table: "CabRequests",
                column: "RequestPassengerPassengerId",
                principalTable: "Passengers",
                principalColumn: "PassengerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOfferFulfillments_Passengers_AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments",
                column: "AcceptedPassengerIdPassengerId",
                principalTable: "Passengers",
                principalColumn: "PassengerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                column: "OfferCarpoolCarpoolOfferId",
                principalTable: "CarpoolOffers",
                principalColumn: "CarpoolOfferId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Locations_DestinationLocationLocationId",
                table: "CarpoolOffers",
                column: "DestinationLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Drivers_OfferDriverDriverId",
                table: "CarpoolOffers",
                column: "OfferDriverDriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Locations_OriginLocationLocationId",
                table: "CarpoolOffers",
                column: "OriginLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_Drivers_AcceptedDriverDriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_RequestCabCabRequestId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_DropOffLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_PickUpLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Passengers_RequestPassengerPassengerId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOfferFulfillments_Passengers_AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_DestinationLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Drivers_OfferDriverDriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_OriginLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_DestinationLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_OfferDriverDriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_OriginLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOfferFulfillments_AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOfferFulfillments_OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_DropOffLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_PickUpLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_RequestPassengerPassengerId",
                table: "CabRequests");

            migrationBuilder.DropIndex(
                name: "IX_CabRequestFulfillments_AcceptedDriverDriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropIndex(
                name: "IX_CabRequestFulfillments_RequestCabCabRequestId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropColumn(
                name: "DestinationLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "OfferDriverDriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "OriginLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "DropOffLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "PickUpLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "RequestPassengerPassengerId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedDriverDriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropColumn(
                name: "RequestCabCabRequestId",
                table: "CabRequestFulfillments");

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationId",
                table: "CarpoolOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "CarpoolOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginLocationId",
                table: "CarpoolOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcceptedPassengerId",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DropOffLocationId",
                table: "CabRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "CabRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationId",
                table: "CabRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcceptedDriverId",
                table: "CabRequestFulfillments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CabRequestId",
                table: "CabRequestFulfillments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
