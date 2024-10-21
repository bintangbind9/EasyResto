using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyResto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "Name", "Password", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[] { new Guid("b4834d25-fdb0-420e-9201-eefaa2d61ee5"), new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, true, "Admin", "AQAAAAIAAYagAAAAEAWU2uDAa2OfNJScHxyH8fR9kmnLNPqBji+KFrdqR/oSeYH6AOBy4wm894/3eEQF3g==", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "FoodItemStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("548c763a-f7e4-4a22-8c25-bae275fb2c4b"), "NotReady", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "NotReady", null, null },
                    { new Guid("cabc0a34-4ce6-4eba-bfd1-0321538c3d7f"), "Ready", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Ready", null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("070e1ba3-8eb8-40ba-a661-695b49890252"), "Canceled", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Canceled", null, null },
                    { new Guid("0ecf549a-5fa0-4b1c-85b4-0b9d50079ce3"), "Cooking", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Cooking", null, null },
                    { new Guid("4dc62fd3-b3c5-4ce1-b349-11002bedf363"), "Delivered", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Delivered", null, null },
                    { new Guid("80344bd1-fd91-4a56-9f25-cab6ef02007f"), "Billed", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Billed", null, null },
                    { new Guid("94f5c8c5-93e1-4513-ae10-431fd28f68a8"), "Draft", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Draft", null, null },
                    { new Guid("aeb883ff-29cf-4141-872a-19111fc2569f"), "Requested", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Requested", null, null },
                    { new Guid("b0e424f8-2a6f-4cbb-844e-c3938d06c33f"), "Closed", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Closed", null, null },
                    { new Guid("f94741b4-0e99-46f9-8269-ddb5402a24f0"), "Ready", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Ready", null, null }
                });

            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0a843b50-50fe-472d-8c53-9edf0f5a72ed"), "DeleteDiningTable", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteDiningTable", null, null },
                    { new Guid("0c837a3e-9c25-4f8a-b53e-b88f88e09747"), "CreateOrderStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateOrderStatus", null, null },
                    { new Guid("0e071527-57a4-40ac-85b4-6fe8ae689f03"), "CreateRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateRole", null, null },
                    { new Guid("1252ca85-8129-410f-bbbe-d18cd38ffc20"), "UpdateAppUser", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateAppUser", null, null },
                    { new Guid("2a04f504-ded9-4321-bf4a-6394a8d68e34"), "DeletePrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeletePrivilege", null, null },
                    { new Guid("2b67f1c1-9706-47df-b8e2-de436ec15c96"), "ReadPrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadPrivilege", null, null },
                    { new Guid("2c670fcb-5962-4645-9b98-a2a11ea9b24c"), "DeleteAppUserRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteAppUserRole", null, null },
                    { new Guid("30210652-72da-4e5f-8b17-bb789498eeed"), "ReadFoodItem", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadFoodItem", null, null },
                    { new Guid("307d782b-4566-468d-9e6a-80076d811609"), "DeleteFoodCategory", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteFoodCategory", null, null },
                    { new Guid("30cb8b12-ffa9-44d3-a622-10ee055a7eea"), "UpdateFoodCategory", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateFoodCategory", null, null },
                    { new Guid("34785b0d-55ef-4d18-9154-91dd65e49869"), "DeleteOrderDetail", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteOrderDetail", null, null },
                    { new Guid("365933ef-f682-4e7c-8e3b-2c0fed8a51bb"), "ReadFoodCategory", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadFoodCategory", null, null },
                    { new Guid("384275e8-8481-42f8-96f1-f294d5576e5b"), "CreateOrder", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateOrder", null, null },
                    { new Guid("3af8ff36-926e-46dc-8f68-42c0743147e1"), "UpdateRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateRole", null, null },
                    { new Guid("3e686c9d-f5ad-4293-85ad-9bdaf7f8be00"), "DeleteRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteRole", null, null },
                    { new Guid("51b21093-4f59-4718-98ee-c5f6f7246bb6"), "ReadDiningTable", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadDiningTable", null, null },
                    { new Guid("55fe2fb0-d0e6-435a-95a2-c7a4128e348d"), "UpdateOrderDetail", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateOrderDetail", null, null },
                    { new Guid("5adaa260-8fe9-47d4-bd55-899953cd17b7"), "ReadRolePrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadRolePrivilege", null, null },
                    { new Guid("63080caa-640e-4d43-b8ea-4df8a8d34f9e"), "UpdateDiningTable", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateDiningTable", null, null },
                    { new Guid("6329652f-ea64-424b-a65d-05fbccdb9e79"), "DeleteFoodItemStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteFoodItemStatus", null, null },
                    { new Guid("638261bc-cc9e-4a8e-b506-9cd00cf655cc"), "ReadOrderDetail", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadOrderDetail", null, null },
                    { new Guid("673ed6ba-ab67-49d5-bd68-bdc53ac36f89"), "DeleteFoodItem", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteFoodItem", null, null },
                    { new Guid("67534680-8527-4653-8109-dc38ff034066"), "ReadOrder", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadOrder", null, null },
                    { new Guid("6abfbbc8-f52c-4ac4-8a8d-39a2a9b699b1"), "CreatePrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreatePrivilege", null, null },
                    { new Guid("6b06be71-c0fd-4f1a-8475-27d49df94885"), "CreateRolePrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateRolePrivilege", null, null },
                    { new Guid("6c4fc91c-af56-4b3c-bd40-cbf1298f9b86"), "CreateDiningTable", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateDiningTable", null, null },
                    { new Guid("6e9a9935-9db3-4951-8d6b-12f3618389fe"), "ReadFoodItemStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadFoodItemStatus", null, null },
                    { new Guid("6f8b1a9f-abd9-454b-bbb7-8bf207f318d1"), "UpdateOrder", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateOrder", null, null },
                    { new Guid("70d2b2e0-5afe-45d3-998d-ae3a03c56506"), "UpdateFoodItem", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateFoodItem", null, null },
                    { new Guid("71256737-da55-4613-b5a7-637b47c9ee77"), "DeleteOrder", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteOrder", null, null },
                    { new Guid("765942b5-69f6-417b-9901-3e55cbdaf1c4"), "DeleteRolePrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteRolePrivilege", null, null },
                    { new Guid("7cd2c8af-619c-4916-b771-46ca92a3f00b"), "CreateOrderDetail", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateOrderDetail", null, null },
                    { new Guid("7feafffa-bf03-425f-b16e-ba0ba930eb42"), "CreateAppUser", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateAppUser", null, null },
                    { new Guid("91fd1296-1de6-4343-a50c-dd12426c3c60"), "ReadAppUser", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadAppUser", null, null },
                    { new Guid("92e0322c-6371-45c8-8d11-4775244a6eb7"), "UpdateAppUserRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateAppUserRole", null, null },
                    { new Guid("97e18b76-e10d-4e81-83ac-a7ade5d3f3b4"), "CreateAppUserRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateAppUserRole", null, null },
                    { new Guid("98bb84d5-b3a3-4a2a-adc1-33191972f50c"), "UpdatePrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdatePrivilege", null, null },
                    { new Guid("a8b7fce3-0c10-4997-b389-215fb8751379"), "DeleteOrderStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteOrderStatus", null, null },
                    { new Guid("ac04d0a3-34be-40d2-a3ce-1c2cfe9a0451"), "ReadOrderStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadOrderStatus", null, null },
                    { new Guid("af646771-acda-44dc-8e6f-ef0c70531659"), "UpdateFoodItemStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateFoodItemStatus", null, null },
                    { new Guid("c7eca966-f6d9-45c3-98c8-8f9b1f7051be"), "CreateFoodItemStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateFoodItemStatus", null, null },
                    { new Guid("cd7fea40-5954-4f09-bc6a-a94988c0d0fa"), "ReadRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadRole", null, null },
                    { new Guid("dd2577a6-24f4-4f93-b91c-93678dd58559"), "UpdateRolePrivilege", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateRolePrivilege", null, null },
                    { new Guid("de989a65-e12b-4458-8f8a-97b7ac374fe3"), "CreateFoodCategory", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateFoodCategory", null, null },
                    { new Guid("e6d94c2c-b260-4d0c-a304-7d6939d8f5be"), "ReadAppUserRole", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "ReadAppUserRole", null, null },
                    { new Guid("ede1f40c-3b2d-4b7b-80bb-e4e21bd58243"), "DeleteAppUser", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "DeleteAppUser", null, null },
                    { new Guid("f2dca889-a381-4e0a-8249-60c1579469c2"), "CreateFoodItem", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "CreateFoodItem", null, null },
                    { new Guid("faefbbe7-329f-4310-b35d-65cf463090db"), "UpdateOrderStatus", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "UpdateOrderStatus", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("044e8258-b152-41fb-9a91-d719abd202c7"), "Cashier", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Cashier", null, null },
                    { new Guid("3f1fdd95-ab54-429d-8231-87157b51d0a0"), "Waiter", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Waiter", null, null },
                    { new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da"), "Admin", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Admin", null, null },
                    { new Guid("938bb77e-79e1-46ad-b7f6-d310d9ecae0d"), "Chef", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Chef", null, null },
                    { new Guid("d1bbe2bc-101f-40ac-981f-8d2369c70108"), "Manager", new DateTime(2024, 10, 21, 14, 45, 11, 439, DateTimeKind.Local).AddTicks(3848), "Admin", null, null, "Manager", null, null }
                });

            migrationBuilder.InsertData(
                table: "AppUserRole",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { new Guid("b4834d25-fdb0-420e-9201-eefaa2d61ee5"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "PrivilegeId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0a843b50-50fe-472d-8c53-9edf0f5a72ed"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("0c837a3e-9c25-4f8a-b53e-b88f88e09747"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("0e071527-57a4-40ac-85b4-6fe8ae689f03"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("1252ca85-8129-410f-bbbe-d18cd38ffc20"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("2a04f504-ded9-4321-bf4a-6394a8d68e34"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("2b67f1c1-9706-47df-b8e2-de436ec15c96"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("2c670fcb-5962-4645-9b98-a2a11ea9b24c"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("30210652-72da-4e5f-8b17-bb789498eeed"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("307d782b-4566-468d-9e6a-80076d811609"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("30cb8b12-ffa9-44d3-a622-10ee055a7eea"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("34785b0d-55ef-4d18-9154-91dd65e49869"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("365933ef-f682-4e7c-8e3b-2c0fed8a51bb"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("384275e8-8481-42f8-96f1-f294d5576e5b"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("3af8ff36-926e-46dc-8f68-42c0743147e1"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("3e686c9d-f5ad-4293-85ad-9bdaf7f8be00"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("51b21093-4f59-4718-98ee-c5f6f7246bb6"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("55fe2fb0-d0e6-435a-95a2-c7a4128e348d"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("5adaa260-8fe9-47d4-bd55-899953cd17b7"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("63080caa-640e-4d43-b8ea-4df8a8d34f9e"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("6329652f-ea64-424b-a65d-05fbccdb9e79"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("638261bc-cc9e-4a8e-b506-9cd00cf655cc"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("673ed6ba-ab67-49d5-bd68-bdc53ac36f89"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("67534680-8527-4653-8109-dc38ff034066"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("6abfbbc8-f52c-4ac4-8a8d-39a2a9b699b1"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("6b06be71-c0fd-4f1a-8475-27d49df94885"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("6c4fc91c-af56-4b3c-bd40-cbf1298f9b86"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("6e9a9935-9db3-4951-8d6b-12f3618389fe"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("6f8b1a9f-abd9-454b-bbb7-8bf207f318d1"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("70d2b2e0-5afe-45d3-998d-ae3a03c56506"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("71256737-da55-4613-b5a7-637b47c9ee77"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("765942b5-69f6-417b-9901-3e55cbdaf1c4"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("7cd2c8af-619c-4916-b771-46ca92a3f00b"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("7feafffa-bf03-425f-b16e-ba0ba930eb42"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("91fd1296-1de6-4343-a50c-dd12426c3c60"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("92e0322c-6371-45c8-8d11-4775244a6eb7"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("97e18b76-e10d-4e81-83ac-a7ade5d3f3b4"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("98bb84d5-b3a3-4a2a-adc1-33191972f50c"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("a8b7fce3-0c10-4997-b389-215fb8751379"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("ac04d0a3-34be-40d2-a3ce-1c2cfe9a0451"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("af646771-acda-44dc-8e6f-ef0c70531659"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("c7eca966-f6d9-45c3-98c8-8f9b1f7051be"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("cd7fea40-5954-4f09-bc6a-a94988c0d0fa"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("dd2577a6-24f4-4f93-b91c-93678dd58559"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("de989a65-e12b-4458-8f8a-97b7ac374fe3"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("e6d94c2c-b260-4d0c-a304-7d6939d8f5be"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("ede1f40c-3b2d-4b7b-80bb-e4e21bd58243"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("f2dca889-a381-4e0a-8249-60c1579469c2"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") },
                    { new Guid("faefbbe7-329f-4310-b35d-65cf463090db"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRole",
                keyColumns: new[] { "AppUserId", "RoleId" },
                keyValues: new object[] { new Guid("b4834d25-fdb0-420e-9201-eefaa2d61ee5"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "FoodItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("548c763a-f7e4-4a22-8c25-bae275fb2c4b"));

            migrationBuilder.DeleteData(
                table: "FoodItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("cabc0a34-4ce6-4eba-bfd1-0321538c3d7f"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("070e1ba3-8eb8-40ba-a661-695b49890252"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("0ecf549a-5fa0-4b1c-85b4-0b9d50079ce3"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("4dc62fd3-b3c5-4ce1-b349-11002bedf363"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("80344bd1-fd91-4a56-9f25-cab6ef02007f"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("94f5c8c5-93e1-4513-ae10-431fd28f68a8"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("aeb883ff-29cf-4141-872a-19111fc2569f"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("b0e424f8-2a6f-4cbb-844e-c3938d06c33f"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("f94741b4-0e99-46f9-8269-ddb5402a24f0"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("044e8258-b152-41fb-9a91-d719abd202c7"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3f1fdd95-ab54-429d-8231-87157b51d0a0"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("938bb77e-79e1-46ad-b7f6-d310d9ecae0d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d1bbe2bc-101f-40ac-981f-8d2369c70108"));

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0a843b50-50fe-472d-8c53-9edf0f5a72ed"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0c837a3e-9c25-4f8a-b53e-b88f88e09747"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0e071527-57a4-40ac-85b4-6fe8ae689f03"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("1252ca85-8129-410f-bbbe-d18cd38ffc20"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("2a04f504-ded9-4321-bf4a-6394a8d68e34"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("2b67f1c1-9706-47df-b8e2-de436ec15c96"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("2c670fcb-5962-4645-9b98-a2a11ea9b24c"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("30210652-72da-4e5f-8b17-bb789498eeed"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("307d782b-4566-468d-9e6a-80076d811609"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("30cb8b12-ffa9-44d3-a622-10ee055a7eea"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("34785b0d-55ef-4d18-9154-91dd65e49869"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("365933ef-f682-4e7c-8e3b-2c0fed8a51bb"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("384275e8-8481-42f8-96f1-f294d5576e5b"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3af8ff36-926e-46dc-8f68-42c0743147e1"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3e686c9d-f5ad-4293-85ad-9bdaf7f8be00"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("51b21093-4f59-4718-98ee-c5f6f7246bb6"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("55fe2fb0-d0e6-435a-95a2-c7a4128e348d"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5adaa260-8fe9-47d4-bd55-899953cd17b7"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("63080caa-640e-4d43-b8ea-4df8a8d34f9e"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6329652f-ea64-424b-a65d-05fbccdb9e79"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("638261bc-cc9e-4a8e-b506-9cd00cf655cc"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("673ed6ba-ab67-49d5-bd68-bdc53ac36f89"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("67534680-8527-4653-8109-dc38ff034066"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6abfbbc8-f52c-4ac4-8a8d-39a2a9b699b1"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6b06be71-c0fd-4f1a-8475-27d49df94885"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6c4fc91c-af56-4b3c-bd40-cbf1298f9b86"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6e9a9935-9db3-4951-8d6b-12f3618389fe"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6f8b1a9f-abd9-454b-bbb7-8bf207f318d1"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("70d2b2e0-5afe-45d3-998d-ae3a03c56506"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("71256737-da55-4613-b5a7-637b47c9ee77"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("765942b5-69f6-417b-9901-3e55cbdaf1c4"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("7cd2c8af-619c-4916-b771-46ca92a3f00b"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("7feafffa-bf03-425f-b16e-ba0ba930eb42"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("91fd1296-1de6-4343-a50c-dd12426c3c60"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("92e0322c-6371-45c8-8d11-4775244a6eb7"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("97e18b76-e10d-4e81-83ac-a7ade5d3f3b4"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("98bb84d5-b3a3-4a2a-adc1-33191972f50c"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a8b7fce3-0c10-4997-b389-215fb8751379"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ac04d0a3-34be-40d2-a3ce-1c2cfe9a0451"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("af646771-acda-44dc-8e6f-ef0c70531659"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c7eca966-f6d9-45c3-98c8-8f9b1f7051be"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("cd7fea40-5954-4f09-bc6a-a94988c0d0fa"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("dd2577a6-24f4-4f93-b91c-93678dd58559"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("de989a65-e12b-4458-8f8a-97b7ac374fe3"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("e6d94c2c-b260-4d0c-a304-7d6939d8f5be"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ede1f40c-3b2d-4b7b-80bb-e4e21bd58243"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("f2dca889-a381-4e0a-8249-60c1579469c2"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("faefbbe7-329f-4310-b35d-65cf463090db"), new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da") });

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("b4834d25-fdb0-420e-9201-eefaa2d61ee5"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("0a843b50-50fe-472d-8c53-9edf0f5a72ed"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("0c837a3e-9c25-4f8a-b53e-b88f88e09747"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("0e071527-57a4-40ac-85b4-6fe8ae689f03"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("1252ca85-8129-410f-bbbe-d18cd38ffc20"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("2a04f504-ded9-4321-bf4a-6394a8d68e34"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("2b67f1c1-9706-47df-b8e2-de436ec15c96"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("2c670fcb-5962-4645-9b98-a2a11ea9b24c"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("30210652-72da-4e5f-8b17-bb789498eeed"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("307d782b-4566-468d-9e6a-80076d811609"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("30cb8b12-ffa9-44d3-a622-10ee055a7eea"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("34785b0d-55ef-4d18-9154-91dd65e49869"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("365933ef-f682-4e7c-8e3b-2c0fed8a51bb"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("384275e8-8481-42f8-96f1-f294d5576e5b"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("3af8ff36-926e-46dc-8f68-42c0743147e1"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("3e686c9d-f5ad-4293-85ad-9bdaf7f8be00"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("51b21093-4f59-4718-98ee-c5f6f7246bb6"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("55fe2fb0-d0e6-435a-95a2-c7a4128e348d"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("5adaa260-8fe9-47d4-bd55-899953cd17b7"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("63080caa-640e-4d43-b8ea-4df8a8d34f9e"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("6329652f-ea64-424b-a65d-05fbccdb9e79"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("638261bc-cc9e-4a8e-b506-9cd00cf655cc"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("673ed6ba-ab67-49d5-bd68-bdc53ac36f89"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("67534680-8527-4653-8109-dc38ff034066"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("6abfbbc8-f52c-4ac4-8a8d-39a2a9b699b1"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("6b06be71-c0fd-4f1a-8475-27d49df94885"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("6c4fc91c-af56-4b3c-bd40-cbf1298f9b86"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("6e9a9935-9db3-4951-8d6b-12f3618389fe"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("6f8b1a9f-abd9-454b-bbb7-8bf207f318d1"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("70d2b2e0-5afe-45d3-998d-ae3a03c56506"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("71256737-da55-4613-b5a7-637b47c9ee77"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("765942b5-69f6-417b-9901-3e55cbdaf1c4"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("7cd2c8af-619c-4916-b771-46ca92a3f00b"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("7feafffa-bf03-425f-b16e-ba0ba930eb42"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("91fd1296-1de6-4343-a50c-dd12426c3c60"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("92e0322c-6371-45c8-8d11-4775244a6eb7"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("97e18b76-e10d-4e81-83ac-a7ade5d3f3b4"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("98bb84d5-b3a3-4a2a-adc1-33191972f50c"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("a8b7fce3-0c10-4997-b389-215fb8751379"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("ac04d0a3-34be-40d2-a3ce-1c2cfe9a0451"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("af646771-acda-44dc-8e6f-ef0c70531659"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("c7eca966-f6d9-45c3-98c8-8f9b1f7051be"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("cd7fea40-5954-4f09-bc6a-a94988c0d0fa"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("dd2577a6-24f4-4f93-b91c-93678dd58559"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("de989a65-e12b-4458-8f8a-97b7ac374fe3"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("e6d94c2c-b260-4d0c-a304-7d6939d8f5be"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("ede1f40c-3b2d-4b7b-80bb-e4e21bd58243"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("f2dca889-a381-4e0a-8249-60c1579469c2"));

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: new Guid("faefbbe7-329f-4310-b35d-65cf463090db"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("59453518-e6ec-41bf-ba53-5bdb0808c0da"));
        }
    }
}
