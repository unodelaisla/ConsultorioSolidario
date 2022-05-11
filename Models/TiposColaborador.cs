using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class TiposColaborador
    {
        public TiposColaborador()
        {
            Colaboradores = new HashSet<Colaborador>();
        }

        public int TcoCod { get; set; }
        public string TcoDes { get; set; } = null!;

        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
