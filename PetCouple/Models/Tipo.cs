using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
