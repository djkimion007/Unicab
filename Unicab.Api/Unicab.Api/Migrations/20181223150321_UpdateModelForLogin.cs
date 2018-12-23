using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unicab.Api.Migrations
{
    public partial class UpdateModelForLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentLoginDateTime",
                table: "Passengers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrentLoginUniqueId",
                table: "Passengers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Passengers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateTime",
                table: "Passengers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentLoginDateTime",
                table: "Drivers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrentLoginUniqueId",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Drivers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateTime",
                table: "Drivers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentLoginDateTime",
                table: "Admins",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrentLoginUniqueId",
                table: "Admins",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Admins",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateTime",
                table: "Admins",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLoginDateTime",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "CurrentLoginUniqueId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "LastLoginDateTime",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "CurrentLoginDateTime",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CurrentLoginUniqueId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LastLoginDateTime",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CurrentLoginDateTime",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "CurrentLoginUniqueId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "LastLoginDateTime",
                table: "Admins");
        }
    }
}
