﻿using Microsoft.EntityFrameworkCore;
using RumoATI.ETB.Domain2.Entidades;
using RumoATI.ETB.Domain2.Map;
using umoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Domain2.Context
{
    public class ETBContext : DbContext
    {
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Curso> Curso { get; set; }

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
