using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Especialista
    {
        public Especialista()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int EspUsu { get; set; }
        public string EspNco { get; set; } = null!;
        public string? EspDes { get; set; }
        public int EspTes { get; set; }
        public bool EspTri { get; set; }

        public virtual TiposEspecialistum EspTesNavigation { get; set; } = null!;
        public virtual Usuario EspUsuNavigation { get; set; } = null!;
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
