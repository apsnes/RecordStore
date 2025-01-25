using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Migrations
{
    /// <inheritdoc />
    public partial class Artiststable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArtistId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArtistId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArtistId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Records");
        }
    }
}
