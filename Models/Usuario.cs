using System;
using System.Collections.Generic;

namespace ConsultorioSolidario.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Documentos = new HashSet<Documento>();
            MensajeMenUdeNavigations = new HashSet<Mensaje>();
        }

        public int UsuCod { get; set; }
        public string UsuDid { get; set; } = null!;
        public string UsuEma { get; set; } = null!;
        public string UsuNem { get; set; } = null!;
        public string UsuPwh { get; set; } = null!;
        public string UsuNom { get; set; } = null!;
        public string UsuApe { get; set; } = null!;
        public string UsuDir { get; set; } = null!;
        public string? UsuCpo { get; set; }
        public int UsuCiu { get; set; }
        public int UsuPro { get; set; }
        public int UsuPai { get; set; }
        public string? UsuTfn { get; set; }
        public int UsuIdi { get; set; }
        public int UsuRol { get; set; }
        public int UsuEus { get; set; }

        public virtual Ciudad UsuCiuNavigation { get; set; } = null!;
        public virtual EstadosUsuario UsuEusNavigation { get; set; } = null!;
        public virtual Idioma UsuIdiNavigation { get; set; } = null!;
        public virtual Pais UsuPaiNavigation { get; set; } = null!;
        public virtual Provincia UsuProNavigation { get; set; } = null!;
        public virtual Rol UsuRolNavigation { get; set; } = null!;
        public virtual Centro Centro { get; set; } = null!;
        public virtual Colaborador Colaboradore { get; set; } = null!;
        public virtual Especialista Especialista { get; set; } = null!;
        public virtual Mensaje MensajeMenCodNavigation { get; set; } = null!;
        public virtual Paciente Paciente { get; set; } = null!;
        public virtual ICollection<Documento> Documentos { get; set; }
        public virtual ICollection<Mensaje> MensajeMenUdeNavigations { get; set; }
    }
}
