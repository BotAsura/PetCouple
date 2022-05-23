using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PetCouple.Models
{
    public partial class Interaccion
    {
        public Interaccion()
        {
            UsuariosNormales = new HashSet<UsuariosNormales>();
        }

        public int IdInteraccion { get; set; }
        public int IdNotificacion { get; set; }
        public int IdMensaje { get; set; }

        public virtual Mensajes IdMensajeNavigation { get; set; }
        public virtual Notificaciones IdNotificacionNavigation { get; set; }
        public virtual ICollection<UsuariosNormales> UsuariosNormales { get; set; }
    }
}
