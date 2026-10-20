using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiAlbuns.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaAlbuns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    AnoLancamento = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroFaixas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Albuns",
                columns: new[] { "Id", "AnoLancamento", "NumeroFaixas", "Titulo" },
                values: new object[,]
                {
                    { 1, 1997, 12, "OK Computer" },
                    { 2, 2000, 10, "Kid A" },
                    { 3, 2007, 10, "In Rainbows" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albuns");
        }
    }
}
