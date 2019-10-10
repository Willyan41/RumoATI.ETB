using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RumoATI.ETB.Domain2.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RumoATI.ETB.Domain2.Map
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("BS_010_PERFIL");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Descricao)
                   .HasColumnName("DESCRICAO")
                   .HasColumnType("VARCHAR(200)");
        }
    }
}
