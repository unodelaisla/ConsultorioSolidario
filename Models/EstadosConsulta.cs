using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class EstadosConsulta
    {
        public EstadosConsulta()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int EcoCod { get; set; }
        public string EcoDes { get; set; } = null!;

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
