using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopForPerts.Migrations
{
    public partial class ChartWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartWork",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastNameSeller1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstNameSeller1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleNameSeller1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastNameSeller2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstNameSeller2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleNameSeller2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    day = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartWork", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartWork");
        }
    }
}
