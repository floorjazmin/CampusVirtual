using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestNegocio
{
    [TestClass]
    public class Notificaciones
    {
        [TestMethod]
        public void Alta()
        {

            Entidades.Notificacion notificacion = new Entidades.Notificacion();
            notificacion.IdNotificacion = 3;
            notificacion.Descripcion = "Hoy no hay clases";

            Negocio.Notificacion.Insertar(notificacion);

        }

        [TestMethod]
        public void Listar()
        {

            Negocio.Notificacion.Listar();

        }

        [TestMethod]
        public void ListarPorUsuarioEmisor()
        {

            Negocio.Notificacion.ListarPorUsuarioEmisor(11);

        }
        [TestMethod]
        public void ListarPorUsuarioReceptor()
        {

            Negocio.Notificacion.ListarPorUsuarioReceptor(1008);

        }

        [TestMethod]
        public void Modificacion()
        {
            Entidades.Notificacion notificaciones = new Entidades.Notificacion();
            notificaciones.IdNotificacion = 2;
            notificaciones.IdUsuarioEmisor = Negocio.Usuario.Obtener(12);
            notificaciones.IdUsuarioReceptor = Negocio.Usuario.Obtener(1008);

        }

        [TestMethod]
        public void Baja()
        {

            Negocio.Notificacion.Eliminar(3);
        }

 
        [TestMethod]
        public void ModificarEstado()
        {
            Entidades.Notificacion notificaciones = new Entidades.Notificacion();
            Negocio.Notificacion.CambiarVista(1,Entidades.Enumerables.Vista.Visto);
        }



    }
}