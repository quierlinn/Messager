using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messager.Migrations
{
    /// <inheritdoc />
    public partial class messageTableRenaame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_receiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_senderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_receiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_senderId",
                table: "Messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Messages_receiverId",
                table: "Messages",
                column: "receiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_senderId",
                table: "Messages",
                column: "senderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_receiverId",
                table: "Messages",
                column: "receiverId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_senderId",
                table: "Messages",
                column: "senderId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
