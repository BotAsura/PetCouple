using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class UsuariosNormales
    {
        public int IdUsuarioNormal { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroTel { get; set; }
        public int IdDelegacion { get; set; }
        public int IdMascota { get; set; }
        public int? IdInteraccion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Delegacion IdDelegacionNavigation { get; set; }
        public virtual Interaccion IdInteraccionNavigation { get; set; }
        public virtual Mascotas IdMascotaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
