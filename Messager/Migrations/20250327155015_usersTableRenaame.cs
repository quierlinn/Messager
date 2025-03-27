using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messager.Migrations
{
    /// <inheritdoc />
    public partial class usersTableRenaame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_receiverId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_senderId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message_senderId",
                table: "Messages",
                newName: "IX_Messages_senderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_receiverId",
                table: "Messages",
                newName: "IX_Messages_receiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_receiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_senderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_senderId",
                table: "Message",
                newName: "IX_Message_senderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_receiverId",
                table: "Message",
                newName: "IX_Message_receiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_receiverId",
                table: "Message",
                column: "receiverId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_senderId",
                table: "Message",
                column: "senderId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
