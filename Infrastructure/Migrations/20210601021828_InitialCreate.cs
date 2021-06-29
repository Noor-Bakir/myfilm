using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmStar1",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StarName = table.Column<string>(nullable: true),
                    Film = table.Column<string>(nullable: true),
                    Starimage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStar1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmStar2",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StarName = table.Column<string>(nullable: true),
                    Film = table.Column<string>(nullable: true),
                    Starimage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStar2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FilmName = table.Column<string>(nullable: true),
                    FilmLang = table.Column<string>(nullable: true),
                    FilmTrans = table.Column<string>(nullable: true),
                    FilmType = table.Column<string>(nullable: true),
                    Filmtime = table.Column<string>(nullable: true),
                    FilmDate = table.Column<string>(nullable: true),
                    FilmDarg = table.Column<string>(nullable: true),
                    FilmImage = table.Column<string>(nullable: true),
                    FilmStar1Id = table.Column<Guid>(nullable: true),
                    FilmStar2Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_FilmStar1_FilmStar1Id",
                        column: x => x.FilmStar1Id,
                        principalTable: "FilmStar1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Film_FilmStar2_FilmStar2Id",
                        column: x => x.FilmStar2Id,
                        principalTable: "FilmStar2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "Id", "FilmDarg", "FilmDate", "FilmImage", "FilmLang", "FilmName", "FilmStar1Id", "FilmStar2Id", "FilmTrans", "FilmType", "Filmtime" },
                values: new object[] { new Guid("c43d0db0-63ec-4ec4-9b7a-1a20c48d9a71"), "****", null, null, null, "Jungle", null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Film_FilmStar1Id",
                table: "Film",
                column: "FilmStar1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Film_FilmStar2Id",
                table: "Film",
                column: "FilmStar2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "FilmStar1");

            migrationBuilder.DropTable(
                name: "FilmStar2");
        }
    }
}
