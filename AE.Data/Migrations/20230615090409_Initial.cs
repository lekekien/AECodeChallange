using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AE.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Longtitude = table.Column<double>(type: "double precision", nullable: false),
                    Lattitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Longtitude = table.Column<double>(type: "double precision", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Velocity = table.Column<double>(type: "double precision", nullable: false),
                    CreateUser = table.Column<string>(type: "text", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ship", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Port",
                columns: new[] { "Id", "Lattitude", "Longtitude", "Name" },
                values: new object[,]
                {
                    { new Guid("1d4571e0-3fa6-4d80-884b-6931aa76a762"), 21.027763, 105.834160, "Hanoi" },
                    { new Guid("243e3b93-2710-41f6-a0a8-f94171f81044"), 41.878113, -87.629799, "Chicago" },
                    { new Guid("505996e6-8250-412a-a10e-4d04a461fc6a"),-33.8698439, 151.2082848, "Sydney" },
                    { new Guid("52066584-c4a5-4656-abdb-ec564a9a5faa"), 48.8588897,2.320041, "Paris" },
                    { new Guid("d3ad4946-a0fb-4f6e-a537-0f83c3eb55b4"),1.357107, 103.8194992, "Singapore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Ship");
        }
    }
}
