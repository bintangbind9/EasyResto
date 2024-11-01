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
                values: new object[] { new Guid("7d69d651-10d9-4d07-b489-40d6b61c4c70"), new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, true, "Admin", "AQAAAAIAAYagAAAAECz/9iguuazf1BnWy13LE8f8WR2XtLW0t8zuVJehGE2nR4tzHGCMJccWKuZo0a9Pzw==", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "FoodItemStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("9da9ce17-1337-43d9-a68b-f71e21119d50"), "NotReady", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "NotReady", null, null },
                    { new Guid("d80cdea6-af2a-4b08-8fa4-16b968c0a785"), "Ready", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Ready", null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1cafbfaa-a940-433c-b42a-aaa4f5770165"), "Closed", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Closed", null, null },
                    { new Guid("2d617a3f-6c5c-4d55-9c17-dcafaf893065"), "Canceled", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Canceled", null, null },
                    { new Guid("34e5e21f-dd77-4ee9-982e-ebf420613727"), "Cooking", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Cooking", null, null },
                    { new Guid("379d336b-83f4-46fc-8a2a-a49659e756d2"), "Delivered", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Delivered", null, null },
                    { new Guid("4b09f188-83a7-4fb1-815a-344299dfc3cd"), "Ready", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Ready", null, null },
                    { new Guid("86680acb-f53b-428d-94c7-87b1cc4f804a"), "Billed", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Billed", null, null },
                    { new Guid("cafa9bf1-3ddc-45e4-96ac-0853d3238963"), "Draft", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Draft", null, null },
                    { new Guid("e668a32f-c130-48ec-9548-de07d4b62a23"), "Requested", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Requested", null, null }
                });

            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("02953670-7941-4911-928b-f890fef16e89"), "DeleteRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteRole", null, null },
                    { new Guid("07e364f8-f3dc-4db9-8e46-dabfcf365e7b"), "ReadPrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadPrivilege", null, null },
                    { new Guid("0ac62db5-80d2-4b11-bee9-9babb566855c"), "CreateFoodItem", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateFoodItem", null, null },
                    { new Guid("12049a9d-7665-43a2-9cae-0e56a5139ae4"), "DeleteOrderDetail", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteOrderDetail", null, null },
                    { new Guid("157f4bbb-04c5-405e-b4ed-5f97f53578ca"), "DeleteFoodItem", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteFoodItem", null, null },
                    { new Guid("2c420818-5a44-40e9-8a6c-029308278366"), "UpdateFoodItem", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateFoodItem", null, null },
                    { new Guid("328b0151-939e-4dc6-87ad-a96202e62a73"), "UpdateDiningTable", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateDiningTable", null, null },
                    { new Guid("361878f1-ccee-4b4b-b10c-b2f341d79c18"), "CreateFoodItemStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateFoodItemStatus", null, null },
                    { new Guid("3a4755a3-4e8a-4974-8e5d-f6068ec871b5"), "UpdateOrderStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateOrderStatus", null, null },
                    { new Guid("3ac200d9-1e17-4bf2-90e3-3ad668dc5249"), "ReadFoodItemStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadFoodItemStatus", null, null },
                    { new Guid("4460fc0c-fc8a-4c87-b39b-a2372d00eac5"), "DeleteAppUserRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteAppUserRole", null, null },
                    { new Guid("4792d373-c7b8-43ec-9bce-bd67155fb7b3"), "ReadAppUserRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadAppUserRole", null, null },
                    { new Guid("47e6ab16-b1cc-41f0-a226-ab6a0c9f6552"), "ReadOrder", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadOrder", null, null },
                    { new Guid("55824a6c-de35-4369-930e-99a58aad9f63"), "DeleteFoodItemStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteFoodItemStatus", null, null },
                    { new Guid("5dd93a01-ae59-44f4-ae49-e9480343084f"), "DeleteFoodCategory", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteFoodCategory", null, null },
                    { new Guid("6efa2677-722f-41f9-93fe-34970e681ae7"), "DeleteOrder", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteOrder", null, null },
                    { new Guid("73ebf7a4-96e9-4265-89bc-883a20e465c9"), "ReadOrderStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadOrderStatus", null, null },
                    { new Guid("75c91442-f4c5-4da7-ab3a-5c2f74c4a4a1"), "UpdateRolePrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateRolePrivilege", null, null },
                    { new Guid("7863ef8c-ef07-41ac-b547-11c76d96b7b0"), "CreatePrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreatePrivilege", null, null },
                    { new Guid("7a809ee4-ac17-4821-8c5f-f4c237fba876"), "DeleteDiningTable", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteDiningTable", null, null },
                    { new Guid("7f715986-c418-43a4-a411-c18017b1987d"), "UpdateFoodCategory", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateFoodCategory", null, null },
                    { new Guid("835c861c-cbd3-400b-9ede-d54ef9cd6f0f"), "ReadDiningTable", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadDiningTable", null, null },
                    { new Guid("83f3b095-fd9f-450a-b07a-c369a00871d0"), "CreateRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateRole", null, null },
                    { new Guid("853a30b0-240c-4338-ac84-59bcf392dfad"), "ReadFoodItem", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadFoodItem", null, null },
                    { new Guid("873c6ef9-5bbf-4f2a-b513-fdccff8322d7"), "ReadFoodCategory", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadFoodCategory", null, null },
                    { new Guid("8adf3ce7-9dc6-485a-8f8e-31e5446a6e18"), "UpdateOrder", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateOrder", null, null },
                    { new Guid("8f8f49a4-6982-4dbd-ad21-36a64856aaa6"), "CreateOrderStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateOrderStatus", null, null },
                    { new Guid("91c8c84b-6b92-4d87-b650-3e0a042f19fb"), "CreateAppUserRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateAppUserRole", null, null },
                    { new Guid("92bd6e02-e912-4b14-b75d-482c730bd322"), "DeleteAppUser", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteAppUser", null, null },
                    { new Guid("97d7b14e-09c3-41a2-86e3-358938675a1f"), "UpdateOrderDetail", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateOrderDetail", null, null },
                    { new Guid("9ba3eea2-a2ee-4716-8dc6-f52d37f4bbc0"), "CreateFoodCategory", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateFoodCategory", null, null },
                    { new Guid("a4ac1506-7c54-4b12-9578-2225d34fe8c2"), "UpdateAppUser", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateAppUser", null, null },
                    { new Guid("aea3ff16-19ab-45d9-979d-bcbea37eeaf4"), "DeleteOrderStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteOrderStatus", null, null },
                    { new Guid("b1fc6295-b378-454e-9751-dff10a44ed01"), "DeleteRolePrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeleteRolePrivilege", null, null },
                    { new Guid("b3e5c281-3692-49e2-a8e9-e416f010f175"), "CreateOrder", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateOrder", null, null },
                    { new Guid("bb067833-81fe-4d7a-b1da-58e33e97f205"), "ReadOrderDetail", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadOrderDetail", null, null },
                    { new Guid("c30af59b-4203-414a-bda9-aeee492e28f2"), "ReadAppUser", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadAppUser", null, null },
                    { new Guid("c558c973-14a1-4d0d-9d76-c260a178e3ca"), "CreateDiningTable", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateDiningTable", null, null },
                    { new Guid("d146d210-ee8e-428d-8f54-d7690d9d4235"), "UpdateRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateRole", null, null },
                    { new Guid("d6af02d0-38d3-46f9-8f06-d6096457a780"), "UpdateFoodItemStatus", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateFoodItemStatus", null, null },
                    { new Guid("e11f15eb-947b-4852-aeec-8dd2f1ed1f5f"), "UpdatePrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdatePrivilege", null, null },
                    { new Guid("e13cad3e-9acc-4d98-af01-d22ebb771191"), "DeletePrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "DeletePrivilege", null, null },
                    { new Guid("e1730817-9d79-4298-bb63-207112ee2f74"), "CreateOrderDetail", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateOrderDetail", null, null },
                    { new Guid("e367426a-b6b7-4241-8e83-2e845a900f8c"), "UpdateAppUserRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "UpdateAppUserRole", null, null },
                    { new Guid("e8ad7df4-5c98-49e5-81c1-36892be27856"), "CreateAppUser", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateAppUser", null, null },
                    { new Guid("ebfc81be-e8f4-4928-99d0-9706f08614ec"), "ReadRole", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadRole", null, null },
                    { new Guid("eca55170-278d-4d16-9326-eae6c8682aa6"), "CreateRolePrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "CreateRolePrivilege", null, null },
                    { new Guid("f3f167c4-2265-48b1-ab38-f96508575654"), "ReadRolePrivilege", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "ReadRolePrivilege", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3dc67bb8-a873-426f-9169-cbec32767a35"), "Cashier", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Cashier", null, null },
                    { new Guid("6e053b66-5275-4191-9a02-e89080a159b8"), "Manager", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Manager", null, null },
                    { new Guid("72a035a0-11c0-49c0-8722-751c26a9312d"), "Waiter", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Waiter", null, null },
                    { new Guid("b3f0761e-ca81-4e7a-aa4b-df1a43e2cc87"), "Chef", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Chef", null, null },
                    { new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df"), "Admin", new DateTime(2024, 11, 2, 1, 33, 5, 244, DateTimeKind.Local).AddTicks(8660), "Admin", null, null, "Admin", null, null }
                });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { new Guid("7d69d651-10d9-4d07-b489-40d6b61c4c70"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "PrivilegeId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("02953670-7941-4911-928b-f890fef16e89"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("07e364f8-f3dc-4db9-8e46-dabfcf365e7b"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("0ac62db5-80d2-4b11-bee9-9babb566855c"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("12049a9d-7665-43a2-9cae-0e56a5139ae4"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("157f4bbb-04c5-405e-b4ed-5f97f53578ca"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("2c420818-5a44-40e9-8a6c-029308278366"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("328b0151-939e-4dc6-87ad-a96202e62a73"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("361878f1-ccee-4b4b-b10c-b2f341d79c18"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("3a4755a3-4e8a-4974-8e5d-f6068ec871b5"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("3ac200d9-1e17-4bf2-90e3-3ad668dc5249"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("4460fc0c-fc8a-4c87-b39b-a2372d00eac5"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("4792d373-c7b8-43ec-9bce-bd67155fb7b3"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("47e6ab16-b1cc-41f0-a226-ab6a0c9f6552"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("55824a6c-de35-4369-930e-99a58aad9f63"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("5dd93a01-ae59-44f4-ae49-e9480343084f"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("6efa2677-722f-41f9-93fe-34970e681ae7"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("73ebf7a4-96e9-4265-89bc-883a20e465c9"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("75c91442-f4c5-4da7-ab3a-5c2f74c4a4a1"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("7863ef8c-ef07-41ac-b547-11c76d96b7b0"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("7a809ee4-ac17-4821-8c5f-f4c237fba876"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("7f715986-c418-43a4-a411-c18017b1987d"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("835c861c-cbd3-400b-9ede-d54ef9cd6f0f"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("83f3b095-fd9f-450a-b07a-c369a00871d0"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("853a30b0-240c-4338-ac84-59bcf392dfad"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("873c6ef9-5bbf-4f2a-b513-fdccff8322d7"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("8adf3ce7-9dc6-485a-8f8e-31e5446a6e18"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("8f8f49a4-6982-4dbd-ad21-36a64856aaa6"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("91c8c84b-6b92-4d87-b650-3e0a042f19fb"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("92bd6e02-e912-4b14-b75d-482c730bd322"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("97d7b14e-09c3-41a2-86e3-358938675a1f"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("9ba3eea2-a2ee-4716-8dc6-f52d37f4bbc0"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("a4ac1506-7c54-4b12-9578-2225d34fe8c2"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("aea3ff16-19ab-45d9-979d-bcbea37eeaf4"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("b1fc6295-b378-454e-9751-dff10a44ed01"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("b3e5c281-3692-49e2-a8e9-e416f010f175"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("bb067833-81fe-4d7a-b1da-58e33e97f205"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("c30af59b-4203-414a-bda9-aeee492e28f2"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("c558c973-14a1-4d0d-9d76-c260a178e3ca"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("d146d210-ee8e-428d-8f54-d7690d9d4235"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("d6af02d0-38d3-46f9-8f06-d6096457a780"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("e11f15eb-947b-4852-aeec-8dd2f1ed1f5f"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("e13cad3e-9acc-4d98-af01-d22ebb771191"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("e1730817-9d79-4298-bb63-207112ee2f74"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("e367426a-b6b7-4241-8e83-2e845a900f8c"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("e8ad7df4-5c98-49e5-81c1-36892be27856"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("ebfc81be-e8f4-4928-99d0-9706f08614ec"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("eca55170-278d-4d16-9326-eae6c8682aa6"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") },
                    { new Guid("f3f167c4-2265-48b1-ab38-f96508575654"), new Guid("e127c09f-c9eb-4a10-89cf-669462a7a2df") }
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
