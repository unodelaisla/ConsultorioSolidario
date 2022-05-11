using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Ciudades = new HashSet<Ciudad>();
            Usuarios = new HashSet<Usuario>();
        }

        public int ProCod { get; set; }
        public string ProNom { get; set; } = null!;
        public int ProPai { get; set; }

        public virtual Pais ProPaiNavigation { get; set; } = null!;
        public virtual ICollection<Ciudad> Ciudades { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
