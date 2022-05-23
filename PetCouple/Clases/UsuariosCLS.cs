using PetCouple.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PetCouple.Clases
{
    public class UsuariosCLS
    {
        public string Ingresar(Usuario user)
        {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                int nveces = db.Usuario.Where(x => x.Usuario1 == user.Usuario1 && x.Contraseña == user.Contraseña).Count();
                if (nveces != 0)
                {
                    return "Todo Ok";
                }
            }
            return "Nada Ok";
        }
        public string Reg(Usuario user,byte[] image)
        {
            using (PetCoupleContext db = new PetCoupleContext()) {

                Usuario setUsuario = new Usuario();

                setUsuario.Usuario1 = user.Usuario1;
                setUsuario.Contraseña = user.Contraseña;
                setUsuario.Correo = user.Correo;
                setUsuario.Delegacion = user.Delegacion;
                setUsuario.NombreMascota = user.NombreMascota;
                setUsuario.EdadMascota = user.EdadMascota;
                setUsuario.Sexo =  user.Sexo;
                setUsuario.Foto = image;
                setUsuario.Raza = user.Raza;
                setUsuario.NombreCompleto = user.NombreCompleto;
                setUsuario.NumeroTel = user.NumeroTel;

                try
                {
                    db.Usuario.Add(setUsuario);

                    db.SaveChanges();

                    return "Todo bien";
                }
                catch (System.Exception ex)
                {

                    return "Todo Mal + " + ex.Message;
                }
            }
        }
    }
}

