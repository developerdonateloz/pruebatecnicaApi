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
                Fecha_Creacion = DateTime.UtcNow,
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

            var resultado = await _context.Matriculas
                .Join(_context.DetallesMatricula, x => x.Id_Matricula, y => y.Matricula_Id_Matricula,
                    (x, y) => new { x, y })
                .Join(_context.Cursos, a => a.y.Curso_Cod_Curso, b => b.Cod_Curso,
                    (a, b) => new { a, b })
                .Where(q => q.a.x.Cod_Linea_Negocio == param.linea_negocio &&
                            (q.a.x.Cod_Modal_Est == param.modalidad || q.a.x.Cod_Alumno == param.codigo_alumno ||
                             q.a.x.Cod_Periodo == param.codigo_periodo))
                .Select(s => new MatriculaDto
                {
                    Cod_Linea_Negocio = s.a.x.Cod_Linea_Negocio,
                    Cod_Modal_Est = s.a.x.Cod_Modal_Est,
                    Cod_Periodo = s.a.x.Cod_Periodo,
                    Cod_Alumno = s.a.x.Cod_Alumno,
                    Usuario_Creador = s.a.x.Usuario_Creador,
                    Fecha_Creacion = s.a.x.Fecha_Creacion
                }).ToListAsync();
            
            return resultado;
        }
    }
}
