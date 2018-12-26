using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class UpdateModelFKAgainTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_CabRequestId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_DropOffLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_CarpoolOfferId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_OriginLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.RenameColumn(
                name: "OriginLocationLocationId",
                table: "CarpoolOffers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CarpoolOffers_OriginLocationLocationId",
                table: "CarpoolOffers",
                newName: "IX_CarpoolOffers_LocationId");

            migrationBuilder.RenameColumn(
                name: "DropOffLocationLocationId",
                table: "CabRequests",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CabRequests_DropOffLocationLocationId",
                table: "CabRequests",
                newName: "IX_CabRequests_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CabRequestId",
                table: "CabRequestFulfillments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_CabRequestId",
                table: "CabRequestFulfillments",
                column: "CabRequestId",
                principalTable: "CabRequests",
                principalColumn: "CabRequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Locations_LocationId",
                table: "CabRequests",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                column: "CarpoolOfferId",
                principalTable: "CarpoolOffers",
                principalColumn: "CarpoolOfferId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Locations_LocationId",
                table: "CarpoolOffers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_CabRequestId",
                table: "CabRequestFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_LocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_CarpoolOfferId",
                table: "CarpoolOfferFulfillments");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_LocationId",
                table: "CarpoolOffers");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "CarpoolOffers",
                newName: "OriginLocationLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CarpoolOffers_LocationId",
                table: "CarpoolOffers",
                newName: "IX_CarpoolOffers_OriginLocationLocationId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "CabRequests",
                newName: "DropOffLocationLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CabRequests_LocationId",
                table: "CabRequests",
                newName: "IX_CabRequests_DropOffLocationLocationId");

            migrationBuilder.AlterColumn<int>(
                name: "CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CabRequestId",
                table: "CabRequestFulfillments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequestFulfillments_CabRequests_CabRequestId",
                table: "CabRequestFulfillments",
                column: "CabRequestId",
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
                name: "FK_CarpoolOfferFulfillments_CarpoolOffers_CarpoolOfferId",
                table: "CarpoolOfferFulfillments",
                column: "CarpoolOfferId",
                principalTable: "CarpoolOffers",
                principalColumn: "CarpoolOfferId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Locations_OriginLocationLocationId",
                table: "CarpoolOffers",
                column: "OriginLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
