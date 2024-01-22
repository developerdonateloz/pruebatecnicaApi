using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.DbModel.Entities
{
    public class Det_Matricula
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(5)")]
        public string Seccion { get; set; }

        [Column(TypeName = "Char(2)")]
        public string Grupo { get; set; }

        [Required]
        [Column(TypeName = "Varchar(8)")]
        public string Usuario_Creador { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha_Creacion { get; set; }

        [Column(TypeName = "Varchar(8)")]
        public string Usuario_Modificador { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha_Modificacion { get; set; }

        [ForeignKey(nameof(Matricula))]
        public int Matricula_Id_Matricula { get; set; }

        [ForeignKey(nameof(Curso))]
        public string Curso_Cod_Curso { get; set; }

        [ForeignKey(nameof(Curso))]
        public string Curso_Linea_Negocio { get; set; }
    }
}
