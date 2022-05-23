using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Razas
    {
        public Razas()
        {
            Mascotas = new HashSet<Mascotas>();
        }

        public int IdRazas { get; set; }
        public string NombreRaza { get; set; }
        public string TipoMascota { get; set; }

        public virtual ICollection<Mascotas> Mascotas { get; set; }
    }
}
