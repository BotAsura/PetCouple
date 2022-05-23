using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Mascotas
    {
        public Mascotas()
        {
            UsuariosNormales = new HashSet<UsuariosNormales>();
        }

        public int IdMascota { get; set; }
        public string NombreMascota { get; set; }
        public string EdadMascota { get; set; }
        public string Sexo { get; set; }
        public byte[] Foto { get; set; }
        public string Raza { get; set; }

        public virtual ICollection<UsuariosNormales> UsuariosNormales { get; set; }
    }
}
