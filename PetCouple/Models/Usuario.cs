using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            InteraccionUsuario1Navigation = new HashSet<Interaccion>();
            InteraccionUsuario2Navigation = new HashSet<Interaccion>();
        }

        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public string Delegacion { get; set; }
        public string NombreMascota { get; set; }
        public string EdadMascota { get; set; }
        public string Sexo { get; set; }
        public byte[] Foto { get; set; }
        public string Raza { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroTel { get; set; }

        public virtual ICollection<Interaccion> InteraccionUsuario1Navigation { get; set; }
        public virtual ICollection<Interaccion> InteraccionUsuario2Navigation { get; set; }
    }
}
