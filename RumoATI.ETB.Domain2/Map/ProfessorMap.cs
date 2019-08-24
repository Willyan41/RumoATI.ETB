using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RumoATI.ETB.Domain2.Entidades;
using System;

namespace RumoATI.ETB.Domain2.Map
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("BS_002_PROFESSOR");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("ID_PROFESSOR");

            builder.Property(p => p.Nome)
                   .HasColumnName("NOME_PROFESSOR");

            builder.Property(p => p.SobreNome)
                   .HasColumnName("SOBRENOME_PROFESSOR");

            builder.Property(p => p.Email)
                   .HasColumnName("EMAIL_PROFESSOR");

            builder.HasMany(pc => pc.ProfessoresCurso)
                        .WithOne(p => p.Professor)
                        .HasForeignKey(fk => fk.IdProfessor);

            builder.HasOne(u => u.Usuario)
                   .WithOne(p => p.Professor)
                   .HasForeignKey<Professor>(fk => fk.Id);
        }
    }
}
