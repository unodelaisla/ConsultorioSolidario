using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            SceCens = new HashSet<Centro>();
        }

        public int SvcCod { get; set; }
        public string SvcDes { get; set; } = null!;

        public virtual ICollection<Centro> SceCens { get; set; }
    }
}
