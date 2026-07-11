using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALUNO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_INSTRUTOR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Especialidade = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INSTRUTOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_TB_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_MODULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    DuracaoHoras = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MODULO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_MODULO_TB_CURSO_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_CURSO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TURMA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TURMA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TURMA_TB_CURSO_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_CURSO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TURMA_TB_INSTRUTOR_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "TB_INSTRUTOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_MATRICULA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MATRICULA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_MATRICULA_TB_ALUNO_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "TB_ALUNO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_MATRICULA_TB_TURMA_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "TB_TURMA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_CPF",
                table: "TB_ALUNO",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_Email",
                table: "TB_ALUNO",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_Telefone",
                table: "TB_ALUNO",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CATEGORIA_Titulo",
                table: "TB_CATEGORIA",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_CategoriaId",
                table: "TB_CURSO",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_Titulo_CategoriaId",
                table: "TB_CURSO",
                columns: new[] { "Titulo", "CategoriaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_INSTRUTOR_Email",
                table: "TB_INSTRUTOR",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_INSTRUTOR_Telefone",
                table: "TB_INSTRUTOR",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_MATRICULA_AlunoId_TurmaId",
                table: "TB_MATRICULA",
                columns: new[] { "AlunoId", "TurmaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_MATRICULA_TurmaId",
                table: "TB_MATRICULA",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MODULO_CursoId_Ordem",
                table: "TB_MODULO",
                columns: new[] { "CursoId", "Ordem" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TURMA_CursoId",
                table: "TB_TURMA",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TURMA_InstrutorId",
                table: "TB_TURMA",
                column: "InstrutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MATRICULA");

            migrationBuilder.DropTable(
                name: "TB_MODULO");

            migrationBuilder.DropTable(
                name: "TB_ALUNO");

            migrationBuilder.DropTable(
                name: "TB_TURMA");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_INSTRUTOR");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");
        }
    }
}
