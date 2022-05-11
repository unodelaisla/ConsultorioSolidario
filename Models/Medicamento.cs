using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Medicamento
    {
        public Medicamento()
        {
            ConsultaMedicamentos = new HashSet<ConsultaMedicamento>();
        }

        public int MedCod { get; set; }
        public string MedNom { get; set; } = null!;
        public string? MedFor { get; set; }
        public string? MedPos { get; set; }

        public virtual ICollection<ConsultaMedicamento> ConsultaMedicamentos { get; set; }
    }
}
