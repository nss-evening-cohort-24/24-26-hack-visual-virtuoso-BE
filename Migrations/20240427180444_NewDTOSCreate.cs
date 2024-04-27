using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _24_26_hack_visual_virtuoso_BE.Migrations
{
    /// <inheritdoc />
    public partial class NewDTOSCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkTags_Artwork_ArtworkId",
                table: "ArtworkTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkTags_Tags_TagId",
                table: "ArtworkTags");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "ArtworkTags",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtworkId",
                table: "ArtworkTags",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Artwork",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Artwork",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkTags_Artwork_ArtworkId",
                table: "ArtworkTags",
                column: "ArtworkId",
                principalTable: "Artwork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkTags_Tags_TagId",
                table: "ArtworkTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkTags_Artwork_ArtworkId",
                table: "ArtworkTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkTags_Tags_TagId",
                table: "ArtworkTags");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Artwork");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "ArtworkTags",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ArtworkId",
                table: "ArtworkTags",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkTags_Artwork_ArtworkId",
                table: "ArtworkTags",
                column: "ArtworkId",
                principalTable: "Artwork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkTags_Tags_TagId",
                table: "ArtworkTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
