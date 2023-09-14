using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopForPerts.Migrations
{
    public partial class Manager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_OrderEnd_OrderEndid",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderEndid",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderEndid",
                table: "OrderDetail");

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isWork = table.Column<bool>(type: "bit", nullable: false),
                    yearWork = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.AddColumn<int>(
                name: "OrderEndid",
                table: "OrderDetail",
                type: "int",
                nullable: true);

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
    }
}
