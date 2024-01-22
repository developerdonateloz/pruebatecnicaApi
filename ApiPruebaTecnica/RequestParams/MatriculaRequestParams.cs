namespace ApiPruebaTecnica.RequestParams
{
    public class MatriculaRequestParams
    {
        public int Id_Matricula { get; set; }
        public string Cod_Linea_Negocio { get; set; }
        public string Cod_Modal_Est { get; set; }
        public string Cod_Periodo { get; set; }
        public string Cod_Alumno { get; set; }
        public string Usuario_Creador { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
