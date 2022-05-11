using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Ciudades = new HashSet<Ciudade>();
            Usuarios = new HashSet<Usuario>();
        }

        public int ProCod { get; set; }
        public string ProNom { get; set; } = null!;
        public int ProPai { get; set; }

        public virtual Paise ProPaiNavigation { get; set; } = null!;
        public virtual ICollection<Ciudade> Ciudades { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
