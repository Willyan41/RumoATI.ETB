using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RumoATI.ETB.Domain2.Migrations
{
    public partial class KiddingSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BS_001_CURSO",
                columns: table => new
                {
                    ID_CURSO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME_CURSO = table.Column<string>(nullable: true),
                    DESCRICAO_CURSO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BS_001_CURSO", x => x.ID_CURSO);
                });

            migrationBuilder.CreateTable(
                name: "BS_010_PERFIL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRICAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BS_010_PERFIL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BS_000_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME_USUARIO = table.Column<string>(nullable: true),
                    ID_PERFIL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BS_000_USUARIO", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK_BS_000_USUARIO_BS_010_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalTable: "BS_010_PERFIL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BS_002_PROFESSOR",
                columns: table => new
                {
                    ID_PROFESSOR = table.Column<int>(nullable: false),
                    NOME_PROFESSOR = table.Column<string>(nullable: true),
                    SOBRENOME_PROFESSOR = table.Column<string>(nullable: true),
                    EMAIL_PROFESSOR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BS_002_PROFESSOR", x => x.ID_PROFESSOR);
                    table.ForeignKey(
                        name: "FK_BS_002_PROFESSOR_BS_000_USUARIO_ID_PROFESSOR",
                        column: x => x.ID_PROFESSOR,
                        principalTable: "BS_000_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BS_003_PROFESSOR_CURSO",
                columns: table => new
                {
                    ID_PROFESSOR = table.Column<int>(nullable: false),
                    ID_CURSO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BS_003_PROFESSOR_CURSO", x => new { x.ID_CURSO, x.ID_PROFESSOR });
                    table.ForeignKey(
                        name: "FK_BS_003_PROFESSOR_CURSO_BS_001_CURSO_ID_CURSO",
                        column: x => x.ID_CURSO,
                        principalTable: "BS_001_CURSO",
                        principalColumn: "ID_CURSO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BS_003_PROFESSOR_CURSO_BS_002_PROFESSOR_ID_PROFESSOR",
                        column: x => x.ID_PROFESSOR,
                        principalTable: "BS_002_PROFESSOR",
                        principalColumn: "ID_PROFESSOR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BS_000_USUARIO_ID_PERFIL",
                table: "BS_000_USUARIO",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_BS_003_PROFESSOR_CURSO_ID_PROFESSOR",
                table: "BS_003_PROFESSOR_CURSO",
                column: "ID_PROFESSOR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BS_003_PROFESSOR_CURSO");

            migrationBuilder.DropTable(
                name: "BS_001_CURSO");

            migrationBuilder.DropTable(
                name: "BS_002_PROFESSOR");

            migrationBuilder.DropTable(
                name: "BS_000_USUARIO");

            migrationBuilder.DropTable(
                name: "BS_010_PERFIL");
        }
    }
}
