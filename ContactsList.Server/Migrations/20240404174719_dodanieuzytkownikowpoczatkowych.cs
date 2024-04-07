using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactsList.Server.Migrations
{
    /// <inheritdoc />
    public partial class dodanieuzytkownikowpoczatkowych : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1239df5f-ad85-4253-ac3e-cd7c735cba80", null, "admin", "admin" },
                    { "a5b2ed4e-78e1-45e7-b305-1764281f2aba", null, "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CategoryId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubcategoryId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2aafaa9c-4cf6-43e9-b35e-f6a28a48744c", 0, new DateTime(2024, 4, 4, 19, 47, 19, 141, DateTimeKind.Local).AddTicks(9007), 1, "24bdb25b-ccd7-4544-a1c4-263a5d8d90c2", "user1@gmail.com", false, false, null, "Phoenix", "user1@gmail.com", "user1", "7oGRWM1/J+I9aXgYWYrv7g==;ouDeSYqEwzZ+W8HwZQBgNf1+XieV3pWtOVAo5K6AOb0=", null, false, "", 1, "Elliott", false, "user1" },
                    { "2f5b4bec-351f-4b25-a597-d0a9ac009557", 0, new DateTime(2024, 4, 4, 19, 47, 19, 143, DateTimeKind.Local).AddTicks(6002), 1, "475799f0-9ea7-4e39-a24a-d233457f0eed", "user3@gmail.com", false, false, null, "Rafael", "user3@gmail.com", "user3", "+iye0s+0WxArvw5kXTFlHw==;kD7Gp36jrCswZfBizTAsglp52o4rfSPDK5SGhXG3W6E=", null, false, "", 1, "Weiner", false, "user3" },
                    { "d6933779-ba12-4eb3-8be4-57c67d6e00fe", 0, new DateTime(2024, 4, 4, 19, 47, 19, 140, DateTimeKind.Local).AddTicks(9359), 1, "cd393682-8eb2-4eda-906e-31845bb46b71", "admin@gmail.com", false, false, null, "Alexander", "admin@gmail.com", "admin", "lTEKq5Fj5y+o65oNiD5ZLA==;VwZ51sh51wK2ik2sH12DSUF60zNfRbubCC0zA2A59IY=", null, false, "", 1, "Johnston", false, "admin" },
                    { "f24dd81f-3d54-4764-9ce4-ddd06bc65875", 0, new DateTime(2024, 4, 4, 19, 47, 19, 142, DateTimeKind.Local).AddTicks(7503), 1, "1c60b205-bf95-47a5-8940-c5b159348a40", "user2@gmail.com", false, false, null, "Christin", "user2@gmail.com", "user2", "joyoSq973MsZmMHn65FgVQ==;7nAPJN6BIa8w9jqF7eBxfpNLx9m3Rtvpb0EPOgKiWMs=", null, false, "", 1, "Cavanaugh", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a5b2ed4e-78e1-45e7-b305-1764281f2aba", "2aafaa9c-4cf6-43e9-b35e-f6a28a48744c" },
                    { "a5b2ed4e-78e1-45e7-b305-1764281f2aba", "2f5b4bec-351f-4b25-a597-d0a9ac009557" },
                    { "1239df5f-ad85-4253-ac3e-cd7c735cba80", "d6933779-ba12-4eb3-8be4-57c67d6e00fe" },
                    { "a5b2ed4e-78e1-45e7-b305-1764281f2aba", "f24dd81f-3d54-4764-9ce4-ddd06bc65875" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5b2ed4e-78e1-45e7-b305-1764281f2aba", "2aafaa9c-4cf6-43e9-b35e-f6a28a48744c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5b2ed4e-78e1-45e7-b305-1764281f2aba", "2f5b4bec-351f-4b25-a597-d0a9ac009557" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1239df5f-ad85-4253-ac3e-cd7c735cba80", "d6933779-ba12-4eb3-8be4-57c67d6e00fe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5b2ed4e-78e1-45e7-b305-1764281f2aba", "f24dd81f-3d54-4764-9ce4-ddd06bc65875" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1239df5f-ad85-4253-ac3e-cd7c735cba80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5b2ed4e-78e1-45e7-b305-1764281f2aba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aafaa9c-4cf6-43e9-b35e-f6a28a48744c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f5b4bec-351f-4b25-a597-d0a9ac009557");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6933779-ba12-4eb3-8be4-57c67d6e00fe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f24dd81f-3d54-4764-9ce4-ddd06bc65875");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", null, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CategoryId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubcategoryId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, new DateTime(2024, 4, 4, 19, 27, 39, 176, DateTimeKind.Local).AddTicks(4562), 1, "2fab7b40-aec4-4143-b197-e6382c1b8e14", "admin@gmail.com", false, false, null, "Alexander", "admin@gmail.com", "admin", "7ZN2iCW2QAf9LPRmdUcBxA==;RmOFWgKTf0fBwCfjHrvTSTEv/ZmhG1QtgV08EWJFA2c=", null, false, "", 1, "Johnston", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });
        }
    }
}
