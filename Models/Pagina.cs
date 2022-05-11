using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Pagina
    {
        public Pagina()
        {
            RpaRols = new HashSet<Role>();
        }

        public int PagCod { get; set; }
        public string PagNom { get; set; } = null!;

        public virtual ICollection<Role> RpaRols { get; set; }
    }
}
