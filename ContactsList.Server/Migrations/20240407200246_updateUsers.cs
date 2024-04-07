using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactsList.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09527c81-9aed-4b24-b130-75cae01612da", "1cd31a01-3456-475f-aef6-fc3d96ba97cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09527c81-9aed-4b24-b130-75cae01612da", "313fe65a-61b6-42d3-8b13-9789eea5a09b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09527c81-9aed-4b24-b130-75cae01612da", "5b56a8cb-4f60-42f2-8124-ecc936102d6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09abcde9-d460-469d-af88-67f7c7159ba9", "bba4903c-e827-4652-a9ac-bcbe4f6662f2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09527c81-9aed-4b24-b130-75cae01612da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09abcde9-d460-469d-af88-67f7c7159ba9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cd31a01-3456-475f-aef6-fc3d96ba97cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "313fe65a-61b6-42d3-8b13-9789eea5a09b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b56a8cb-4f60-42f2-8124-ecc936102d6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bba4903c-e827-4652-a9ac-bcbe4f6662f2");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0874ee7d-86ad-4d83-847a-815245877fcb", null, "user", "user" },
                    { "5bf76c93-fe7e-4afc-acc7-f3425fb099fb", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CategoryId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubcategoryId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1932721d-9553-49fe-ab42-70d42e375ef8", 0, new DateTime(2024, 4, 7, 22, 2, 46, 302, DateTimeKind.Local).AddTicks(7125), 2, "4e56f52f-4248-4db7-84b4-d81af21de70a", "user1@gmail.com", false, false, null, "Phoenix", "user1@gmail.com", "user1", "SAIS/BUANt69JTMv2dN00w==;rShpiB0BrTa5nE84tfvlJMAi7/5d7qngEocM828ZuRo=", null, false, "", 5, "Elliott", false, "user1" },
                    { "1bde2c03-39c7-40e1-9c24-afe0a3dc3c29", 0, new DateTime(2024, 4, 7, 22, 2, 46, 304, DateTimeKind.Local).AddTicks(3928), 1, "632666bd-259b-4b09-aaee-2a568a8bd01a", "user3@gmail.com", false, false, null, "Rafael", "user3@gmail.com", "user3", "wP+1xT9gccbBp3DJTPTJqA==;mBpjZ3ZPvzv38BYXvfI6IsTYs4a6uzaJU50tbmhAdY8=", null, false, "", 3, "Weiner", false, "user3" },
                    { "2a1783ab-e219-42ac-884b-7a98821b5719", 0, new DateTime(2024, 4, 7, 22, 2, 46, 301, DateTimeKind.Local).AddTicks(7826), 1, "b69485b3-fab7-4e36-a2dd-260a2cd93138", "admin@gmail.com", false, false, null, "Alexander", "admin@gmail.com", "admin", "WE1XFwbR/yp+7/5YTukbNQ==;xqNq7FAdR4nTg5ngS46RZ9PtuusJ9ROJ3uiTcYMX6vQ=", null, false, "", 1, "Johnston", false, "admin" },
                    { "489baa6a-313b-41ef-a817-f93035b4145e", 0, new DateTime(2024, 4, 7, 22, 2, 46, 303, DateTimeKind.Local).AddTicks(5580), 2, "1cf5185b-46a4-4359-b883-8121deec7b56", "user2@gmail.com", false, false, null, "Christin", "user2@gmail.com", "user2", "smHu4GgRtZgqnWHr75+3Cw==;6dKGKswBxFx9n7WaglGT7jFk82UyiKtQilvNmb0Xcck=", null, false, "", 4, "Cavanaugh", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0874ee7d-86ad-4d83-847a-815245877fcb", "1932721d-9553-49fe-ab42-70d42e375ef8" },
                    { "0874ee7d-86ad-4d83-847a-815245877fcb", "1bde2c03-39c7-40e1-9c24-afe0a3dc3c29" },
                    { "5bf76c93-fe7e-4afc-acc7-f3425fb099fb", "2a1783ab-e219-42ac-884b-7a98821b5719" },
                    { "0874ee7d-86ad-4d83-847a-815245877fcb", "489baa6a-313b-41ef-a817-f93035b4145e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0874ee7d-86ad-4d83-847a-815245877fcb", "1932721d-9553-49fe-ab42-70d42e375ef8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0874ee7d-86ad-4d83-847a-815245877fcb", "1bde2c03-39c7-40e1-9c24-afe0a3dc3c29" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5bf76c93-fe7e-4afc-acc7-f3425fb099fb", "2a1783ab-e219-42ac-884b-7a98821b5719" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0874ee7d-86ad-4d83-847a-815245877fcb", "489baa6a-313b-41ef-a817-f93035b4145e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0874ee7d-86ad-4d83-847a-815245877fcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bf76c93-fe7e-4afc-acc7-f3425fb099fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1932721d-9553-49fe-ab42-70d42e375ef8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bde2c03-39c7-40e1-9c24-afe0a3dc3c29");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a1783ab-e219-42ac-884b-7a98821b5719");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "489baa6a-313b-41ef-a817-f93035b4145e");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09527c81-9aed-4b24-b130-75cae01612da", null, "user", "user" },
                    { "09abcde9-d460-469d-af88-67f7c7159ba9", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CategoryId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubcategoryId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1cd31a01-3456-475f-aef6-fc3d96ba97cc", 0, new DateTime(2024, 4, 4, 19, 52, 3, 180, DateTimeKind.Local).AddTicks(2453), 2, "db4a9d92-5b92-4914-86a2-9baa5eaa0149", "user1@gmail.com", false, false, null, "Phoenix", "user1@gmail.com", "user1", "elF70dEfvwDWXcE39vX0iA==;DdXMxbsMe0Daf6iIOv2MgbNCNUFcxAfrhj1tjODgIMo=", null, false, "", 5, "Elliott", false, "user1" },
                    { "313fe65a-61b6-42d3-8b13-9789eea5a09b", 0, new DateTime(2024, 4, 4, 19, 52, 3, 181, DateTimeKind.Local).AddTicks(2521), 2, "7380e222-1394-4ff8-9577-5803ff42e003", "user2@gmail.com", false, false, null, "Christin", "user2@gmail.com", "user2", "RQhkbTHIiLzBLd9TO4xMWg==;zGXYlBYH+CeRkUaEzrhEPY8rlikwMngqt6tycD4Xn3o=", null, false, "", 4, "Cavanaugh", false, "user2" },
                    { "5b56a8cb-4f60-42f2-8124-ecc936102d6b", 0, new DateTime(2024, 4, 4, 19, 52, 3, 182, DateTimeKind.Local).AddTicks(1017), 1, "431879aa-2998-4530-95c2-92809b682a50", "user3@gmail.com", false, false, null, "Rafael", "user3@gmail.com", "user3", "QfvmnPIiHOQwjqCoycY0Xg==;5V2rp7f5lEYCNwB1+1rp+8KwCzqazb4IOjv+g+mSzNA=", null, false, "", 3, "Weiner", false, "user3" },
                    { "bba4903c-e827-4652-a9ac-bcbe4f6662f2", 0, new DateTime(2024, 4, 4, 19, 52, 3, 179, DateTimeKind.Local).AddTicks(3814), 1, "a5fb8acf-9cd5-4ec6-822d-00c9348f6238", "admin@gmail.com", false, false, null, "Alexander", "admin@gmail.com", "admin", "jvtOyIoSyTNbeke1IGxKkw==;31ZD61SIDGUnI7s3CmAeZrLmS0j0jMkJ1UqcO9QMJNc=", null, false, "", 1, "Johnston", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "09527c81-9aed-4b24-b130-75cae01612da", "1cd31a01-3456-475f-aef6-fc3d96ba97cc" },
                    { "09527c81-9aed-4b24-b130-75cae01612da", "313fe65a-61b6-42d3-8b13-9789eea5a09b" },
                    { "09527c81-9aed-4b24-b130-75cae01612da", "5b56a8cb-4f60-42f2-8124-ecc936102d6b" },
                    { "09abcde9-d460-469d-af88-67f7c7159ba9", "bba4903c-e827-4652-a9ac-bcbe4f6662f2" }
                });
        }
    }
}
