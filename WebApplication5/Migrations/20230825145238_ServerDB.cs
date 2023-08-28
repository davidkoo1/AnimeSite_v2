using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class ServerDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_Editors_EditorId",
                table: "Animes");

            migrationBuilder.AlterColumn<int>(
                name: "EditorId",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_Editors_EditorId",
                table: "Animes",
                column: "EditorId",
                principalTable: "Editors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_Editors_EditorId",
                table: "Animes");

            migrationBuilder.AlterColumn<int>(
                name: "EditorId",
                table: "Animes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_Editors_EditorId",
                table: "Animes",
                column: "EditorId",
                principalTable: "Editors",
                principalColumn: "Id");
        }
    }
}
