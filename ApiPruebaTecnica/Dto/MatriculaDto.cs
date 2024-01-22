using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Dto
{
    public class MatriculaDto
    {
        public string Cod_Linea_Negocio { get; set; }

        public string Cod_Modal_Est { get; set; }

        public string Cod_Periodo { get; set; }

        public string Cod_Alumno { get; set; }

        
        public string Usuario_Creador { get; set; }

        
        public DateTime Fecha_Creacion { get; set; }
    }
}
