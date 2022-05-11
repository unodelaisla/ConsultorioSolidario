using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class TipoHistorial
    {
        public TipoHistorial()
        {
            HistorialPacientes = new HashSet<HistorialPaciente>();
        }

        public int ThiCod { get; set; }
        /// <summary>
        /// alergia, vacuna, implante, operacion, medicacion, diagnostico, informe, peso, altura..
        /// </summary>
        public string ThiDes { get; set; } = null!;

        public virtual ICollection<HistorialPaciente> HistorialPacientes { get; set; }
    }
}
