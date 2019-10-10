using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using umoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Domain2.Map
{
    class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            
                builder.ToTable("BS_001_CURSO");

                builder.HasKey(k => k.Id);

                builder.Property(p => p.Id)
                       .HasColumnName("ID_CURSO");

                builder.Property(p => p.Nome)
                       .HasColumnName("NOME_CURSO")
                       .HasColumnType("VARCHAR(120)");

            builder.Property(p => p.Descricao)
                       .HasColumnName("DESCRICAO_CURSO")
                       .HasColumnType("VARCHAR(250)");

            builder.HasMany(pc => pc.ProfessoresCurso)
                .WithOne(c => c.Curso)
                .HasForeignKey(fk => fk.IdCurso);

        }
    }
}
