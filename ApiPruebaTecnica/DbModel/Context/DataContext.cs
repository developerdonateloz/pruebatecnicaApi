using ApiPruebaTecnica.DbModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.DbModel.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Det_Matricula> DetallesMatricula { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>().HasKey(q => new { q.Cod_Curso, q.Cod_Linea_Negocio });
        }
    }
}
