using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortenerEntities.Migrations
{
    public partial class AddUsers1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGuest",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("12e15727-d369-49a9-8b13-bc22e9362179"), "abcd123456", "Marie" },
                    { new Guid("14629847-905a-4a0e-9abe-80b61655c5cb"), "abcd1234", "George" },
                    { new Guid("56bf46a4-02b8-4693-a0f5-0a95e2218bdc"), "abcd12345", "Maksym" },
                    { new Guid("8f30bedc-47dd-4286-8950-73d8a68e5d41"), "abcd1234567", "John" },
                    { new Guid("ea0075b4-e61d-48af-86d8-6c931aa493da"), "abcdef1234", "Ivan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrls_UserId",
                table: "ShortenedUrls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortenedUrls_Users_UserId",
                table: "ShortenedUrls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortenedUrls_Users_UserId",
                table: "ShortenedUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortenedUrls_UserId",
                table: "ShortenedUrls");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("12e15727-d369-49a9-8b13-bc22e9362179"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("14629847-905a-4a0e-9abe-80b61655c5cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("56bf46a4-02b8-4693-a0f5-0a95e2218bdc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8f30bedc-47dd-4286-8950-73d8a68e5d41"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ea0075b4-e61d-48af-86d8-6c931aa493da"));

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "PersonName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "PersonId");

            migrationBuilder.AddColumn<bool>(
                name: "IsGuest",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
