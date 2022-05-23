using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Notificaciones
    {
        public Notificaciones()
        {
            Interaccion = new HashSet<Interaccion>();
        }

        public int IdNotificaciones { get; set; }
        public bool Aceptacion { get; set; }
        public int IdUsuarioNormal { get; set; }
        public int IdMascota { get; set; }

        public virtual ICollection<Interaccion> Interaccion { get; set; }
    }
}
