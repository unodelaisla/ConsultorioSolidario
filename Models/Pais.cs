using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Provincia = new HashSet<Provincia>();
            Usuarios = new HashSet<Usuario>();
        }

        public int PaiCod { get; set; }
        public string PaiNom { get; set; } = null!;

        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
