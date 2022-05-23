using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Mensajes
    {
        public Mensajes()
        {
            Interaccion = new HashSet<Interaccion>();
        }

        public int IdMensaje { get; set; }
        public string Mensaje { get; set; }
        public bool ActivarChat { get; set; }

        public virtual ICollection<Interaccion> Interaccion { get; set; }
    }
}
