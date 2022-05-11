using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class TiposEspecialistum
    {
        public TiposEspecialistum()
        {
            Consulta = new HashSet<Consulta>();
            Especialista = new HashSet<Especialista>();
        }

        public int TesCod { get; set; }
        public string TesDes { get; set; } = null!;

        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Especialista> Especialista { get; set; }
    }
}
