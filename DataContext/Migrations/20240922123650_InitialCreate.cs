using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillNumber = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    ChefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChefName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChefLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.ChefId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodItemsId);
                });

            migrationBuilder.CreateTable(
                name: "HouseKeeping",
                columns: table => new
                {
                    HouseKeepingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseKeepingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseKeepingLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseKeeping", x => x.HouseKeepingId);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManagerVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "ReceptionistManager",
                columns: table => new
                {
                    ReceptionistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptionistName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReceptionistLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceptionistPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionistManager", x => x.ReceptionistId);
                    table.ForeignKey(
                        name: "FK_ReceptionistManager_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChefFoodItems",
                columns: table => new
                {
                    ChefsChefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefFoodItems", x => new { x.ChefsChefId, x.FoodItemsId });
                    table.ForeignKey(
                        name: "FK_ChefFoodItems_Chef_ChefsChefId",
                        column: x => x.ChefsChefId,
                        principalTable: "Chef",
                        principalColumn: "ChefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChefFoodItems_FoodItems_FoodItemsId",
                        column: x => x.FoodItemsId,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    GuestAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestRoomNumber = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guest_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guest_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InventoryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefFoodItems_FoodItemsId",
                table: "ChefFoodItems",
                column: "FoodItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_BillId",
                table: "Guest",
                column: "BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_ManagerId",
                table: "Guest",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ManagerId",
                table: "Inventory",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionistManager_BillId",
                table: "ReceptionistManager",
                column: "BillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefFoodItems");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "HouseKeeping");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "ReceptionistManager");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}
