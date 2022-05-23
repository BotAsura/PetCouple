using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Administrador = new HashSet<Administrador>();
            UsuariosNormales = new HashSet<UsuariosNormales>();
        }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public bool Visibilidad { get; set; }

        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<UsuariosNormales> UsuariosNormales { get; set; }
    }
}
