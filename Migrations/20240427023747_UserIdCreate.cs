using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _24_26_hack_visual_virtuoso_BE.Migrations
{
    /// <inheritdoc />
    public partial class UserIdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Email", "Name", "Uid" },
                values: new object[] { 2, "E26 Student", "", "Ross", "kWu72mgiX8T6bZJQkaL0aXdpJMz1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
