﻿using Microsoft.EntityFrameworkCore;
using RumoATI.ETB.Domain2.Entidades;
using RumoATI.ETB.Domain2.Map;

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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FGIG7N0\UNIDADE_IDS;Initial Catalog=BRINCANDO_SQL;User Id=sa;Password=unidade;Integrated Security=True");
        }
    }
}
