﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook_Web_App.Migrations
{
    public partial class AllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedRecipe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    APIReference = table.Column<int>(nullable: false),
                    Instructions = table.Column<string>(nullable: true),
                    Reviews = table.Column<string>(nullable: true),
                    comments = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedRecipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SavedRecipe_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SavedRecipeID",
                table: "Comments",
                column: "SavedRecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_SavedRecipe_UserID",
                table: "SavedRecipe",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SavedRecipe_SavedRecipeID",
                table: "Comments",
                column: "SavedRecipeID",
                principalTable: "SavedRecipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SavedRecipe_SavedRecipeID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "SavedRecipe");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SavedRecipeID",
                table: "Comments");
        }
    }
}
