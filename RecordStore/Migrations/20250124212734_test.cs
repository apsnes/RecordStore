using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpotifyEmbed",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpotifyEmbed",
                value: "https://open.spotify.com/embed/album/4LH4d3cOWNNsVw41Gqt2kv?utm_source=generator");

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpotifyEmbed",
                value: "https://open.spotify.com/embed/album/0ETFjACtuP2ADo6LFhL6HN?utm_source=generator");

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpotifyEmbed",
                value: "https://open.spotify.com/embed/track/3S2R0EVwBSAVMd5UMgKTL0?utm_source=generator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpotifyEmbed",
                table: "Records");
        }
    }
}
