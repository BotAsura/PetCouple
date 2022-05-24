using PetCouple.Models;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PetCouple.Clases
{
    public class UsuariosCLS
    {

        private static int UserScreen;
        private static int usuario;        


        public int Usuario { get => usuario; set => usuario = value; }

        public bool Ingresar(Usuarios user)
        {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                int nveces = db.Usuarios.Where(x => x.Usuario == user.Usuario.ToLower() && x.Contraseña == user.Contraseña.ToLower()).Count();
                
                if (nveces != 0)
                {
                    Usuario = db.Usuarios.Where(x => x.Usuario == user.Usuario.ToLower() && x.Contraseña == user.Contraseña.ToLower()).First().IdUsuario;
                    return true;
                }
            }
            return false;
        }
        public string Reg(Usuarios user,byte[] image,string fileName,string path)
        {
            using (PetCoupleContext db = new PetCoupleContext()) {

                Usuarios setUsuario = new Usuarios();
                
                setUsuario.Usuario = user.Usuario.ToLower();
                setUsuario.Contraseña = user.Contraseña.ToLower();
                setUsuario.Correo = user.Correo;
                setUsuario.Delegacion = user.Delegacion;
                setUsuario.NombreMascota = user.NombreMascota;
                setUsuario.EdadMascota = user.EdadMascota;
                setUsuario.Sexo =  user.Sexo;
                setUsuario.Foto = image;
                setUsuario.Raza = user.Raza;
                setUsuario.NombreCompleto = user.NombreCompleto;
                setUsuario.NumeroTel = user.NumeroTel;
                setUsuario.Identficador = fileName;
                
                try
                {
                    db.Usuarios.Add(setUsuario);

                    db.SaveChanges();
                    
                    return "Todo bien";
                }
                catch (System.Exception ex)
                {

                    return "Todo Mal + " + ex.Message;
                }
            }
        }
        public byte[] getImage() {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                var getLength = db.Usuarios.Count();
                for (int i = 1; i <= getLength; i++)
                {
                    var getUsuario = db.Usuarios.Where(x => x.IdUsuario == i).First();
                    var getLike = db.Likes.Where(x => x.Usuario2 == getUsuario.IdUsuario).FirstOrDefault();
                    if (getLike != null)
                    {
                        if (!(getLike.Like == "Si" || getLike.Like == "No"))
                        {
                            UserScreen = getUsuario.IdUsuario;
                            return getUsuario.Foto;
                        }
                    }
                    else
                    {
                        if (getUsuario.IdUsuario != Usuario)
                        {
                            UserScreen = getUsuario.IdUsuario;
                            return getUsuario.Foto; 
                        }
                    }
                }                
                return null;
            }            
        }
        public void aceptar() {
            using (PetCoupleContext db = new PetCoupleContext()) {
                var getUsuario2 = db.Usuarios.Where(x => x.IdUsuario == UserScreen).First().IdUsuario;
                Likes setLikes = new Likes();
                setLikes.Usuario1 = Usuario;
                setLikes.Usuario2 = getUsuario2;
                setLikes.Like = "Si";
                db.Likes.Add(setLikes);

                db.SaveChanges();
            }        
        }
        public void rechazar() {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                var getUsuario2 = db.Usuarios.Where(x => x.IdUsuario == UserScreen).First().IdUsuario;
                Likes setLikes = new Likes();
                setLikes.Usuario1 = Usuario;
                setLikes.Usuario2 = getUsuario2;
                setLikes.Like = "No";
                db.Likes.Add(setLikes);

                db.SaveChanges();
            }

        }        
    }
}

