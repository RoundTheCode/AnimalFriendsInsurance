using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalFriendsInsurance.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "afi");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "afi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDateOfBirth",
                schema: "afi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDateOfBirth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDateOfBirth_Customer_Id",
                        column: x => x.Id,
                        principalSchema: "afi",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEmail",
                schema: "afi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerEmail_Customer_Id",
                        column: x => x.Id,
                        principalSchema: "afi",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDateOfBirth",
                schema: "afi");

            migrationBuilder.DropTable(
                name: "CustomerEmail",
                schema: "afi");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "afi");
        }
    }
}
