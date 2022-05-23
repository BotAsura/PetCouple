using PetCouple.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetCouple.Clases
{
    public class UsuariosCLS
    {
        public string Ingresar(Usuarios user) {
            using (PetCoupleContext db = new PetCoupleContext()) {
                int nveces = db.Usuarios.Where(x => x.Usuario == user.Usuario && x.Contraseña == user.Contraseña).Count();
                if (nveces != 0)
                {
                    return "Todo Ok";
                }                
            }
            return "Nada Ok";
        }
        public string Reg(Usuarios user, Mascotas pet, UsuariosNormales userNorm) {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                Usuarios setUser = new Usuarios();

                setUser.Usuario = user.Usuario;
                setUser.Contraseña = user.Contraseña;
                setUser.Correo = user.Correo;
                setUser.Visibilidad = user.Visibilidad;

                db.Usuarios.Add(setUser);
                
                Mascotas setPet = new Mascotas();

                setPet.NombreMascota = pet.NombreMascota;
                setPet.EdadMascota = pet.EdadMascota;
                setPet.Sexo = pet.Sexo;
                setPet.Foto = pet.Foto;
                setPet.Raza = pet.Raza;

                db.Mascotas.Add(setPet);

                UsuariosNormales setUsuarioNormal = new UsuariosNormales();

                setUsuarioNormal.NombreCompleto = userNorm.NombreCompleto;
                setUsuarioNormal.NumeroTel = userNorm.NumeroTel;
                setUsuarioNormal.IdDelegacion = 1;
                setUsuarioNormal.IdMascota = 1;
                setUsuarioNormal.IdInteraccion = null;
                setUsuarioNormal.IdUsuario = 1;

                db.UsuariosNormales.Add(userNorm);

                db.SaveChanges();

                return "Todo bien";
            }
        }
    }
}
