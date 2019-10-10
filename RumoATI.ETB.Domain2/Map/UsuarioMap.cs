using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RumoATI.ETB.Domain2.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RumoATI.ETB.Domain2.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("BS_000_USUARIO");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("ID_USUARIO");

            builder.Property(p => p.IdPerfil)
                   .HasColumnName("ID_PERFIL");

            builder.Property(p => p.Nome)
                   .HasColumnName("NOME_USUARIO")
                   .HasColumnType("VARCHAR(120)");

            builder.Property(p => p.Senha)
                .HasColumnName("DESC_SENHA")
                .HasColumnType("VARCHAR(120)");

            builder.Property(p => p.Login)
                   .HasColumnName("LOGIN")
                   .HasColumnType("VARCHAR(8)");

            builder.HasOne(p => p.Perfil)
                   .WithMany(u => u.Usuarios)
                   .HasForeignKey(u => u.IdPerfil);
        }
    }
}
