using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Colaborador
    {
        public int ColUsu { get; set; }
        public int ColTco { get; set; }
        public string? ColDes { get; set; }
        public string? ColNco { get; set; }

        public virtual TiposColaborador ColTcoNavigation { get; set; } = null!;
        public virtual Usuario ColUsuNavigation { get; set; } = null!;
    }
}
