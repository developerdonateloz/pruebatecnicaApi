using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.DbModel.Entities
{
    [Table("Curso")]
    public class Curso
    {

        [Column(TypeName = "Varchar(10)")]
        public string Cod_Curso { get; set; }

        [Column(TypeName = "Char(1)")]
        public string Cod_Linea_Negocio { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string Desc_Curso { get; set; }

        [Required]
        [Column(TypeName = "Varchar(8)")]
        public string Usuario_Creador { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha_Creacion { get; set; }

        [Column(TypeName = "Varchar(8)")]
        public string Usuario_Modificador { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha_Modificacion { get; set; }

    }
}
