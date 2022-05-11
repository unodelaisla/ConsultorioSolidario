using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Consulta
    {
        public Consulta()
        {
            ConsultaMedicamentos = new HashSet<ConsultaMedicamento>();
            ConsultaPruebas = new HashSet<ConsultaPrueba>();
        }

        public int ConCod { get; set; }
        public DateTime ConFch { get; set; }
        public int ConPac { get; set; }
        public int ConTes { get; set; }
        public string? ConMot { get; set; }
        public int ConSan { get; set; }
        public int ConEsp { get; set; }
        public int ConEco { get; set; }
        public string? ConPat { get; set; }
        public string? ConTra { get; set; }

        public virtual EstadosConsulta ConEcoNavigation { get; set; } = null!;
        public virtual Especialista ConEspNavigation { get; set; } = null!;
        public virtual Paciente ConPacNavigation { get; set; } = null!;
        public virtual Sanitario ConSanNavigation { get; set; } = null!;
        public virtual TiposEspecialista ConTesNavigation { get; set; } = null!;
        public virtual ICollection<ConsultaMedicamento> ConsultaMedicamentos { get; set; }
        public virtual ICollection<ConsultaPrueba> ConsultaPruebas { get; set; }
    }
}
