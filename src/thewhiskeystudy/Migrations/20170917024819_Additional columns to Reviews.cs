using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace thewhiskeystudy.Migrations
{
    public partial class AdditionalcolumnstoReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObtainabilityStatus",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Reviews",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "YearReleased",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObtainabilityStatus",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "YearReleased",
                table: "Reviews");
        }
    }
}
