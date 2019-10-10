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
                   .HasColumnName("NOME_PROFESSOR")
                   .HasColumnType("VARCHAR(120)");

            builder.Property(p => p.SobreNome)
                   .HasColumnName("SOBRENOME_PROFESSOR")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Email)
                   .HasColumnName("EMAIL_PROFESSOR")
                   .HasColumnType("VARCHAR(120)");

            builder.HasMany(pc => pc.ProfessoresCurso)
                        .WithOne(p => p.Professor)
                        .HasForeignKey(fk => fk.IdProfessor);

            builder.HasOne(u => u.Usuario)
                   .WithOne(p => p.Professor)
                   .HasForeignKey<Professor>(fk => fk.Id);
        }
    }
}
