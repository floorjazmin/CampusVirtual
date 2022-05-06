using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Notificacion
    {

        #region Metodos 
    

        private static Entidades.Notificacion ArmarDatos(DataRow item)
        {
            Entidades.Notificacion notificacion = new Entidades.Notificacion();
            notificacion.IdNotificacion = Convert.ToInt32(item["IdNotificacion"]);
            notificacion.IdUsuarioReceptor.IdUsuario = Convert.ToInt32(item["IdUsuarioReceptor"]);
            notificacion.IdUsuarioEmisor.IdUsuario = Convert.ToInt32(item["IdUsuarioEmisor"]);
            notificacion.Descripcion = Convert.ToString(item["Descripcion"]);
            notificacion.Vista = (Entidades.Enumerables.Vista)item["Vista"];
            notificacion.Fecha = Convert.ToDateTime(item["Fecha"]);


            return notificacion;
        }

        public static List<Entidades.Notificacion> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificacion.Listar();

            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }


            return listaNotificaciones;
        }
        public static List<Entidades.Notificacion> ListarPorUsuarioEmisor(int IdUsuarioEmisor)
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificacion.ListarPorUsuarioEmisor(IdUsuarioEmisor);

            List<Entidades.Notificacion> listaUsuarioEmisor = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaUsuarioEmisor.Add(ArmarDatos(item));
            }


            return listaUsuarioEmisor;
        }
        public static List<Entidades.Notificacion> ListarPorUsuarioReceptor(int IdUsuarioReceptor)
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificacion.ListarPorUsuarioReceptor(IdUsuarioReceptor);

            List<Entidades.Notificacion> listaUsuarioReceptor = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaUsuarioReceptor.Add(ArmarDatos(item));
            }


            return listaUsuarioReceptor;
        }
        public static List<Entidades.Notificacion> Buscar(string descripcion)
        {
            DataTable dt = new DataTable();
            dt = Datos.Notificacion.Buscar(descripcion);
            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }

            return listaNotificaciones;
        }

        public static void Eliminar(int idNotificacion)
        {
            Datos.Notificacion.Eliminar(idNotificacion);
        }

        public static int Insertar(Entidades.Notificacion notificacion)
        {
            return Datos.Notificacion.Insertar(notificacion);
        }

        public static int Modificar(Entidades.Notificacion notificaciones)
        {
            Datos.Notificacion.Modificar(notificaciones);

            return notificaciones.IdNotificacion.Value;
        }

        public static bool Validar(Entidades.Notificacion notificacion, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(notificacion.Descripcion))
                error += "La Descripcion ingresada se encuentra vacia ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        public static void CambiarVista(int idNotificacion, Entidades.Enumerables.Vista vista)
        {
            Datos.Notificacion.CambiarVista(idNotificacion, (int)vista);
        }



        #endregion
    }
}

