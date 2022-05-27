using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCouple.Clases;
using PetCouple.Models;
using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace PetCouple.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            this.hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuarios usuarios)
        {
            if (new UsuariosCLS().Ingresar(usuarios))
            {
                var claims = new List<Claim>
                    {
                        new Claim("Usuario", usuarios.Usuario),
                        new Claim("Contraseña", usuarios.Contraseña),

                    };

                claims.Add(new Claim(ClaimTypes.Role, "Usuario"));

                var claimsIdentityAdmin = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityAdmin));
                return RedirectToAction("Inicio");
            }
            ViewBag.Bool = true;
            return View();
        }

        [HttpGet]
        public IActionResult Registro()
        {
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Usuarios user, IFormFile image)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(image.FileName);
            string fileName = DateTime.Now.ToString("yymmssfff");
            string path = Path.Combine(wwwRootPath + "/img/", fileName + extension);

            using (var fileStream = new FileStream(path, FileMode.Create)) {
                image.CopyTo(fileStream);
            }

            ViewBag.Mensaje = new UsuariosCLS().Reg(user, Imagen_A_Bytes(path), fileName, path);

            ViewBag.Bool = true;

            return RedirectToAction("Login");
        }
        public Byte[] Imagen_A_Bytes(String ruta)
        {
            FileStream foto = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Byte[] arreglo = new Byte[foto.Length];

            BinaryReader reader = new BinaryReader(foto);

            arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));

            return arreglo;

        }
        public IActionResult GetImage() {
            byte[] imagen = new UsuariosCLS().getImage();
            return File(imagen, "image/*");
        }
        [Authorize(Roles = "Usuario")]
        public IActionResult SinAnimales() {
            ViewBag.Usuario = new UsuariosCLS().UserName;
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Usuario")]
        public IActionResult Inicio() {
            ViewBag.Usuario = new UsuariosCLS().UserName;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Usuario")]
        public IActionResult Aceptar() {
            new UsuariosCLS().aceptar();
            ViewBag.Usuario = new UsuariosCLS().UserName;
            return RedirectToAction("Inicio");
        }
        [HttpPost]
        [Authorize(Roles = "Usuario")]
        public IActionResult Rechazar() {
            new UsuariosCLS().rechazar();
            ViewBag.Usuario = new UsuariosCLS().UserName;
            return RedirectToAction("Inicio");
        }

        [Authorize(Roles = "Usuario")]
        public IActionResult Likes()
        {
            ViewBag.Usuario = new UsuariosCLS().UserName;
            return View(new UsuariosCLS().ListUsuarioLikes());
        }
        [Authorize(Roles = "Usuario")]
        public IActionResult GetImageLike(int id) {
            ViewBag.Usuario = new UsuariosCLS().UserName;
            return File(new UsuariosCLS().getImageLike(id), "image/*");
        }
        [HttpPost]
        [Authorize(Roles = "Usuario")]
        public IActionResult AcceptMatch(int IdAceptar)
        {
            new UsuariosCLS().aceptarMatc(IdAceptar);
            return RedirectToAction("Likes");
        }
        [HttpPost]
        [Authorize(Roles = "Usuario")]
        public IActionResult DeniedMatch(int IdDenegar)
        {
            new UsuariosCLS().negarMatch(IdDenegar);
            return RedirectToAction("Likes");
        }
        [Authorize(Roles = "Usuario")]
        public IActionResult Match() {
            ViewBag.Usuario = new UsuariosCLS().UserName;
            return View(new UsuariosCLS().ListUsuariosMatch());
        }
        [HttpGet]
        [Authorize(Roles = "Usuario")]
        public IActionResult Configuracion(){
            ViewBag.Usuario = new UsuariosCLS().UserName;
            ViewBag.Mensaje = "";
            ViewBag.Bool = false;
            return View(new UsuariosCLS().infoUsuario());
        }
        [HttpPost]
        [Authorize(Roles ="Usuario")]
        public IActionResult Configuracion(Usuarios user, IFormFile image) {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(image.FileName);
            string fileName = DateTime.Now.ToString("yymmssfff");
            string path = Path.Combine(wwwRootPath + "/img/", fileName + extension);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            ViewBag.Mensaje = new UsuariosCLS().Modificar(user, Imagen_A_Bytes(path), fileName, path);
            ViewBag.Bool = true;

            return RedirectToAction("Configuracion");
        }
        public async Task<IActionResult> CerrarSesion() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public IActionResult Denegado() {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
