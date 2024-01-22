namespace ApiPruebaTecnica.RequestParams
{
    public class DetalleMatriculaRequestParams
    {
        public int Id { get; set; }
        public string Seccion { get; set; }
        public string Grupo { get; set; }
        public string Usuario_Creador { get; set; }
        public DateTime Fecha_Creacion { get; set; }

        public int Matricula_Id_Matricula { get; set; }
        public string Curso_Cod_Curso { get; set; }
        public string Curso_Linea_Negocio { get; set; }
    }
}
