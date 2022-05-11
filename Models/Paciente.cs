using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
            HistorialPacientes = new HashSet<HistorialPaciente>();
        }

        public int PacUsu { get; set; }
        public string PacSex { get; set; } = null!;
        public DateTime PacFch { get; set; }
        /// <summary>
        /// Grupo sanguineo
        /// </summary>
        public string? PacSan { get; set; }

        public virtual Usuario PacUsuNavigation { get; set; } = null!;
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<HistorialPaciente> HistorialPacientes { get; set; }
    }
}
