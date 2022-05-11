using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class EstadosUsuario
    {
        public EstadosUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int EusCod { get; set; }
        public string? EusDes { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
