using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Interaccion
    {
        public int IdInteraccion { get; set; }
        public int? Usuario1 { get; set; }
        public int? Usuario2 { get; set; }
        public bool? Match { get; set; }

        public virtual Usuario Usuario1Navigation { get; set; }
        public virtual Usuario Usuario2Navigation { get; set; }
    }
}
