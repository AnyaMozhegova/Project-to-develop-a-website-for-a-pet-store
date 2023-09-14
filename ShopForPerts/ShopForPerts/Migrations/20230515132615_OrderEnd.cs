using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopForPerts.Migrations
{
    public partial class OrderEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderEndid",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderEnd",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEnd", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderEndid",
                table: "OrderDetail",
                column: "OrderEndid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_OrderEnd_OrderEndid",
                table: "OrderDetail",
                column: "OrderEndid",
                principalTable: "OrderEnd",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_OrderEnd_OrderEndid",
                table: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderEnd");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderEndid",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderEndid",
                table: "OrderDetail");
        }
    }
}
