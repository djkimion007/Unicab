using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class InitialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StaffPosition = table.Column<string>(nullable: true),
                    ProfilePhoto = table.Column<byte[]>(nullable: true),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Notes = table.Column<string>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "CabRequestFulfillments",
                columns: table => new
                {
                    CabRequestFulfillmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CabRequestId = table.Column<int>(nullable: false),
                    AcceptedDriverId = table.Column<int>(nullable: false),
                    DriverHasCompleted = table.Column<bool>(nullable: false),
                    DriverCompletedDateTime = table.Column<DateTime>(nullable: false),
                    PassengerHasCompleted = table.Column<bool>(nullable: false),
                    PassengerCompletedDateTime = table.Column<DateTime>(nullable: false),
                    DistanceTravelled = table.Column<double>(nullable: false),
                    FareCharge = table.Column<double>(nullable: false),
                    IsFarePaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabRequestFulfillments", x => x.CabRequestFulfillmentId);
                });

            migrationBuilder.CreateTable(
                name: "CabRequests",
                columns: table => new
                {
                    CabRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PassengerId = table.Column<int>(nullable: false),
                    PickUpLocation = table.Column<string>(nullable: true),
                    PickUpDateTime = table.Column<DateTime>(nullable: false),
                    DropOffLocation = table.Column<string>(nullable: true),
                    NoOfPassengers = table.Column<int>(nullable: false),
                    IsLadiesOnly = table.Column<bool>(nullable: false),
                    AdditionalNotes = table.Column<string>(nullable: true),
                    RequestPeriod = table.Column<int>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabRequests", x => x.CabRequestId);
                });

            migrationBuilder.CreateTable(
                name: "CarpoolOfferFulfillments",
                columns: table => new
                {
                    CarpoolOfferFulfillmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarpoolOfferId = table.Column<int>(nullable: false),
                    AcceptedPassengerId = table.Column<int>(nullable: false),
                    DriverHasCompleted = table.Column<bool>(nullable: false),
                    DriverCompletedDateTime = table.Column<DateTime>(nullable: false),
                    PassengerHasCompleted = table.Column<bool>(nullable: false),
                    PassengerCompletedDateTime = table.Column<DateTime>(nullable: false),
                    DistanceTravelled = table.Column<double>(nullable: false),
                    FareCharge = table.Column<double>(nullable: false),
                    IsFarePaid = table.Column<bool>(nullable: false),
                    IsFareSplit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpoolOfferFulfillments", x => x.CarpoolOfferFulfillmentId);
                });

            migrationBuilder.CreateTable(
                name: "CarpoolOffers",
                columns: table => new
                {
                    CarpoolOfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriverId = table.Column<int>(nullable: false),
                    OriginLocation = table.Column<string>(nullable: true),
                    OriginDateTime = table.Column<DateTime>(nullable: false),
                    DestinationLocation = table.Column<string>(nullable: true),
                    NoOfPassengers = table.Column<int>(nullable: false),
                    IsLadiesOnly = table.Column<bool>(nullable: false),
                    AdditionalNotes = table.Column<string>(nullable: true),
                    OfferPeriod = table.Column<int>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpoolOffers", x => x.CarpoolOfferId);
                });

            migrationBuilder.CreateTable(
                name: "DriverApplicants",
                columns: table => new
                {
                    DriverApplicantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatricsNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    MatricsCardPhoto = table.Column<byte[]>(nullable: true),
                    DriversLicensePhoto = table.Column<byte[]>(nullable: true),
                    DriversLicenseDueDate = table.Column<DateTime>(nullable: false),
                    CarPlateNo = table.Column<string>(nullable: true),
                    CarMake = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    CarMakeYear = table.Column<string>(nullable: true),
                    CarColour = table.Column<string>(nullable: true),
                    CarRoadTaxDueDate = table.Column<DateTime>(nullable: false),
                    CarInsuranceGrantPhoto = table.Column<byte[]>(nullable: true),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApprovedDateTime = table.Column<DateTime>(nullable: false),
                    ApprovedByAdminId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverApplicants", x => x.DriverApplicantId);
                });

            migrationBuilder.CreateTable(
                name: "DriverBlacklists",
                columns: table => new
                {
                    DriverBlacklistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriverId = table.Column<int>(nullable: false),
                    BlacklistedDateTime = table.Column<DateTime>(nullable: false),
                    BlacklistedReason = table.Column<string>(nullable: true),
                    BlacklistedByAdminId = table.Column<int>(nullable: false),
                    BlacklistedDuration = table.Column<int>(nullable: false),
                    UnblacklistedDateTime = table.Column<DateTime>(nullable: false),
                    UnblacklistedReason = table.Column<string>(nullable: true),
                    UnblacklistedByAdminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverBlacklists", x => x.DriverBlacklistId);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatricsNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ProfilePhoto = table.Column<byte[]>(nullable: true),
                    MatricsCardPhoto = table.Column<byte[]>(nullable: true),
                    DriversLicensePhoto = table.Column<byte[]>(nullable: true),
                    DriversLicenseDueDate = table.Column<DateTime>(nullable: false),
                    CarPlateNo = table.Column<string>(nullable: true),
                    CarMake = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    CarMakeYear = table.Column<string>(nullable: true),
                    CarColour = table.Column<string>(nullable: true),
                    CarRoadTaxDueDate = table.Column<DateTime>(nullable: false),
                    CarInsuranceGrantPhoto = table.Column<byte[]>(nullable: true),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    AddedByAdminId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(nullable: true),
                    LocationLatitude = table.Column<double>(nullable: false),
                    LocationLongitude = table.Column<double>(nullable: false),
                    IsWithinUSM = table.Column<bool>(nullable: false),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "PassengerApplicants",
                columns: table => new
                {
                    PassengerApplicantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatricsNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    MatricsCardPhoto = table.Column<byte[]>(nullable: true),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApprovedDateTime = table.Column<DateTime>(nullable: false),
                    ApprovedByAdminId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerApplicants", x => x.PassengerApplicantId);
                });

            migrationBuilder.CreateTable(
                name: "PassengerBlacklists",
                columns: table => new
                {
                    PassengerBlacklistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PassengerId = table.Column<int>(nullable: false),
                    BlacklistedDateTime = table.Column<DateTime>(nullable: false),
                    BlacklistedReason = table.Column<string>(nullable: true),
                    BlacklistedByAdminId = table.Column<int>(nullable: false),
                    BlacklistedDuration = table.Column<int>(nullable: false),
                    UnblacklistedDateTime = table.Column<DateTime>(nullable: false),
                    UnblacklistedReason = table.Column<string>(nullable: true),
                    UnblacklistedByAdminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerBlacklists", x => x.PassengerBlacklistId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatricsNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ProfilePhoto = table.Column<byte[]>(nullable: true),
                    MatricsCardPhoto = table.Column<byte[]>(nullable: true),
                    AddedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    AddedByAdminId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                });

            migrationBuilder.CreateTable(
                name: "RatingFeedbacks",
                columns: table => new
                {
                    RatingFeedbackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RatingScore = table.Column<double>(nullable: false),
                    FeedbackText = table.Column<string>(nullable: true),
                    IsDriverFeedback = table.Column<bool>(nullable: false),
                    SentByPassengerId = table.Column<int>(nullable: false),
                    SentToDriverId = table.Column<int>(nullable: false),
                    SentByPassengerDateTime = table.Column<DateTime>(nullable: false),
                    IsPassengerFeedback = table.Column<bool>(nullable: false),
                    SentByDriverId = table.Column<int>(nullable: false),
                    SentToPassengerId = table.Column<int>(nullable: false),
                    SentByDriverDateTime = table.Column<DateTime>(nullable: false),
                    IsCarpoolFeedback = table.Column<bool>(nullable: false),
                    FeedbackCarpoolId = table.Column<int>(nullable: false),
                    IsCabRequestFeedback = table.Column<bool>(nullable: false),
                    FeedbackCabRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFeedbacks", x => x.RatingFeedbackId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CabRequestFulfillments");

            migrationBuilder.DropTable(
                name: "CabRequests");

            migrationBuilder.DropTable(
                name: "CarpoolOfferFulfillments");

            migrationBuilder.DropTable(
                name: "CarpoolOffers");

            migrationBuilder.DropTable(
                name: "DriverApplicants");

            migrationBuilder.DropTable(
                name: "DriverBlacklists");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PassengerApplicants");

            migrationBuilder.DropTable(
                name: "PassengerBlacklists");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "RatingFeedbacks");
        }
    }
}
