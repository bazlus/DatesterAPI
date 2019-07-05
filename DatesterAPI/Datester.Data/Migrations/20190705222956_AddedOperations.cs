using Microsoft.EntityFrameworkCore.Migrations;

namespace Datester.Data.Migrations
{
    public partial class AddedOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserOperations",
                columns: table => new
                {
                    UserOneId = table.Column<string>(nullable: false),
                    UserTwoId = table.Column<string>(nullable: false),
                    Operation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperations", x => new { x.UserOneId, x.UserTwoId });
                    table.ForeignKey(
                        name: "FK_UserOperations_AspNetUsers_UserOneId",
                        column: x => x.UserOneId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserOperations_AspNetUsers_UserTwoId",
                        column: x => x.UserTwoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOperations_UserTwoId",
                table: "UserOperations",
                column: "UserTwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOperations");
        }
    }
}
