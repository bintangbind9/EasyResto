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
                    CashierNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                values: new object[] { new Guid("3079f683-d7b6-4b97-98a2-fe592ad6a509"), new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, true, "Admin", "AQAAAAIAAYagAAAAECQ4QIFAO5570Ed/GbPUk2FBareVyXYc1uGln9Jlatws2iXcqNT7sJSwmO1X6Bas/Q==", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "FoodItemStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("8edf589a-665d-4625-8a78-88c71774eb12"), "NotReady", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "NotReady", null, null },
                    { new Guid("aa4b811e-0244-4d0e-829f-a846b4f7d7a6"), "Ready", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Ready", null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("049b015e-4072-4255-999b-2d4de9eac527"), "Billed", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Billed", null, null },
                    { new Guid("298fc1bc-c2c2-4c82-adf1-1f54ecaab704"), "Draft", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Draft", null, null },
                    { new Guid("34c98e4a-d2f6-4d59-a335-ce003cc7e530"), "Ready", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Ready", null, null },
                    { new Guid("7efe4fe2-b632-4939-8d97-c047f2081f44"), "Delivered", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Delivered", null, null },
                    { new Guid("8437d6a8-8086-4d06-b238-94864878f63d"), "Closed", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Closed", null, null },
                    { new Guid("b09a5bab-f1cc-4d48-ad6e-6eef967ee385"), "Requested", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Requested", null, null },
                    { new Guid("ca0c4fee-be3f-4eb3-a6cf-a1fcf9178d37"), "Cooking", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Cooking", null, null },
                    { new Guid("ffa97289-3146-4fe8-8ec6-3fe831169fe0"), "Canceled", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Canceled", null, null }
                });

            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0679d002-4e9d-44e6-ac72-f6cf1d25e065"), "UpdateAppUserRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateAppUserRole", null, null },
                    { new Guid("121f05fe-3da2-4df0-872a-147e4f2c7e93"), "ReadOrderStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadOrderStatus", null, null },
                    { new Guid("2049944c-9073-440b-95e9-22a8713e52a5"), "DeleteAppUser", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteAppUser", null, null },
                    { new Guid("2571d215-363d-472d-aae2-acd058f279ba"), "ReadAppUserRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadAppUserRole", null, null },
                    { new Guid("31f0bb9c-8abd-4028-b3f7-e415c6f7371e"), "DeleteOrder", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteOrder", null, null },
                    { new Guid("3515c51f-2e60-45f0-b304-ce5a1a3746ec"), "CreateRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateRole", null, null },
                    { new Guid("371fa317-b00b-403d-adef-d7c4dda135be"), "DeleteOrderDetail", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteOrderDetail", null, null },
                    { new Guid("383c4489-e4dd-448b-a37d-2894cff5964a"), "CreateOrderStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateOrderStatus", null, null },
                    { new Guid("39aa6148-a9c6-4ad4-b3e3-6c92ba890798"), "CreateOrderDetail", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateOrderDetail", null, null },
                    { new Guid("45f48cbe-c78a-43d1-8d78-a574390ad4d3"), "UpdateDiningTable", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateDiningTable", null, null },
                    { new Guid("4804446e-796a-4c6a-8c6c-a2584d05ac20"), "DeleteFoodItemStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteFoodItemStatus", null, null },
                    { new Guid("4e255c75-f050-414f-9221-65c78cf47dee"), "CreateAppUserRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateAppUserRole", null, null },
                    { new Guid("537de7f1-e29c-4ea6-b32f-63817556520a"), "DeleteAppUserRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteAppUserRole", null, null },
                    { new Guid("5454ca03-50aa-4513-b01d-32c096610d66"), "UpdateOrderDetail", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateOrderDetail", null, null },
                    { new Guid("55746de5-dcad-4fca-9886-44cc4d42e5d9"), "ReadFoodItemStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadFoodItemStatus", null, null },
                    { new Guid("5ad3e208-041a-46bf-b4d5-e6b087f3e744"), "DeleteRolePrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteRolePrivilege", null, null },
                    { new Guid("5cc661ea-f7fa-4fe4-9d95-0587e5161400"), "UpdateOrder", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateOrder", null, null },
                    { new Guid("619abad8-6e70-496c-950b-01717b415cb8"), "UpdateFoodCategory", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateFoodCategory", null, null },
                    { new Guid("6c90b6da-49f4-4474-9e8e-76bf41a1716e"), "ReadOrder", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadOrder", null, null },
                    { new Guid("7398c034-28a3-4881-9c8f-ebb53eaf56d7"), "DeleteOrderStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteOrderStatus", null, null },
                    { new Guid("7d1ee991-f109-4b0c-9233-65d997d20a6e"), "CreatePrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreatePrivilege", null, null },
                    { new Guid("7df546c9-bca9-42fe-a4f8-776436db2ece"), "UpdateOrderStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateOrderStatus", null, null },
                    { new Guid("87bbf8fe-cfde-4e42-a44c-69a7b234123d"), "CreateFoodItemStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateFoodItemStatus", null, null },
                    { new Guid("8973b4b8-e80d-40ca-9419-4da95745a0f5"), "DeletePrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeletePrivilege", null, null },
                    { new Guid("983f42b1-2d08-48cf-900e-558b36305d84"), "UpdateFoodItemStatus", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateFoodItemStatus", null, null },
                    { new Guid("9a5198b4-ef68-450a-bf1c-6a14c8db5a81"), "ReadOrderDetail", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadOrderDetail", null, null },
                    { new Guid("a4de6b58-b8e8-4830-b920-16204cb9e736"), "ReadPrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadPrivilege", null, null },
                    { new Guid("aed01930-2411-4be4-87d9-7602e83d3238"), "ReadFoodItem", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadFoodItem", null, null },
                    { new Guid("afd6a22b-3f3e-42ef-810f-8c5813211d9b"), "UpdateFoodItem", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateFoodItem", null, null },
                    { new Guid("b15eed2f-d563-4f2f-b4c9-2797b75b4370"), "ReadAppUser", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadAppUser", null, null },
                    { new Guid("b595be53-f67c-44ba-897f-6b2d3d05ab94"), "DeleteRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteRole", null, null },
                    { new Guid("bb6939e0-81b8-4e7e-80a4-4e5a9ecdf81f"), "UpdateRolePrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateRolePrivilege", null, null },
                    { new Guid("bd2ff3bd-6ffe-4533-a0f6-eccb06eb4e5f"), "CreateOrder", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateOrder", null, null },
                    { new Guid("bfc01c87-ed46-4057-a941-e2a0d92d78b7"), "ReadRolePrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadRolePrivilege", null, null },
                    { new Guid("c716c609-04de-4cf0-a7ab-7c6762fb3fcb"), "CreateRolePrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateRolePrivilege", null, null },
                    { new Guid("d0033d57-f30c-4c85-aab5-b906725ab207"), "UpdateRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateRole", null, null },
                    { new Guid("d4d373de-a8cd-434b-a117-e15b8b06f46b"), "ReadRole", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadRole", null, null },
                    { new Guid("d710e7f7-e95e-430a-ac3b-12e270aeeb1b"), "CreateAppUser", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateAppUser", null, null },
                    { new Guid("d8df5ad7-7dde-46a2-8775-b2b2e62f92c2"), "UpdateAppUser", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdateAppUser", null, null },
                    { new Guid("d963d27c-73f5-4e67-8a64-42be8e66edde"), "UpdatePrivilege", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "UpdatePrivilege", null, null },
                    { new Guid("dde87dc2-b943-4a2e-adcb-4761069949fc"), "DeleteDiningTable", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteDiningTable", null, null },
                    { new Guid("de89c867-4c3d-4b80-bb57-520c738622fb"), "CreateFoodItem", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateFoodItem", null, null },
                    { new Guid("e040c8c5-f283-4169-9ead-9244e458fbc3"), "DeleteFoodItem", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteFoodItem", null, null },
                    { new Guid("ed6a52c7-816a-4c62-95af-d9bb02001290"), "CreateDiningTable", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateDiningTable", null, null },
                    { new Guid("ee99cb88-eaf1-4b14-a566-293d324ddfee"), "ReadDiningTable", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadDiningTable", null, null },
                    { new Guid("f2ebaaa5-c0ec-428a-a4c9-e22ac93e8b31"), "ReadFoodCategory", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "ReadFoodCategory", null, null },
                    { new Guid("f7557465-0327-406d-9368-f97749b9a817"), "CreateFoodCategory", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "CreateFoodCategory", null, null },
                    { new Guid("f901ddab-17ea-4d7c-a1a0-29850993bbbf"), "DeleteFoodCategory", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "DeleteFoodCategory", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487"), "Admin", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Admin", null, null },
                    { new Guid("0d7be661-df63-43c7-abaa-fc32458ccd80"), "Waiter", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Waiter", null, null },
                    { new Guid("52989699-15e2-4663-96e6-01a0811adffa"), "Cashier", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Cashier", null, null },
                    { new Guid("5d49ae3a-765f-4ad3-a127-ddfae0708ae9"), "Chef", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Chef", null, null },
                    { new Guid("86c57788-272a-4c06-8d13-f99eceb01e45"), "Manager", new DateTime(2024, 10, 23, 10, 36, 51, 997, DateTimeKind.Local).AddTicks(5688), "Admin", null, null, "Manager", null, null }
                });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { new Guid("3079f683-d7b6-4b97-98a2-fe592ad6a509"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "PrivilegeId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0679d002-4e9d-44e6-ac72-f6cf1d25e065"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("121f05fe-3da2-4df0-872a-147e4f2c7e93"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("2049944c-9073-440b-95e9-22a8713e52a5"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("2571d215-363d-472d-aae2-acd058f279ba"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("31f0bb9c-8abd-4028-b3f7-e415c6f7371e"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("3515c51f-2e60-45f0-b304-ce5a1a3746ec"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("371fa317-b00b-403d-adef-d7c4dda135be"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("383c4489-e4dd-448b-a37d-2894cff5964a"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("39aa6148-a9c6-4ad4-b3e3-6c92ba890798"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("45f48cbe-c78a-43d1-8d78-a574390ad4d3"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("4804446e-796a-4c6a-8c6c-a2584d05ac20"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("4e255c75-f050-414f-9221-65c78cf47dee"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("537de7f1-e29c-4ea6-b32f-63817556520a"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("5454ca03-50aa-4513-b01d-32c096610d66"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("55746de5-dcad-4fca-9886-44cc4d42e5d9"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("5ad3e208-041a-46bf-b4d5-e6b087f3e744"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("5cc661ea-f7fa-4fe4-9d95-0587e5161400"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("619abad8-6e70-496c-950b-01717b415cb8"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("6c90b6da-49f4-4474-9e8e-76bf41a1716e"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("7398c034-28a3-4881-9c8f-ebb53eaf56d7"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("7d1ee991-f109-4b0c-9233-65d997d20a6e"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("7df546c9-bca9-42fe-a4f8-776436db2ece"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("87bbf8fe-cfde-4e42-a44c-69a7b234123d"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("8973b4b8-e80d-40ca-9419-4da95745a0f5"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("983f42b1-2d08-48cf-900e-558b36305d84"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("9a5198b4-ef68-450a-bf1c-6a14c8db5a81"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("a4de6b58-b8e8-4830-b920-16204cb9e736"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("aed01930-2411-4be4-87d9-7602e83d3238"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("afd6a22b-3f3e-42ef-810f-8c5813211d9b"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("b15eed2f-d563-4f2f-b4c9-2797b75b4370"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("b595be53-f67c-44ba-897f-6b2d3d05ab94"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("bb6939e0-81b8-4e7e-80a4-4e5a9ecdf81f"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("bd2ff3bd-6ffe-4533-a0f6-eccb06eb4e5f"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("bfc01c87-ed46-4057-a941-e2a0d92d78b7"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("c716c609-04de-4cf0-a7ab-7c6762fb3fcb"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("d0033d57-f30c-4c85-aab5-b906725ab207"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("d4d373de-a8cd-434b-a117-e15b8b06f46b"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("d710e7f7-e95e-430a-ac3b-12e270aeeb1b"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("d8df5ad7-7dde-46a2-8775-b2b2e62f92c2"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("d963d27c-73f5-4e67-8a64-42be8e66edde"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("dde87dc2-b943-4a2e-adcb-4761069949fc"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("de89c867-4c3d-4b80-bb57-520c738622fb"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("e040c8c5-f283-4169-9ead-9244e458fbc3"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("ed6a52c7-816a-4c62-95af-d9bb02001290"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("ee99cb88-eaf1-4b14-a566-293d324ddfee"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("f2ebaaa5-c0ec-428a-a4c9-e22ac93e8b31"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("f7557465-0327-406d-9368-f97749b9a817"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") },
                    { new Guid("f901ddab-17ea-4d7c-a1a0-29850993bbbf"), new Guid("0c43562f-49c6-47b3-bb27-bd48083eb487") }
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
