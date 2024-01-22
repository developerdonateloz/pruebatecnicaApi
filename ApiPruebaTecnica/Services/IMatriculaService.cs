using ApiPruebaTecnica.DbModel.Entities;
using ApiPruebaTecnica.Dto;
using ApiPruebaTecnica.RequestParams;

namespace ApiPruebaTecnica.Services
{
    public interface IMatriculaService
    {
        Task<Matricula> CreateMatricula(MatriculaRequestParams matriculaRequestParams);
        Task<List<MatriculaDto>> GetMatriculas(FilterMatriculaParams param);
    }
}
