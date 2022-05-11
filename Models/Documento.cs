using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Documento
    {
        public int DocCod { get; set; }
        public int DocUsu { get; set; }
        public int DocTdc { get; set; }
        public DateTime? DocFch { get; set; }
        public string? DocDes { get; set; }
        public bool DocAce { get; set; }

        public virtual TiposDocumento DocTdcNavigation { get; set; } = null!;
        public virtual Usuario DocUsuNavigation { get; set; } = null!;
    }
}
