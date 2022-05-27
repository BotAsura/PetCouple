using PetCouple.Models;
using System;
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
        private static string userName;

        public int Usuario { get => usuario; set => usuario = value; }
        public string UserName { get => userName; set => userName = value; }

        public bool Ingresar(Usuarios user)
        {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                int nveces = db.Usuarios.Where(x => x.Usuario == user.Usuario.ToLower() && x.Contraseña == user.Contraseña.ToLower()).Count();
                
                if (nveces != 0)
                {
                    Usuario = db.Usuarios.Where(x => x.Usuario == user.Usuario.ToLower() && x.Contraseña == user.Contraseña.ToLower()).First().IdUsuario;
                    UserName = db.Usuarios.Where(x => x.Usuario == user.Usuario.ToLower() && x.Contraseña == user.Contraseña.ToLower()).First().Usuario.ToUpper();
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
                List<Usuarios> getUsuarios = db.Usuarios.ToList();                
                for (int i = 0; i <= getUsuarios.Count; i++)
                {
                    if (!(getUsuarios[i].IdUsuario == Usuario))
                    {                        
                        var getLike = db.Likes.Where(x => x.Usuario1 == Usuario).ToList();
                        if (getLike.Count != 0)
                        {
                            try
                            {
                                if (!(getLike[i].Like == "Si" || getLike[i].Like == "No")) return null;                                

                            }
                            catch (System.Exception)
                            {
                                try
                                {
                                        if (!(getLike[i-1].Like == "Si" || getLike[i-1].Like == "No")) return null;
                                }
                                catch (System.Exception)
                                {
                                    UserScreen = getUsuarios[i].IdUsuario;
                                    return getUsuarios[i].Foto;
                                }    
                            }                            
                        }
                        else
                        {
                            UserScreen = getUsuarios[i].IdUsuario;
                            return getUsuarios[i].Foto;
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
                setLikes.Visibilidad = true;
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
                setLikes.Visibilidad = false;
                db.Likes.Add(setLikes);

                db.SaveChanges();
            }

        }
        public List<Usuarios> ListUsuarioLikes() {
            using (PetCoupleContext db = new PetCoupleContext()) {
                List<Usuarios> ListUser = new List<Usuarios>();
                var getLikes = db.Likes.Where(x => x.Usuario2 == Usuario).ToList();
                for (int i = 0; i < getLikes.Count; i++)
                {
                    if (getLikes[i].Visibilidad)
                    {
                        ListUser.Add(db.Usuarios.Where(
                                            x => x.IdUsuario == getLikes[i].Usuario1
                                            ).First()); 
                    }
                }
                return ListUser;
            }
        }
        public byte[] getImageLike(int id)
        {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                var getUsuario = db.Usuarios.Where(x => x.IdUsuario == id).First();
                return getUsuario.Foto;
            }
        }
        public void aceptarMatc(int id) {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                Random rd = new Random();
                var getLike = db.Likes.Where(x => x.Usuario1 == id && x.Usuario2 == Usuario).FirstOrDefault();
                var getLugar = db.Parques.ToList();
                if (getLike != null)
                {
                    Interaccion match = new Interaccion();
                    match.Usuario1 = Usuario;
                    match.Usuario2 = id;
                    match.Match = true;
                    match.IdParque = rd.Next(1,getLugar.Count());

                    db.Interaccion.Add(match);

                    getLike.Visibilidad = false;
                    db.SaveChanges();
                }
            }
        }
        public void negarMatch(int id) {
            using (PetCoupleContext db = new PetCoupleContext()) {
                var getLike = db.Likes.Where(x => x.Usuario1 == id && x.Usuario2 == Usuario ).FirstOrDefault();
                if (getLike != null)
                {

                    getLike.Visibilidad = false;
                    db.SaveChanges();
                }
            }
        }
        public List<MatchCLS> ListUsuariosMatch() {
            using (PetCoupleContext db = new PetCoupleContext()) {
                List<MatchCLS> getListUser = new List<MatchCLS>();
                var getMatch = db.Interaccion.Where(x => x.Usuario1 == Usuario).ToList();
                
                for (int i = 0; i <= getMatch.Count; i++)
                {
                    try
                    {
                        var getUsuario2 = db.Usuarios.Where(x => x.IdUsuario == getMatch[i].Usuario2).FirstOrDefault();
                        if (getUsuario2 != null)
                        {
                            string nombre = getUsuario2.NombreCompleto;
                            string lugar = db.Parques.Where(x => x.IdParque == getMatch[i].IdParque).First().Lugar;
                            string url = db.Parques.Where(x => x.IdParque == getMatch[i].IdParque).First().Url;

                            getListUser.Add(new MatchCLS { Nombre = nombre, Lugar = lugar, Url = url });
                        }
                    }
                    catch (System.Exception)
                    {
                        return getListUser;
                    }

                }
                return getListUser;
            }
        }
        public string Modificar(Usuarios user, byte[] image, string fileName, string path)
        {
            using (PetCoupleContext db = new PetCoupleContext())
            {
                Usuarios setUsuario = db.Usuarios.Where(x => x.IdUsuario == usuario).First();

                setUsuario.Usuario = user.Usuario.ToLower();
                setUsuario.Contraseña = user.Contraseña.ToLower();
                setUsuario.Correo = user.Correo;
                setUsuario.Delegacion = user.Delegacion;
                setUsuario.NombreMascota = user.NombreMascota;
                setUsuario.EdadMascota = user.EdadMascota;
                setUsuario.Sexo = user.Sexo;
                if (image != null)
                {
                    setUsuario.Foto = image; 
                }
                setUsuario.Raza = user.Raza;
                setUsuario.NombreCompleto = user.NombreCompleto;
                setUsuario.NumeroTel = user.NumeroTel;
                setUsuario.Identficador = fileName;

                try
                {
                    db.Usuarios.Update(setUsuario);

                    db.SaveChanges();

                    return "Todo bien";
                }
                catch (System.Exception ex)
                {

                    return "Todo Mal + " + ex.Message;
                }
            }
        }
        public List<Usuarios> infoUsuario() {
            using (PetCoupleContext db = new PetCoupleContext()) {
                var getUsuario = db.Usuarios.Where(x => x.IdUsuario == usuario).ToList();
                return getUsuario;
            }
        }

    }
}

