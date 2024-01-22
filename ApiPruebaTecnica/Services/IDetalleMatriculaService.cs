using ApiPruebaTecnica.DbModel.Context;
using ApiPruebaTecnica.DbModel.Entities;
using ApiPruebaTecnica.RequestParams;

namespace ApiPruebaTecnica.Services
{
    public interface IDetalleMatriculaService
    {
        
        Task<Det_Matricula> CrearDetalleMatricula(DetalleMatriculaRequestParams param);
    }
}
