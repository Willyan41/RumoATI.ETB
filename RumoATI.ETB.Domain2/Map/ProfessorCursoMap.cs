﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RumoATI.ETB.Domain2.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using umoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Domain2.Map
{
    public class ProfessorCursoMap : IEntityTypeConfiguration<ProfessorCurso>
    {
        public void Configure(EntityTypeBuilder<ProfessorCurso> builder)
        {
            builder.ToTable("BS_003_PROFESSOR_CURSO");

            builder.HasKey(k => new { k.IdCurso, k.IdProfessor });
        }
    }
}