using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Utilidades;

namespace Presentacion.WebMVC.Controllers
{
    public class UsuariosController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Prueba()
        {

            Entidades.Usuario usuario1 = new Entidades.Usuario();
            usuario1.Nombre = "Mati";
            usuario1.Apellido = "Leiva";
            usuario1.TipoUsuario = Entidades.Enumerables.TipoUsuarios.Alumno;
            usuario1.Estado = Entidades.Enumerables.Estados.Activo;
            usuario1.Observaciones = "";

            Negocio.Usuario.Grabar(usuario1);





            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(Negocio.Usuario Usuario)
        {
            try
            {
                Negocio.Usuario UsuarioLogueado = Negocio.Usuario.Obtener(Usuario.Email,Seguridad.Encriptar(Usuario.Clave));
                Session["Usuario"] = UsuarioLogueado;

                if (UsuarioLogueado!=null)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Error", "Home", new { @Mensaje = "El usuario que quiere ingresar es incorrecto" });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult RecuperarClave(Negocio.Usuario Usuario)
        {
            try
            {
                Negocio.Usuario UsuarioLogueado = Negocio.Usuario.Obtener(Usuario.Email);
                Session["Usuario"] = UsuarioLogueado;

                if (UsuarioLogueado != null)
                { 
                    Negocio.Utilidades.Email.Enviar(
                       ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                       Usuario.Email,
                       "Esba",
                       Usuario.Nombre,
                       ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                       ConfigurationManager.AppSettings["Clave"].ToString(),
                       "Recuperar Contraseña",
                       Usuario.Email + " Tu clave es: " + Negocio.Utilidades.Seguridad.DesEncriptar(Usuario.Clave),
                       false,
                       ConfigurationManager.AppSettings["Host"].ToString(),
                       Convert.ToInt32(ConfigurationManager.AppSettings["Puerto"].ToString()),
                       Convert.ToBoolean(ConfigurationManager.AppSettings["UsaSSL"].ToString()));

                        return RedirectToAction("Index", "Home");
                }
                else
                    return RedirectToAction("Error", "Home", new { @Mensaje = "El usuario que quiere ingresar es incorrecto" });
            }
            catch
            {
                return View();
            }
        }
    }
}
