using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class TiposSanitario
    {
        public TiposSanitario()
        {
            Sanitarios = new HashSet<Sanitario>();
        }

        public int TsaCod { get; set; }
        public string TsaDes { get; set; } = null!;

        public virtual ICollection<Sanitario> Sanitarios { get; set; }
    }
}
