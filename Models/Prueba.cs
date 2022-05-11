using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Prueba
    {
        public Prueba()
        {
            ConsultaPruebas = new HashSet<ConsultaPrueba>();
        }

        public int PruCod { get; set; }
        public string PruNom { get; set; } = null!;
        public string? PruDes { get; set; }

        public virtual ICollection<ConsultaPrueba> ConsultaPruebas { get; set; }
    }
}
