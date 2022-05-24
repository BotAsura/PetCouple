using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Parques
    {
        public Parques()
        {
            Interaccion = new HashSet<Interaccion>();
        }

        public int IdParque { get; set; }
        public string Lugar { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Interaccion> Interaccion { get; set; }
    }
}
