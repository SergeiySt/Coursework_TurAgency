using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tur_agen_asp_net.Migrations
{
    /// <inheritdoc />
    public partial class InitialTurAgency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    id_tour = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName_tour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TCount = table.Column<int>(type: "int", nullable: false),
                    TUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.id_tour);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_users = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ULogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPhone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_users);
                });

            migrationBuilder.CreateTable(
                name: "TourOrders",
                columns: table => new
                {
                    id_tour_oder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tour = table.Column<int>(type: "int", nullable: false),
                    id_users = table.Column<int>(type: "int", nullable: false),
                    TOCount = table.Column<int>(type: "int", nullable: false),
                    TOSumm = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Tourid_tour = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourOrders", x => x.id_tour_oder);
                    table.ForeignKey(
                        name: "FK_TourOrders_Tours_Tourid_tour",
                        column: x => x.Tourid_tour,
                        principalTable: "Tours",
                        principalColumn: "id_tour");
                    table.ForeignKey(
                        name: "FK_TourOrders_Tours_id_tour",
                        column: x => x.id_tour,
                        principalTable: "Tours",
                        principalColumn: "id_tour",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourOrders_Users_id_users",
                        column: x => x.id_users,
                        principalTable: "Users",
                        principalColumn: "id_users",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourOrders_id_tour",
                table: "TourOrders",
                column: "id_tour");

            migrationBuilder.CreateIndex(
                name: "IX_TourOrders_id_users",
                table: "TourOrders",
                column: "id_users");

            migrationBuilder.CreateIndex(
                name: "IX_TourOrders_Tourid_tour",
                table: "TourOrders",
                column: "Tourid_tour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourOrders");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
