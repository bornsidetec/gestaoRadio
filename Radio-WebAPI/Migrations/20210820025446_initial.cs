using Microsoft.EntityFrameworkCore.Migrations;

namespace Radio_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interpretes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interpretes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Estilo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tempo = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbunsInterpretes",
                columns: table => new
                {
                    AlbunsId = table.Column<int>(type: "INTEGER", nullable: false),
                    InterpretesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbunsInterpretes", x => new { x.AlbunsId, x.InterpretesId });
                    table.ForeignKey(
                        name: "FK_AlbunsInterpretes_Albuns_AlbunsId",
                        column: x => x.AlbunsId,
                        principalTable: "Albuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbunsInterpretes_Interpretes_InterpretesId",
                        column: x => x.InterpretesId,
                        principalTable: "Interpretes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicasInterpretes",
                columns: table => new
                {
                    MusicasId = table.Column<int>(type: "INTEGER", nullable: false),
                    InterpretesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicasInterpretes", x => new { x.MusicasId, x.InterpretesId });
                    table.ForeignKey(
                        name: "FK_MusicasInterpretes_Interpretes_InterpretesId",
                        column: x => x.InterpretesId,
                        principalTable: "Interpretes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicasInterpretes_Musicas_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "Musicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Albuns",
                columns: new[] { "Id", "Ano", "Imagem", "Nome" },
                values: new object[] { 1, 1990, "", "Classicos" });

            migrationBuilder.InsertData(
                table: "Albuns",
                columns: new[] { "Id", "Ano", "Imagem", "Nome" },
                values: new object[] { 2, 1978, "", "MPB" });

            migrationBuilder.InsertData(
                table: "Interpretes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Roberto Carlos" });

            migrationBuilder.InsertData(
                table: "Interpretes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Toquinho" });

            migrationBuilder.InsertData(
                table: "Interpretes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Vinícius de Morais" });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Ano", "Estilo", "Nome", "Tempo" },
                values: new object[] { 1, 1983, 1, "Aquarela", 4.2000000000000002 });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Ano", "Estilo", "Nome", "Tempo" },
                values: new object[] { 2, 1963, 1, "Garota de Ipanema", 5.3499999999999996 });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Ano", "Estilo", "Nome", "Tempo" },
                values: new object[] { 3, 2021, 2, "Esse cara sou eu", 4.5300000000000002 });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Ano", "Estilo", "Nome", "Tempo" },
                values: new object[] { 4, 1973, 2, "Detalhes", 5.5999999999999996 });

            migrationBuilder.InsertData(
                table: "AlbunsInterpretes",
                columns: new[] { "AlbunsId", "InterpretesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AlbunsInterpretes",
                columns: new[] { "AlbunsId", "InterpretesId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AlbunsInterpretes",
                columns: new[] { "AlbunsId", "InterpretesId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "MusicasInterpretes",
                columns: new[] { "InterpretesId", "MusicasId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "MusicasInterpretes",
                columns: new[] { "InterpretesId", "MusicasId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "MusicasInterpretes",
                columns: new[] { "InterpretesId", "MusicasId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "MusicasInterpretes",
                columns: new[] { "InterpretesId", "MusicasId" },
                values: new object[] { 1, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_AlbunsInterpretes_InterpretesId",
                table: "AlbunsInterpretes",
                column: "InterpretesId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicasInterpretes_InterpretesId",
                table: "MusicasInterpretes",
                column: "InterpretesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbunsInterpretes");

            migrationBuilder.DropTable(
                name: "MusicasInterpretes");

            migrationBuilder.DropTable(
                name: "Albuns");

            migrationBuilder.DropTable(
                name: "Interpretes");

            migrationBuilder.DropTable(
                name: "Musicas");
        }
    }
}
