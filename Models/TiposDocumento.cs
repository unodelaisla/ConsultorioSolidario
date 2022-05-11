using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class TiposDocumento
    {
        public TiposDocumento()
        {
            Documentos = new HashSet<Documento>();
        }

        public int TdcCod { get; set; }
        /// <summary>
        /// documento acreditacion, politica privacidad, aviso legal...
        /// </summary>
        public string TdcNom { get; set; } = null!;

        public virtual ICollection<Documento> Documentos { get; set; }
    }
}
