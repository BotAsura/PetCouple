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
using System.Web;
using Microsoft.AspNetCore.Http;

namespace PetCouple.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuarios user)
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
        public IActionResult Registro(Usuarios user,Mascotas pet,UsuariosNormales userNorm, List<IFormFile> uploud)
        {            
            ViewBag.Bool = true;
            ViewBag.Mensaje = new UsuariosCLS().Reg(user,pet,userNorm);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
