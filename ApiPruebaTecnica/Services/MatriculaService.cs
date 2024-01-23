using ApiPruebaTecnica.DbModel.Context;
using ApiPruebaTecnica.DbModel.Entities;
using ApiPruebaTecnica.Dto;
using ApiPruebaTecnica.RequestParams;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly DataContext _context;

        public MatriculaService(DataContext context)
        {
            _context = context;
        }
        public async Task<Matricula> CreateMatricula(MatriculaRequestParams param)
        {
            if (param.Usuario_Creador.Length > 8)
            {
                throw new Exception($"La máxima longitud del campo Usuario_Creador es de 8 caracteres.");
            }

            if (param.Cod_Linea_Negocio.Length > 1)
            {
                throw new Exception($"La máxima longitud del campo Cod_Linea_Negocio es de 1 caracter.");
            }
            if (param.Cod_Modal_Est.Length > 2)
            {
                throw new Exception($"La máxima longitud del campo Modal_Est es de 2 caracteres.");
            }
            if (param.Cod_Periodo.Length > 6)
            {
                throw new Exception($"La máxima longitud del campo Cod_Periodo es de 6 caracteres.");
            }
            if (param.Cod_Alumno.Length > 9)
            {
                throw new Exception($"La máxima longitud del campo Cod_Alumno es de 9 caracteres.");
            }
            var existeMatricula = await _context.Matriculas.AnyAsync(q => q.Id_Matricula == param.Id_Matricula);

            if (existeMatricula)
            {
                throw new Exception($"La matrícula con ID: {param.Id_Matricula} ya existe.");
            }

            var matricula = new Matricula
            {
                Id_Matricula = param.Id_Matricula,
                Cod_Linea_Negocio = param.Cod_Linea_Negocio,
                Cod_Modal_Est = param.Cod_Modal_Est,
                Cod_Periodo = param.Cod_Periodo,
                Cod_Alumno = param.Cod_Alumno,
                Usuario_Creador = param.Usuario_Creador,
                Fecha_Creacion = DateTime.UtcNow
            };

            _context.Matriculas.Add(matricula);

            await _context.SaveChangesAsync();

            return matricula;
        }


        public async Task<List<MatriculaDto>> GetMatriculas(FilterMatriculaParams param)
        {
            if (string.IsNullOrWhiteSpace(param.linea_negocio))
            {
                throw new Exception($"linea de negocio obligatorio");
            }

            var resultado = _context.Matriculas
                .GroupJoin(_context.DetallesMatricula, x => x.Id_Matricula, y => y.Matricula_Id_Matricula, (x, y) => new
                {
                    matriculas = x,
                    y
                })
                .SelectMany(q => q.y.DefaultIfEmpty(), (x, y) => new
                {
                    x.matriculas,
                    detalles = y
                }
                )
                .GroupJoin(_context.Cursos, a => a.detalles.Curso_Cod_Curso, b => b.Cod_Curso, (a, b) => new
                {
                    a.matriculas,
                    a.detalles,
                    cursos = b
                })
                .SelectMany(q => q.cursos.DefaultIfEmpty(), (x, y) => new
                {
                    x.matriculas,
                    x.detalles,
                    x.cursos,
                })
                .Where(q => q.matriculas.Cod_Linea_Negocio == param.linea_negocio)
                .Select(s => new MatriculaDto
                {
                    Cod_Linea_Negocio = s.matriculas.Cod_Linea_Negocio,
                    Cod_Modal_Est = s.matriculas.Cod_Modal_Est,
                    Cod_Periodo = s.matriculas.Cod_Periodo,
                    Cod_Alumno = s.matriculas.Cod_Alumno,
                    Usuario_Creador = s.matriculas.Usuario_Creador,
                    Fecha_Creacion = s.matriculas.Fecha_Creacion
                });

            if (!string.IsNullOrWhiteSpace(param.modalidad))
            {
                resultado = resultado.Where(q => q.Cod_Modal_Est == param.modalidad);
            }

            if (!string.IsNullOrWhiteSpace(param.codigo_periodo))
            {
                resultado = resultado.Where(q => q.Cod_Periodo == param.codigo_periodo);
            }

            if (!string.IsNullOrWhiteSpace(param.codigo_alumno))
            {
                resultado = resultado.Where(q => q.Cod_Alumno == param.codigo_alumno);
            }

            return await resultado.ToListAsync();
        }
    }
}
