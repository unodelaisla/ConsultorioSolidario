using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class ConsultaMedicamento
    {
        public int CmeCon { get; set; }
        public int CmeMed { get; set; }
        public string? CmeDes { get; set; }
        public DateTime CmeFch { get; set; }

        public virtual Consulta CmeConNavigation { get; set; } = null!;
        public virtual Medicamento CmeMedNavigation { get; set; } = null!;
    }
}
