using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class TiposColaborador
    {
        public TiposColaborador()
        {
            Colaboradores = new HashSet<Colaboradore>();
        }

        public int TcoCod { get; set; }
        public string TcoDes { get; set; } = null!;

        public virtual ICollection<Colaboradore> Colaboradores { get; set; }
    }
}
