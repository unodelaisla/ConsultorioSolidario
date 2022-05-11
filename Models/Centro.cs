using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Centro
    {
        public Centro()
        {
            SceSvcs = new HashSet<Servicio>();
        }

        public int CenUsu { get; set; }
        public string CenNom { get; set; } = null!;
        public string? CenDes { get; set; }

        public virtual Usuario CenUsuNavigation { get; set; } = null!;

        public virtual ICollection<Servicio> SceSvcs { get; set; }
    }
}
