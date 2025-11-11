using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsWithERD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Orders_OrderId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRoles_Staff_StaffId",
                table: "StaffRoles");

            migrationBuilder.DropIndex(
                name: "IX_StaffRoles_StaffId",
                table: "StaffRoles");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_OrderId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "ServerName",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "StaffRoles");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "Guests",
                table: "Tables",
                newName: "TableNumber");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "StaffRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "OpenedAt");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Tables",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "Tables",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staff",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClockedIn",
                table: "Staff",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Staff",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Staff",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MenuItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ServerId",
                table: "Tables",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleId",
                table: "Staff",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServerId",
                table: "Orders",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MenuItemId",
                table: "OrderItem",
                column: "MenuItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Categories_CategoryId",
                table: "MenuItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Staff_ServerId",
                table: "Orders",
                column: "ServerId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_StaffRoles_RoleId",
                table: "Staff",
                column: "RoleId",
                principalTable: "StaffRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Staff_ServerId",
                table: "Tables",
                column: "ServerId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Categories_CategoryId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Staff_ServerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_StaffRoles_RoleId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Staff_ServerId",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Tables_ServerId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Staff_RoleId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ServerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "IsClockedIn",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "TableNumber",
                table: "Tables",
                newName: "Guests");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StaffRoles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "OpenedAt",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "Tables",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tables",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ServerName",
                table: "Tables",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "Tables",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "StaffRoles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Staff",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MenuItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffRoles_StaffId",
                table: "StaffRoles",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OrderId",
                table: "MenuItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Orders_OrderId",
                table: "MenuItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRoles_Staff_StaffId",
                table: "StaffRoles",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");
        }
    }
}
