using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Mensaje
    {
        public int MenCod { get; set; }
        public DateTime MenFch { get; set; }
        public int MenUor { get; set; }
        public int? MenUde { get; set; }
        public string MenTxt { get; set; } = null!;
        public bool MenLee { get; set; }

        public virtual Usuario MenCodNavigation { get; set; } = null!;
        public virtual Usuario? MenUdeNavigation { get; set; }
    }
}
