using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlippingTracker.Migrations
{
    public partial class MoreItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Items",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Items",
                newName: "description");

            migrationBuilder.AlterColumn<string>(
                name: "price",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Currentid",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Todayid",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "icon_large",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "members",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "trend",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeIcon",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Current",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trend = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Today",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    price = table.Column<int>(type: "int", nullable: false),
                    trend = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Today", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Currentid",
                table: "Items",
                column: "Currentid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Todayid",
                table: "Items",
                column: "Todayid");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Current_Currentid",
                table: "Items",
                column: "Currentid",
                principalTable: "Current",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Today_Todayid",
                table: "Items",
                column: "Todayid",
                principalTable: "Today",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Current_Currentid",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Today_Todayid",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Current");

            migrationBuilder.DropTable(
                name: "Today");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Currentid",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Todayid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Currentid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Todayid",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "icon",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "icon_large",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "members",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "trend",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "typeIcon",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Items",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Items",
                newName: "Description");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "Items",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemID");
        }
    }
}
