using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tur_agen_asp_net.Migrations
{
    /// <inheritdoc />
    public partial class InitialTourAgency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    id_tour = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName_tour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TCount = table.Column<int>(type: "int", nullable: false),
                    TUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.id_tour);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id_users = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ULogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPhone = table.Column<int>(type: "int", nullable: false),
                    UIsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_users);
                });

            migrationBuilder.CreateTable(
                name: "TourOrder",
                columns: table => new
                {
                    id_tour_order = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TOQuantity = table.Column<int>(type: "int", nullable: false),
                    TOPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourOrder", x => x.id_tour_order);
                    table.ForeignKey(
                        name: "FK_TourOrder_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "id_tour",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourOrder_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id_users",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrderHistory",
                columns: table => new
                {
                    id_user_order_history = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderHistory", x => x.id_user_order_history);
                    table.ForeignKey(
                        name: "FK_UserOrderHistory_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "id_tour",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrderHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id_users",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourOrder_TourId",
                table: "TourOrder",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourOrder_UserId",
                table: "TourOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderHistory_TourId",
                table: "UserOrderHistory",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderHistory_UserId",
                table: "UserOrderHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourOrder");

            migrationBuilder.DropTable(
                name: "UserOrderHistory");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
