﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RumoATI.ETB.Domain2.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        public Professor Professor { get; set; }
    }
}
