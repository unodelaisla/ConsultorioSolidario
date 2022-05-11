using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Idioma
    {
        public Idioma()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdiCod { get; set; }
        public string IdiNom { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
