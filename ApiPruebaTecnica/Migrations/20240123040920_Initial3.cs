using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CodCurso = table.Column<string>(name: "Cod_Curso", type: "Varchar(10)", nullable: false),
                    CodLineaNegocio = table.Column<string>(name: "Cod_Linea_Negocio", type: "Char(1)", nullable: false),
                    DescCurso = table.Column<string>(name: "Desc_Curso", type: "Varchar(100)", nullable: false),
                    UsuarioCreador = table.Column<string>(name: "Usuario_Creador", type: "Varchar(8)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(name: "Fecha_Creacion", type: "Date", nullable: false),
                    UsuarioModificador = table.Column<string>(name: "Usuario_Modificador", type: "Varchar(8)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(name: "Fecha_Modificacion", type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => new { x.CodCurso, x.CodLineaNegocio });
                });

            migrationBuilder.CreateTable(
                name: "DetallesMatricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Seccion = table.Column<string>(type: "Varchar(5)", nullable: false),
                    Grupo = table.Column<string>(type: "Char(2)", nullable: false),
                    UsuarioCreador = table.Column<string>(name: "Usuario_Creador", type: "Varchar(8)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(name: "Fecha_Creacion", type: "Date", nullable: false),
                    UsuarioModificador = table.Column<string>(name: "Usuario_Modificador", type: "Varchar(8)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(name: "Fecha_Modificacion", type: "Date", nullable: true),
                    MatriculaIdMatricula = table.Column<int>(name: "Matricula_Id_Matricula", type: "NUMBER(10)", nullable: false),
                    CursoCodCurso = table.Column<string>(name: "Curso_Cod_Curso", type: "NVARCHAR2(2000)", nullable: false),
                    CursoLineaNegocio = table.Column<string>(name: "Curso_Linea_Negocio", type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesMatricula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(name: "Id_Matricula", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CodLineaNegocio = table.Column<string>(name: "Cod_Linea_Negocio", type: "Char(1)", nullable: false),
                    CodModalEst = table.Column<string>(name: "Cod_Modal_Est", type: "Char(2)", nullable: false),
                    CodPeriodo = table.Column<string>(name: "Cod_Periodo", type: "Char(6)", nullable: false),
                    CodAlumno = table.Column<string>(name: "Cod_Alumno", type: "Varchar(9)", nullable: false),
                    UsuarioCreador = table.Column<string>(name: "Usuario_Creador", type: "Varchar(8)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(name: "Fecha_Creacion", type: "Date", nullable: false),
                    UsuarioModificador = table.Column<string>(name: "Usuario_Modificador", type: "Varchar(8)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(name: "Fecha_Modificacion", type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.IdMatricula);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "DetallesMatricula");

            migrationBuilder.DropTable(
                name: "Matriculas");
        }
    }
}
