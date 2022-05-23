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
        public IActionResult Login(Usuario usuario)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registro()
        {
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Usuario usuario, IFormFile image)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/img/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create)) {
                image.CopyTo(fileStream);
            }            
            
            ViewBag.Mensaje = new UsuariosCLS().Reg(usuario,Imagen_A_Bytes(path));            
            
            ViewBag.Bool = true;
            
            return View();
        }
        public Byte[] Imagen_A_Bytes(String ruta)

        {
            FileStream foto = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Byte[] arreglo = new Byte[foto.Length];

            BinaryReader reader = new BinaryReader(foto);

            arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));

            return arreglo;

        }
        [HttpGet]
        public IActionResult Inicio() {
            return View();
        }
        [HttpPost]
        public IActionResult Aceptar(string aceptar) {            
            return RedirectToAction("Inicio");
        }
        [HttpPost]
        public IActionResult Rechazar(string rechazar) {            
            return RedirectToAction("Inicio");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
