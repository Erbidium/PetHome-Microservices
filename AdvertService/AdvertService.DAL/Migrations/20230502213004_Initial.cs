﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ownerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    performerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adverts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "advertsToRequests",
                columns: table => new
                {
                    advertId = table.Column<int>(type: "int", nullable: false),
                    requestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advertsToRequests", x => new { x.advertId, x.requestId });
                    table.ForeignKey(
                        name: "FK_advertsToRequests_adverts_advertId",
                        column: x => x.advertId,
                        principalTable: "adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "adverts",
                columns: new[] { "Id", "cost", "description", "endTime", "location", "name", "ownerId", "performerId", "startTime", "status" },
                values: new object[] { 1, 500, "TestDesacription", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyiv", "TestAdvert", "", null, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advertsToRequests");

            migrationBuilder.DropTable(
                name: "adverts");
        }
    }
}
