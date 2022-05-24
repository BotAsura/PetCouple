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
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuarios usuarios)
        {
            if (new UsuariosCLS().Ingresar(usuarios))
            {
                return RedirectToAction("Inicio");
            }
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
            
            ViewBag.Mensaje = new UsuariosCLS().Reg(user,Imagen_A_Bytes(path),fileName,path);            
            
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
        public IActionResult SinAnimales() {
            return View();
        }
        [HttpGet]
        public IActionResult Inicio() {
            return View();
        }
        [HttpPost]
        public IActionResult Aceptar() {
            new UsuariosCLS().aceptar();
            return RedirectToAction("Inicio");
        }
        [HttpPost]
        public IActionResult Rechazar() {
            new UsuariosCLS().rechazar();
            return RedirectToAction("Inicio");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
