using Microsoft.EntityFrameworkCore;
using RumoATI.ETB.Domain2.Entidades;
using RumoATI.ETB.Domain2.Map;

namespace RumoATI.ETB.Domain2.Context
{
    public class ETBContext : DbContext
    {
        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfessorMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BOMBINHA;Initial Catalog=BRINCANDO_SQL;Integrated Security=True");
        }
    }
}
