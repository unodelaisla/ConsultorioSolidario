using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class HistorialPaciente
    {
        /// <summary>
        /// clave primaria
        /// </summary>
        public int HpaCod { get; set; }
        /// <summary>
        /// clave foránea al paciente
        /// </summary>
        public int HpaPac { get; set; }
        /// <summary>
        /// cf al tipo de historial ( analítica, informe, resonancia ..)
        /// </summary>
        public int HpaThi { get; set; }
        /// <summary>
        /// fecha de realización de la prueba
        /// </summary>
        public DateTime? HpaFch { get; set; }
        /// <summary>
        /// Descripción  de la prueba
        /// </summary>
        public string? HpaDes { get; set; }

        public virtual Paciente HpaPacNavigation { get; set; } = null!;
        public virtual TipoHistorial HpaThiNavigation { get; set; } = null!;
    }
}
