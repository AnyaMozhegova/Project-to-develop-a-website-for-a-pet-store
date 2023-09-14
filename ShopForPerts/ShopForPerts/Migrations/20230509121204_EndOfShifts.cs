using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopForPerts.Migrations
{
    public partial class EndOfShifts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EndOfShift",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collection = table.Column<long>(type: "bigint", nullable: false),
                    cashless = table.Column<long>(type: "bigint", nullable: false),
                    cash = table.Column<long>(type: "bigint", nullable: false),
                    banknote5000 = table.Column<long>(type: "bigint", nullable: false),
                    bankote1000 = table.Column<long>(type: "bigint", nullable: false),
                    bankote500 = table.Column<long>(type: "bigint", nullable: false),
                    bankote100 = table.Column<long>(type: "bigint", nullable: false),
                    bankote50 = table.Column<long>(type: "bigint", nullable: false),
                    bankoteSmall = table.Column<long>(type: "bigint", nullable: false),
                    refund = table.Column<long>(type: "bigint", nullable: false),
                    seller1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seller2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    day = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndOfShift", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndOfShift");
        }
    }
}
