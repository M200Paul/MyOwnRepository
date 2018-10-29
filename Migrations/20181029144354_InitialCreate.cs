using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaAnagrafica.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafiche",
                columns: table => new
                {
                    AnagraficaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    AnnoNascita = table.Column<int>(nullable: false),
                    CodiceFiscale = table.Column<string>(nullable: true),
                    Sesso = table.Column<char>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafiche", x => x.AnagraficaId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Indirizzi",
                columns: table => new
                {
                    IndirizzoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeIndirizzo = table.Column<string>(nullable: true),
                    Città = table.Column<string>(nullable: true),
                    Nazione = table.Column<string>(nullable: true),
                    CAP = table.Column<int>(nullable: false),
                    AnagraficaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indirizzi", x => x.IndirizzoId);
                    table.ForeignKey(
                        name: "FK_Indirizzi_Anagrafiche_AnagraficaId",
                        column: x => x.AnagraficaId,
                        principalTable: "Anagrafiche",
                        principalColumn: "AnagraficaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: false),
                    IndirizzoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Indirizzi_IndirizzoId",
                        column: x => x.IndirizzoId,
                        principalTable: "Indirizzi",
                        principalColumn: "IndirizzoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzi_AnagraficaId",
                table: "Indirizzi",
                column: "AnagraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IndirizzoId",
                table: "Posts",
                column: "IndirizzoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Indirizzi");

            migrationBuilder.DropTable(
                name: "Anagrafiche");
        }
    }
}
