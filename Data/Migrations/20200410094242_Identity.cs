using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeepakGallery.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2020, 4, 10, 15, 12, 42, 140, DateTimeKind.Local).AddTicks(8975));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2020, 4, 10, 13, 45, 56, 863, DateTimeKind.Local).AddTicks(6379));
        }
    }
}
