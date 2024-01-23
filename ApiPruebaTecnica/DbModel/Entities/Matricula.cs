using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ApiPruebaTecnica.DbModel.Entities
{
    public class Matricula
    {
        [Key]
        public int Id_Matricula { get; set; }

        [Required]
        [Column(TypeName = "Char(1)")]
        public string Cod_Linea_Negocio { get; set; }
        
        [Column(TypeName = "Char(2)")]
        [Required] 
        public string Cod_Modal_Est { get; set; }
        
        [Column(TypeName = "Char(6)")]
        [Required] 
        public string Cod_Periodo { get; set; }
        
        [Column(TypeName = "Varchar(9)")]
        [Required] public string Cod_Alumno { get; set; }
        
        [Column(TypeName = "Varchar(8)")]
        [Required] 
        public string Usuario_Creador { get; set; }
        
        [Column(TypeName = "Date")]
        [Required] 
        public DateTime Fecha_Creacion { get; set; }
        
        [Column(TypeName = "Varchar(8)")]
        public string? Usuario_Modificador { get; set; }
        
        [Column(TypeName = "Date")]
        public DateTime? Fecha_Modificacion { get; set; }
    }
}
