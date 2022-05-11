using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class ConsultaPrueba
    {
        public int CprCon { get; set; }
        public int CprPru { get; set; }
        public DateTime CprFch { get; set; }
        public string? CprDes { get; set; }

        public virtual Consulta CprConNavigation { get; set; } = null!;
        public virtual Prueba CprPruNavigation { get; set; } = null!;
    }
}
