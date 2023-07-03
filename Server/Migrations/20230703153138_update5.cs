using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppWSAM.Server.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ImageLibrary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ImageLibrary",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
