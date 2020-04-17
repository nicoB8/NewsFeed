using Microsoft.EntityFrameworkCore.Migrations;

namespace newsfeed.nicolasbonora.repository.Migrations
{
    public partial class ChangedUserFeedTableNameAndFeedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFeed_Feeds_FeedId",
                table: "UserFeed");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFeed_Users_UserId",
                table: "UserFeed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFeed",
                table: "UserFeed");

            migrationBuilder.RenameTable(
                name: "UserFeed",
                newName: "UserFeeds");

            migrationBuilder.RenameIndex(
                name: "IX_UserFeed_FeedId",
                table: "UserFeeds",
                newName: "IX_UserFeeds_FeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFeeds",
                table: "UserFeeds",
                columns: new[] { "UserId", "FeedId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeeds_Feeds_FeedId",
                table: "UserFeeds",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeeds_Users_UserId",
                table: "UserFeeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Feeds_FeedId",
                table: "UserFeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFeeds_Users_UserId",
                table: "UserFeeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFeeds",
                table: "UserFeeds");

            migrationBuilder.RenameTable(
                name: "UserFeeds",
                newName: "UserFeed");

            migrationBuilder.RenameIndex(
                name: "IX_UserFeeds_FeedId",
                table: "UserFeed",
                newName: "IX_UserFeed_FeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFeed",
                table: "UserFeed",
                columns: new[] { "UserId", "FeedId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeed_Feeds_FeedId",
                table: "UserFeed",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFeed_Users_UserId",
                table: "UserFeed",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
