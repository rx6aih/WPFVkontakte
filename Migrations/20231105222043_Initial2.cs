using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFVkontakte.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_UserIdid",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserIdid",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserIdid",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    UserIdid = table.Column<int>(type: "int", nullable: false),
                    groupsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.UserIdid, x.groupsid });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_groupsid",
                        column: x => x.groupsid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UserIdid",
                        column: x => x.UserIdid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_groupsid",
                table: "GroupUser",
                column: "groupsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.AddColumn<int>(
                name: "UserIdid",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserIdid",
                table: "Groups",
                column: "UserIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_UserIdid",
                table: "Groups",
                column: "UserIdid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
