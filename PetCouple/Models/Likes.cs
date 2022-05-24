using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Likes
    {
        public int IdLikes { get; set; }
        public int? Usuario1 { get; set; }
        public int? Usuario2 { get; set; }
        public string Like { get; set; }
        public bool Visibilidad { get; set; }

        public virtual Usuarios Usuario1Navigation { get; set; }
        public virtual Usuarios Usuario2Navigation { get; set; }
    }
}
