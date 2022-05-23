using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Delegacion
    {
        public Delegacion()
        {
            UsuariosNormales = new HashSet<UsuariosNormales>();
        }

        public int IdDelegacion { get; set; }
        public string Delegacion1 { get; set; }

        public virtual ICollection<UsuariosNormales> UsuariosNormales { get; set; }
    }
}
