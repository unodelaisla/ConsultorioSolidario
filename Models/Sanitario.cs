using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Sanitario
    {
        public Sanitario()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int SanUsu { get; set; }
        public string? SanNco { get; set; }
        public int SanTsa { get; set; }
        public string SanDes { get; set; } = null!;

        public virtual TiposSanitario SanTsaNavigation { get; set; } = null!;
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
