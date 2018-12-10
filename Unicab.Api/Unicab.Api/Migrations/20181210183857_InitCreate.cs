using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class InitCreate : Migration
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
                    AddedDateTime = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
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
                    AddedDateTime = table.Column<DateTime>(nullable: false),
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
                    AddedDateTime = table.Column<DateTime>(nullable: false),
                    AddedByAdminId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
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
                    AddedDateTime = table.Column<DateTime>(nullable: false),
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
                    MatricsCardPhoto = table.Column<byte[]>(nullable: true),
                    AddedDateTime = table.Column<DateTime>(nullable: false),
                    AddedByAdminId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "DriverApplicants");

            migrationBuilder.DropTable(
                name: "DriverBlacklists");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "PassengerApplicants");

            migrationBuilder.DropTable(
                name: "PassengerBlacklists");

            migrationBuilder.DropTable(
                name: "Passengers");
        }
    }
}
