using Microsoft.EntityFrameworkCore;
using RumoATI.ETB.Domain2.Entidades;
using RumoATI.ETB.Domain2.Map;
using umoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Domain2.Context
{
    public class ETBContext : DbContext
    {
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ProfessorCurso> ProfessorCurso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new ProfessorCursoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=UNIDADE_IDS;Initial Catalog=BRINCANDO_SQL;User Id=******;Password=*****;Integrated Security=True");
        }
    }
}
