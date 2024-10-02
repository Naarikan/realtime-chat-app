using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealTimeChatApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupRoles_AspNetRoles_RoleId",
                table: "UserGroupRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupRoles",
                table: "UserGroupRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupRoles",
                table: "UserGroupRoles",
                columns: new[] { "UserId", "GroupChatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupRoles_AspNetRoles_RoleId",
                table: "UserGroupRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupRoles_AspNetRoles_RoleId",
                table: "UserGroupRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupRoles",
                table: "UserGroupRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupRoles",
                table: "UserGroupRoles",
                columns: new[] { "UserId", "RoleId", "GroupChatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupRoles_AspNetRoles_RoleId",
                table: "UserGroupRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
