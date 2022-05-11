using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Ciudade
    {
        public Ciudade()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int CiuCod { get; set; }
        public string CiuNom { get; set; } = null!;
        public int CiudPro { get; set; }

        public virtual Provincia CiudProNavigation { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
