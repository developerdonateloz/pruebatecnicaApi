using ApiPruebaTecnica.DbModel.Context;
using ApiPruebaTecnica.DbModel.Entities;
using ApiPruebaTecnica.RequestParams;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Services
{
    public class DetalleMatriculaService : IDetalleMatriculaService
    {
        private readonly DataContext _context;

        public DetalleMatriculaService(DataContext context)
        {
            _context = context;
        }
        public async Task<Det_Matricula> CrearDetalleMatricula(DetalleMatriculaRequestParams param)
        {
            var existeDetalle = await _context.DetallesMatricula.AnyAsync(q => q.Id == param.Id);

            if (existeDetalle)
            {
                throw new Exception($"Ya existe detalle con ID: {param.Id}");
            }

            var detalleMatricula = new Det_Matricula
            {
                Id = param.Id,
                Seccion = param.Seccion,
                Grupo = param.Grupo,
                Usuario_Creador = param.Usuario_Creador,
                Fecha_Creacion = DateTime.UtcNow,

                Matricula_Id_Matricula = param.Matricula_Id_Matricula,
                Curso_Cod_Curso = param.Curso_Cod_Curso,
                Curso_Linea_Negocio = param.Curso_Linea_Negocio
            };

            _context.DetallesMatricula.Add(detalleMatricula);
            await _context.SaveChangesAsync();

            return detalleMatricula;
        }
    }
}
