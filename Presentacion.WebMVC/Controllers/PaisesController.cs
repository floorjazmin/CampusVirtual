using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.WebMVC.Controllers
{
    public class PaisesController : Controller
    {       
        public ActionResult Alta()
        {
            return View(new Negocio.Pais());
        }

        [HttpPost]
        public ActionResult Crear(Negocio.Pais pais)
        {
            //pais.grabar()
            return RedirectToAction("Alta");
        }
    }
}
