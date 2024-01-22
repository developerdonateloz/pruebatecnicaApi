using ApiPruebaTecnica.RequestParams;
using ApiPruebaTecnica.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [Route("Matriculas")]
    public class MatriculasController : Controller
    {
        private readonly IMatriculaService _matriculaService;
        private readonly IDetalleMatriculaService _detalleMatriculaService;
        private readonly ILogger _logger;

        public MatriculasController(IMatriculaService matriculaService, IDetalleMatriculaService detalleMatriculaService, ILogger<MatriculasController> logger)
        {
            _matriculaService = matriculaService;
            _detalleMatriculaService = detalleMatriculaService;
            _logger = logger;
        }

        [Route("CrearMatricula")]
        [HttpPost]
        public async Task<ActionResult> CrearMatricula([FromBody] MatriculaRequestParams param)
        {
            try
            {
                var matriculaCreada = await _matriculaService.CreateMatricula(param);

                return Ok(matriculaCreada);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.Message);
                throw;
            }
        }
        [Route("CrearDetalleMatricula")]
        [HttpPost]
        public async Task<ActionResult> CrearDetalleMatricula(DetalleMatriculaRequestParams param)
        {
            try
            {
                var detalleMatriculaCreado = await _detalleMatriculaService.CrearDetalleMatricula(param);

                return Ok(detalleMatriculaCreado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.Message);
                throw;
            }
        }

        [Route("GetMatriculas")]
        [HttpGet]
        public async Task<ActionResult> GetMatriculas(FilterMatriculaParams param)
        {
            try
            {
                var matriculas = _matriculaService.GetMatriculas(param);

                return Ok(matriculas);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
