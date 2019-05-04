using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LigaNatacion.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/

        public ActionResult ListadoDeportistas()
        {
            DeportistaNegocio control = new DeportistaNegocio();
            List<Deportista> deportistas = control.ObtenerDeportistas(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            return View(deportistas);
        }

        public ActionResult GraficoDeportistas()
        {
            DeportistaNegocio control = new DeportistaNegocio();
            List<Deportista> deportistas = control.ObtenerDeportistas(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            var deportistasPorAnyo = deportistas.GroupBy(p => p.FechaNacimiento.Year).Select(p => new { Year = p.Key, Cantidad = p.Count() });
            var datosGrafico = "[";
            if (deportistasPorAnyo.Count() > 0)
            {
                foreach (var valor in deportistasPorAnyo)
                {
                    datosGrafico += "['" + valor.Year + "', " + valor.Cantidad + "],";
                }
                datosGrafico = datosGrafico.Substring(0, datosGrafico.Length - 1);
                datosGrafico += "]";
            }
            else
            {
                datosGrafico = "[]";
            }

            ViewBag.DatosGrafico = datosGrafico;
            return View();
        }
    }
}
