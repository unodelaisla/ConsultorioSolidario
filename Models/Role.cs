using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
            RpaPags = new HashSet<Pagina>();
        }

        public int RolCod { get; set; }
        public string RolDes { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Pagina> RpaPags { get; set; }
    }
}
