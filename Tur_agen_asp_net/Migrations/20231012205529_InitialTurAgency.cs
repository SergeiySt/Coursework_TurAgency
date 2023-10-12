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
                name: "Tour",
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
                    table.PrimaryKey("PK_Tour", x => x.id_tour);
                });

            migrationBuilder.CreateTable(
                name: "TourOrder",
                columns: table => new
                {
                    id_tour_oder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tour = table.Column<int>(type: "int", nullable: false),
                    id_users = table.Column<int>(type: "int", nullable: false),
                    TOCount = table.Column<int>(type: "int", nullable: false),
                    TOSumm = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourOrder", x => x.id_tour_oder);
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
                    UPhone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_users);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "TourOrder");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
