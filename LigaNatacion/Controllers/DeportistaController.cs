using LigaNatacion.Models;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LigaNatacion.Controllers
{
    public class DeportistaController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            var tiposDocumento = new List<SelectListItem>();
            tiposDocumento.Add(new SelectListItem(){
                Text  = "Cédula de Ciudadanía",
                Value = "1"
            });
            tiposDocumento.Add(new SelectListItem(){
                Text  = "Tarjeta de Identidad",
                Value = "2"
            });
            ViewBag.TiposDocumento = tiposDocumento;

            return View(new Deportista());
        }

        [HttpPost]
        public ActionResult Crear(Deportista deportista)
        {
            var tiposDocumento = new List<SelectListItem>();
            tiposDocumento.Add(new SelectListItem()
            {
                Text = "Cédula de Ciudadanía",
                Value = "1"
            });
            tiposDocumento.Add(new SelectListItem()
            {
                Text = "Tarjeta de Identidad",
                Value = "2"
            });
            ViewBag.TiposDocumento = tiposDocumento;

            DeportistaNegocio deportistaNegocio = new DeportistaNegocio();
            Entidades.Deportista nuevoDeportista = new Entidades.Deportista()
            {
                FechaNacimiento = deportista.FechaNacimiento.Value,
                NumeroDocumento = deportista.NumeroDocumento,
                PrimerApellido = deportista.PrimerApellido,
                PrimerNombre = deportista.PrimerNombre,
                SegundoNombre = deportista.SegundoNombre,
                SegundoApellido = deportista.SegundoApellido,
                Sexo = new Entidades.Sexo()
                {
                    Id = deportista.Genero == "M" ? 1 : 2
                },
                TipoDocumento = new Entidades.TipoDocumento()
                {
                    Id  = int.Parse(deportista.TipoDocumento)
                }
            };
            try
            {
                deportistaNegocio.IngresarDeportista(nuevoDeportista);
                ViewBag.Mensaje = "Se ingresó el deportista";
            }
            catch(Exception exc)
            {
                ViewBag.Mensaje = "No se pudo ingresar el deportista";
                //Log.Error(exc);
            }
            return View();
        }
    }
}
