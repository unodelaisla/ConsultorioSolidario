using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Pagina
    {
        public Pagina()
        {
            RpaRols = new HashSet<Rol>();
        }

        public int PagCod { get; set; }
        public string PagNom { get; set; } = null!;

        public virtual ICollection<Rol> RpaRols { get; set; }
    }
}
