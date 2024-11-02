using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyResto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiningTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiningTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItem_FoodCategory_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodItem_FoodItemStatus_FoodItemStatusId",
                        column: x => x.FoodItemStatusId,
                        principalTable: "FoodItemStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiningTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChefId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CashierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    BillAmount = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    CashierNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AppUser_CashierId",
                        column: x => x.CashierId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_AppUser_ChefId",
                        column: x => x.ChefId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_AppUser_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_DiningTable_DiningTableId",
                        column: x => x.DiningTableId,
                        principalTable: "DiningTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => new { x.AppUserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePrivilege",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivilege", x => new { x.RoleId, x.PrivilegeId });
                    table.ForeignKey(
                        name: "FK_RolePrivilege_Privilege_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privilege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePrivilege_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_FoodItem_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "Name", "Password", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[] { new Guid("a8d1173d-9a5f-4f82-8813-92e6839294a6"), new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, true, "Admin", "AQAAAAIAAYagAAAAEKfBzOzKhLbtqTO8uB0DmX/NFmMl02PKZzKnIIezbbrjzZvZy9P6jNskLvAB75JHeA==", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "FoodItemStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7377974e-3629-4990-98b6-c5a2faf5e9b6"), "Ready", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Ready", null, null },
                    { new Guid("fb7c7af4-d568-41c4-b7b5-f3575eb411dc"), "NotReady", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "NotReady", null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("462cb6aa-e23b-4283-8f67-c502114541be"), "Requested", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Requested", null, null },
                    { new Guid("94450abd-0093-49ac-bf44-95cd9c017406"), "Cooking", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Cooking", null, null },
                    { new Guid("affb5a4e-bd68-4082-8afd-f2702f9568bf"), "Ready", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Ready", null, null },
                    { new Guid("d66b2719-964a-4b28-8cb6-01452cfe5963"), "Closed", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Closed", null, null },
                    { new Guid("e772e758-422c-43c8-8ea3-c391dd4b2457"), "Canceled", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Canceled", null, null },
                    { new Guid("ebc2f25b-abc8-47b7-8de3-5665738bfbee"), "Delivered", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Delivered", null, null },
                    { new Guid("ef106a12-7088-4992-bcd3-081458c04fc6"), "Billed", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Billed", null, null },
                    { new Guid("f531adc8-62f3-4f91-837f-ab99072a7f21"), "Draft", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Draft", null, null }
                });

            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("114fde07-f6bd-4e91-a889-41793a0d6818"), "CreateFoodItemStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateFoodItemStatus", null, null },
                    { new Guid("1ab1c266-19c5-4b67-8f49-fb403953a02c"), "CreateFoodItem", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateFoodItem", null, null },
                    { new Guid("1cdf2278-4256-4642-88ec-0df5262af750"), "UpdateAppUser", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateAppUser", null, null },
                    { new Guid("1e13a11d-c6e9-46b3-90aa-99aef3192f6f"), "CreatePrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreatePrivilege", null, null },
                    { new Guid("2923cf19-759c-4080-82b1-faca8028360c"), "CreateAppUser", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateAppUser", null, null },
                    { new Guid("2b7f481f-1aa2-4a31-b9e2-3beb01714f0e"), "DeleteOrderStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteOrderStatus", null, null },
                    { new Guid("3282e59f-48e4-4c42-aa67-30a1071fd8c6"), "ReadPrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadPrivilege", null, null },
                    { new Guid("329147fa-c7a3-4353-9873-b4d81700b880"), "ReceivePayment", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReceivePayment", null, null },
                    { new Guid("3558d898-5db5-46b2-8d12-8c98bc8dbdba"), "ReadOrderStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadOrderStatus", null, null },
                    { new Guid("361ddfa1-6d99-4d9d-9e25-6da34a13b553"), "DeleteFoodItemStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteFoodItemStatus", null, null },
                    { new Guid("3736b207-620f-4d84-860a-1fc616213dc6"), "DeleteAppUser", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteAppUser", null, null },
                    { new Guid("3c167e42-79df-42af-8b01-14ef41e10747"), "CloseOrder", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CloseOrder", null, null },
                    { new Guid("3d4fb91d-5133-4d44-8265-53adf26cd832"), "ReadOrderDetail", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadOrderDetail", null, null },
                    { new Guid("3e3761f4-abf0-47eb-97fa-f868406514b4"), "CreateOrderStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateOrderStatus", null, null },
                    { new Guid("468af6af-3689-4ec8-b3ea-35b17d3ca385"), "ReadOrder", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadOrder", null, null },
                    { new Guid("4eb330db-c9af-43e7-8bf3-12d95d211dcf"), "ReadFoodCategory", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadFoodCategory", null, null },
                    { new Guid("585992f0-4d11-4e0e-9c46-824afca13494"), "DeleteAppUserRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteAppUserRole", null, null },
                    { new Guid("6427b81c-904e-4271-82b7-2d4cf8645914"), "DeleteOrder", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteOrder", null, null },
                    { new Guid("66cd272a-fa2b-48c3-afa5-ca9aa9780211"), "CreateRolePrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateRolePrivilege", null, null },
                    { new Guid("68391ecb-2345-4041-8847-8149e9ab3713"), "CreateOrder", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateOrder", null, null },
                    { new Guid("6850375b-4b33-421d-8b4b-1e96a556ba33"), "ReadRolePrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadRolePrivilege", null, null },
                    { new Guid("6e60b22c-c98a-4901-8692-40f68963473f"), "CookOrder", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CookOrder", null, null },
                    { new Guid("721fe0b1-0e96-42cc-81a9-64f8fd70110a"), "UpdateDiningTable", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateDiningTable", null, null },
                    { new Guid("75326d29-9314-4efe-b668-f7086eed4551"), "CreateAppUserRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateAppUserRole", null, null },
                    { new Guid("8ce5bc42-1c09-4880-92a9-1f4a2bfb0335"), "DeleteDiningTable", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteDiningTable", null, null },
                    { new Guid("8df5f7c9-320d-4650-a9b5-7eb286fd5217"), "ReadDiningTable", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadDiningTable", null, null },
                    { new Guid("96a2b8e1-0138-4bb7-bf78-a00cf401cffc"), "DeliveryOrder", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeliveryOrder", null, null },
                    { new Guid("9a7beb21-c1b7-43d3-bc9a-dc0b4c705e8b"), "ReadAppUserRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadAppUserRole", null, null },
                    { new Guid("9c3ddaff-4157-4c1d-bad0-b2aac76d3c59"), "UpdateRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateRole", null, null },
                    { new Guid("aaf58290-5d58-4d5b-814a-389c8018eed9"), "UpdateOrderStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateOrderStatus", null, null },
                    { new Guid("ad72e9f0-5cb4-431e-b9c5-f096d2cf6fb9"), "ReadAppUser", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadAppUser", null, null },
                    { new Guid("aecf04a9-6569-44f9-9ce8-60570bdf227f"), "UpdatePrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdatePrivilege", null, null },
                    { new Guid("b2cd0181-f0bb-4ecc-91d3-8884c16bd0e1"), "DeleteFoodItem", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteFoodItem", null, null },
                    { new Guid("b3089260-52c1-4de7-b520-427e325480d5"), "UpdateOrder", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateOrder", null, null },
                    { new Guid("b724cf18-f503-4c35-9978-736c8151cb99"), "DeletePrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeletePrivilege", null, null },
                    { new Guid("bafdea1d-7c77-4a6a-a80b-d17447622e37"), "ReadFoodItemStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadFoodItemStatus", null, null },
                    { new Guid("c24041c7-a974-4fb1-9f9c-1ace60fe1405"), "UpdateRolePrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateRolePrivilege", null, null },
                    { new Guid("c3600a39-2331-4b80-b313-df2a2b7caac2"), "DeleteFoodCategory", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteFoodCategory", null, null },
                    { new Guid("c4e4f1dd-3c55-48d4-8e62-3b2869696607"), "UpdateOrderDetail", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateOrderDetail", null, null },
                    { new Guid("c6231a2f-f75e-4afb-a65d-1dd734ab055f"), "UpdateAppUserRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateAppUserRole", null, null },
                    { new Guid("ca150491-4ac1-4cbe-b3f0-9ae071cd0918"), "CreateOrderDetail", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateOrderDetail", null, null },
                    { new Guid("d0105568-c630-430d-ba04-756f2f6f4337"), "CreateRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateRole", null, null },
                    { new Guid("d0f055c8-230c-4438-b782-c80fdd8ce851"), "DeleteOrderDetail", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteOrderDetail", null, null },
                    { new Guid("db77bb89-6f2d-410c-92ef-10a5f1dc4b66"), "ReadFoodItem", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadFoodItem", null, null },
                    { new Guid("dc277ec0-2dec-42d0-bcf0-63b13f6bdfd8"), "UpdateFoodCategory", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateFoodCategory", null, null },
                    { new Guid("dfd148fa-0e23-48e6-a332-aaad4633425d"), "DeleteRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteRole", null, null },
                    { new Guid("e0401111-321a-4342-ba99-63ee0a8f2d93"), "CreateDiningTable", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateDiningTable", null, null },
                    { new Guid("e2362b6d-7237-4985-8db4-e38e55e4d594"), "UpdateFoodItem", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateFoodItem", null, null },
                    { new Guid("e52af567-a2c1-4e33-b8c8-9fe75f328813"), "CreateFoodCategory", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "CreateFoodCategory", null, null },
                    { new Guid("e7812636-a67d-4b28-b9b4-116ba08c4479"), "DeleteRolePrivilege", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "DeleteRolePrivilege", null, null },
                    { new Guid("e89cae8f-fb40-4f88-bdd7-63c5f410afd1"), "ReadRole", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "ReadRole", null, null },
                    { new Guid("f243dac1-d66a-480f-bd02-229e50e79011"), "UpdateFoodItemStatus", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "UpdateFoodItemStatus", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("155586db-3459-4f49-847d-eb211a1812f3"), "Admin", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Admin", null, null },
                    { new Guid("307a115f-b6af-4956-a456-8a179d7484f8"), "Cashier", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Cashier", null, null },
                    { new Guid("3f842bd0-edb1-4fbd-a007-ea3cb822e5bd"), "Chef", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Chef", null, null },
                    { new Guid("592a30e6-4791-4381-85d2-b40c1a0f2254"), "Manager", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Manager", null, null },
                    { new Guid("86a2d0c2-caf0-47d3-aa79-a59d23619e73"), "Waiter", new DateTime(2024, 11, 2, 15, 43, 49, 979, DateTimeKind.Local).AddTicks(2339), "Admin", null, null, "Waiter", null, null }
                });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { new Guid("a8d1173d-9a5f-4f82-8813-92e6839294a6"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "PrivilegeId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("114fde07-f6bd-4e91-a889-41793a0d6818"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("1ab1c266-19c5-4b67-8f49-fb403953a02c"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("1cdf2278-4256-4642-88ec-0df5262af750"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("1e13a11d-c6e9-46b3-90aa-99aef3192f6f"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("2923cf19-759c-4080-82b1-faca8028360c"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("2b7f481f-1aa2-4a31-b9e2-3beb01714f0e"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("3282e59f-48e4-4c42-aa67-30a1071fd8c6"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("329147fa-c7a3-4353-9873-b4d81700b880"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("3558d898-5db5-46b2-8d12-8c98bc8dbdba"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("361ddfa1-6d99-4d9d-9e25-6da34a13b553"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("3736b207-620f-4d84-860a-1fc616213dc6"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("3c167e42-79df-42af-8b01-14ef41e10747"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("3d4fb91d-5133-4d44-8265-53adf26cd832"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("3e3761f4-abf0-47eb-97fa-f868406514b4"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("468af6af-3689-4ec8-b3ea-35b17d3ca385"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("4eb330db-c9af-43e7-8bf3-12d95d211dcf"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("585992f0-4d11-4e0e-9c46-824afca13494"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("6427b81c-904e-4271-82b7-2d4cf8645914"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("66cd272a-fa2b-48c3-afa5-ca9aa9780211"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("68391ecb-2345-4041-8847-8149e9ab3713"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("6850375b-4b33-421d-8b4b-1e96a556ba33"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("6e60b22c-c98a-4901-8692-40f68963473f"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("721fe0b1-0e96-42cc-81a9-64f8fd70110a"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("75326d29-9314-4efe-b668-f7086eed4551"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("8ce5bc42-1c09-4880-92a9-1f4a2bfb0335"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("8df5f7c9-320d-4650-a9b5-7eb286fd5217"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("96a2b8e1-0138-4bb7-bf78-a00cf401cffc"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("9a7beb21-c1b7-43d3-bc9a-dc0b4c705e8b"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("9c3ddaff-4157-4c1d-bad0-b2aac76d3c59"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("aaf58290-5d58-4d5b-814a-389c8018eed9"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("ad72e9f0-5cb4-431e-b9c5-f096d2cf6fb9"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("aecf04a9-6569-44f9-9ce8-60570bdf227f"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("b2cd0181-f0bb-4ecc-91d3-8884c16bd0e1"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("b3089260-52c1-4de7-b520-427e325480d5"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("b724cf18-f503-4c35-9978-736c8151cb99"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("bafdea1d-7c77-4a6a-a80b-d17447622e37"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("c24041c7-a974-4fb1-9f9c-1ace60fe1405"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("c3600a39-2331-4b80-b313-df2a2b7caac2"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("c4e4f1dd-3c55-48d4-8e62-3b2869696607"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("c6231a2f-f75e-4afb-a65d-1dd734ab055f"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("ca150491-4ac1-4cbe-b3f0-9ae071cd0918"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("d0105568-c630-430d-ba04-756f2f6f4337"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("d0f055c8-230c-4438-b782-c80fdd8ce851"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("db77bb89-6f2d-410c-92ef-10a5f1dc4b66"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("dc277ec0-2dec-42d0-bcf0-63b13f6bdfd8"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("dfd148fa-0e23-48e6-a332-aaad4633425d"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("e0401111-321a-4342-ba99-63ee0a8f2d93"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("e2362b6d-7237-4985-8db4-e38e55e4d594"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("e52af567-a2c1-4e33-b8c8-9fe75f328813"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("e7812636-a67d-4b28-b9b4-116ba08c4479"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("e89cae8f-fb40-4f88-bdd7-63c5f410afd1"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") },
                    { new Guid("f243dac1-d66a-480f-bd02-229e50e79011"), new Guid("155586db-3459-4f49-847d-eb211a1812f3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Username",
                table: "AppUser",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RoleId",
                table: "AppUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningTable_Code",
                table: "DiningTable",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategory_Code",
                table: "FoodCategory",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_Code",
                table: "FoodItem",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_FoodCategoryId",
                table: "FoodItem",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_FoodItemStatusId",
                table: "FoodItem",
                column: "FoodItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemStatus_Code",
                table: "FoodItemStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CashierId",
                table: "Order",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ChefId",
                table: "Order",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Code",
                table: "Order",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DiningTableId",
                table: "Order",
                column: "DiningTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WaiterId",
                table: "Order",
                column: "WaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_FoodItemId",
                table: "OrderDetail",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_Code",
                table: "OrderStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_Code",
                table: "Privilege",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Code",
                table: "Role",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivilege_PrivilegeId",
                table: "RolePrivilege",
                column: "PrivilegeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "RolePrivilege");

            migrationBuilder.DropTable(
                name: "FoodItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "FoodCategory");

            migrationBuilder.DropTable(
                name: "FoodItemStatus");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "DiningTable");

            migrationBuilder.DropTable(
                name: "OrderStatus");
        }
    }
}
