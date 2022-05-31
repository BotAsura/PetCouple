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
            InteraccionUsuario1Navigation = new HashSet<Interaccion>();
            InteraccionUsuario2Navigation = new HashSet<Interaccion>();
            LikesUsuario1Navigation = new HashSet<Likes>();
            LikesUsuario2Navigation = new HashSet<Likes>();
        }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public string Delegacion { get; set; }
        public string NombreMascota { get; set; }
        public string EdadMascota { get; set; }
        public string Sexo { get; set; }
        public byte[] Foto { get; set; }
        public int IdTipo { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroTel { get; set; }
        public string Identficador { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ICollection<Interaccion> InteraccionUsuario1Navigation { get; set; }
        public virtual ICollection<Interaccion> InteraccionUsuario2Navigation { get; set; }
        public virtual ICollection<Likes> LikesUsuario1Navigation { get; set; }
        public virtual ICollection<Likes> LikesUsuario2Navigation { get; set; }
    }
}
