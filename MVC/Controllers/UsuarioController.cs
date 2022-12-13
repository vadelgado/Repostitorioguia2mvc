using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        usuarioEntities db = new usuarioEntities();
        // GET: Usuario
        public ActionResult Index()
        {
            var list = db.Persona.ToList();

                return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dato = new Persona();
                    dato.PrimerNombre = persona.PrimerNombre;
                    dato.SegundoNombre = persona.SegundoNombre;
                    dato.PrimerApellido = persona.PrimerApellido;
                    dato.SegundoApellido = persona.SegundoApellido;
                    dato.Ciudad = persona.Ciudad;
                    dato.Edad = persona.Edad;

                    db.Persona.Add(dato);
                    db.SaveChanges();
                    TempData["exito"] = "Registro agregado con éxito!";
                    return RedirectToAction("Index");
                }
                return View(persona);
            }
            catch(Exception ex)
            {
                TempData["error"] = "Ha ocurrido un error al crear el registro!";
                return RedirectToAction("Index");
            }
            
        }
    }
}