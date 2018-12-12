using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class ChangeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatricsCardPhoto",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "MatricsCardPhoto",
                table: "PassengerApplicants");

            migrationBuilder.DropColumn(
                name: "CarInsuranceGrantPhoto",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriversLicensePhoto",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "MatricsCardPhoto",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CarInsuranceGrantPhoto",
                table: "DriverApplicants");

            migrationBuilder.DropColumn(
                name: "DriversLicensePhoto",
                table: "DriverApplicants");

            migrationBuilder.DropColumn(
                name: "MatricsCardPhoto",
                table: "DriverApplicants");

            migrationBuilder.AddColumn<string>(
                name: "MatricsCardPhotoAddress",
                table: "Passengers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatricsCardPhotoAddress",
                table: "PassengerApplicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarInsuranceGrantPhotoAddress",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriversLicensePhotoAddress",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatricsCardPhotoAddress",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarInsuranceGrantPhotoAddress",
                table: "DriverApplicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriversLicensePhotoAddress",
                table: "DriverApplicants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatricsCardPhotoAddress",
                table: "DriverApplicants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatricsCardPhotoAddress",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "MatricsCardPhotoAddress",
                table: "PassengerApplicants");

            migrationBuilder.DropColumn(
                name: "CarInsuranceGrantPhotoAddress",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriversLicensePhotoAddress",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "MatricsCardPhotoAddress",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CarInsuranceGrantPhotoAddress",
                table: "DriverApplicants");

            migrationBuilder.DropColumn(
                name: "DriversLicensePhotoAddress",
                table: "DriverApplicants");

            migrationBuilder.DropColumn(
                name: "MatricsCardPhotoAddress",
                table: "DriverApplicants");

            migrationBuilder.AddColumn<byte[]>(
                name: "MatricsCardPhoto",
                table: "Passengers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MatricsCardPhoto",
                table: "PassengerApplicants",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CarInsuranceGrantPhoto",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DriversLicensePhoto",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MatricsCardPhoto",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CarInsuranceGrantPhoto",
                table: "DriverApplicants",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DriversLicensePhoto",
                table: "DriverApplicants",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MatricsCardPhoto",
                table: "DriverApplicants",
                nullable: true);
        }
    }
}
