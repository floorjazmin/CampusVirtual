using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(Negocio.Usuario.Listar());
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Negocio.Usuario.CambiarEstado(id, Entidades.Enumerables.Estados.Inactivo);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edicion(int id=0)
        {

            if(id==0)
                return View(new Entidades.Usuario());
            else
                return View(Negocio.Usuario.Obtener(id));
        }

        [HttpPost]
        public ActionResult Grabar(Entidades.Usuario usuario)
        {
            Negocio.Usuario.Grabar(usuario);
            return RedirectToAction("index");
        }

    }
}
