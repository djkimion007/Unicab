using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class AnotherUpdateModelRelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_Drivers_AcceptedDriverDriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_RequestCabCabRequestId",
                table: "CabRequestFulfillments");

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
                name: "FK_CarpoolOffers_Drivers_OfferDriverDriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_OfferDriverDriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOfferFulfillments_AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_RequestPassengerPassengerId",
                table: "CabRequests");

            migrationBuilder.DropIndex(
                name: "IX_CabRequestFulfillments_AcceptedDriverDriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropColumn(
                name: "OfferDriverDriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "RequestPassengerPassengerId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedDriverDriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.RenameColumn(
                name: "OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                newName: "CarpoolOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_CarpoolOfferFulfillments_OfferCarpoolCarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                newName: "IX_CarpoolOfferFulfillments_CarpoolOfferId");

            migrationBuilder.RenameColumn(
                name: "RequestCabCabRequestId",
                table: "CabRequestFulfillments",
                newName: "CabRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CabRequestFulfillments_RequestCabCabRequestId",
                table: "CabRequestFulfillments",
                newName: "IX_CabRequestFulfillments_CabRequestId");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "CarpoolOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "CabRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "CabRequestFulfillments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_DriverId",
                table: "CarpoolOffers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOfferFulfillments_PassengerId",
                table: "CarpoolOfferFulfillments",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_PassengerId",
                table: "CabRequests",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequestFulfillments_DriverId",
                table: "CabRequestFulfillments",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_CabRequestId",
                table: "CabRequestFulfillments",
                column: "CabRequestId",
                principalTable: "CabRequests",
                principalColumn: "CabRequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequestFulfillments_Drivers_DriverId",
                table: "CabRequestFulfillments",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Passengers_PassengerId",
                table: "CabRequests",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "PassengerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                column: "CarpoolOfferId",
                principalTable: "CarpoolOffers",
                principalColumn: "CarpoolOfferId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOfferFulfillments_Passengers_PassengerId",
                table: "CarpoolOfferFulfillments",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "PassengerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Drivers_DriverId",
                table: "CarpoolOffers",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_CabRequestId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_Drivers_DriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Passengers_PassengerId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_CarpoolOfferId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOfferFulfillments_Passengers_PassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Drivers_DriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_DriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOfferFulfillments_PassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_PassengerId",
                table: "CabRequests");

            migrationBuilder.DropIndex(
                name: "IX_CabRequestFulfillments_DriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "CabRequestFulfillments");

            migrationBuilder.RenameColumn(
                name: "CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                newName: "OfferCarpoolCarpoolOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_CarpoolOfferFulfillments_CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                newName: "IX_CarpoolOfferFulfillments_OfferCarpoolCarpoolOfferId");

            migrationBuilder.RenameColumn(
                name: "CabRequestId",
                table: "CabRequestFulfillments",
                newName: "RequestCabCabRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CabRequestFulfillments_CabRequestId",
                table: "CabRequestFulfillments",
                newName: "IX_CabRequestFulfillments_RequestCabCabRequestId");

            migrationBuilder.AddColumn<int>(
                name: "OfferDriverDriverId",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestPassengerPassengerId",
                table: "CabRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcceptedDriverDriverId",
                table: "CabRequestFulfillments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_OfferDriverDriverId",
                table: "CarpoolOffers",
                column: "OfferDriverDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOfferFulfillments_AcceptedPassengerIdPassengerId",
                table: "CarpoolOfferFulfillments",
                column: "AcceptedPassengerIdPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_RequestPassengerPassengerId",
                table: "CabRequests",
                column: "RequestPassengerPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequestFulfillments_AcceptedDriverDriverId",
                table: "CabRequestFulfillments",
                column: "AcceptedDriverDriverId");

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
                name: "FK_CarpoolOffers_Drivers_OfferDriverDriverId",
                table: "CarpoolOffers",
                column: "OfferDriverDriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
