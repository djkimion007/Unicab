using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class NewFKMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_LocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_PickUpLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_DestinationLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_LocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_DestinationLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_LocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_LocationId",
                table: "CabRequests");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_PickUpLocationLocationId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "DestinationLocationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CabRequests");

            migrationBuilder.DropColumn(
                name: "PickUpLocationLocationId",
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

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_DestinationLocationId",
                table: "CarpoolOffers",
                column: "DestinationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_OriginLocationId",
                table: "CarpoolOffers",
                column: "OriginLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_DropOffLocationId",
                table: "CabRequests",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_PickUpLocationId",
                table: "CabRequests",
                column: "PickUpLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Locations_DropOffLocationId",
                table: "CabRequests",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Locations_PickUpLocationId",
                table: "CabRequests",
                column: "PickUpLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Locations_DestinationLocationId",
                table: "CarpoolOffers",
                column: "DestinationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Locations_OriginLocationId",
                table: "CarpoolOffers",
                column: "OriginLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_DropOffLocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CabRequests_Locations_PickUpLocationId",
                table: "CabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_DestinationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_CarpoolOffers_Locations_OriginLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_DestinationLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarpoolOffers_OriginLocationId",
                table: "CarpoolOffers");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_DropOffLocationId",
                table: "CabRequests");

            migrationBuilder.DropIndex(
                name: "IX_CabRequests_PickUpLocationId",
                table: "CabRequests");

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

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationLocationId",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "CarpoolOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "CabRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationLocationId",
                table: "CabRequests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_DestinationLocationLocationId",
                table: "CarpoolOffers",
                column: "DestinationLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpoolOffers_LocationId",
                table: "CarpoolOffers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_LocationId",
                table: "CabRequests",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabRequests_PickUpLocationLocationId",
                table: "CabRequests",
                column: "PickUpLocationLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CabRequests_Locations_LocationId",
                table: "CabRequests",
                column: "LocationId",
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
                name: "FK_CarpoolOffers_Locations_DestinationLocationLocationId",
                table: "CarpoolOffers",
                column: "DestinationLocationLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarpoolOffers_Locations_LocationId",
                table: "CarpoolOffers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
