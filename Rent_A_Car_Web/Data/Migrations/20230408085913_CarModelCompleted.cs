using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Car_Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarModelCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentEnd",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RentStart",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentEnd",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RentStart",
                table: "Cars");
        }
    }
}
