using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Notificacion
    {
        #region Propiedades

        public int? IdNotificacion { get; set; }
        public Usuario IdUsuarioReceptor { get; set; }
        public Usuario IdUsuarioEmisor { get; set; }
        public string Descripcion { get; set; }
        public Enumerables.Vista Vista { get; set; }
        public DateTime Fecha { get; set; }
        #endregion

        #region Constructores
        public Notificacion()
        { }
        public Notificacion(int idNotificacion, Usuario idUsuarioEmisor, Usuario idUsuarioReceptor, Enumerables.Vista vista, string descripcion, DateTime fecha)
        {
            IdNotificacion = idNotificacion;
            IdUsuarioEmisor = idUsuarioEmisor;
            IdUsuarioReceptor = idUsuarioReceptor;
            Vista = vista;
            Descripcion = descripcion;
            Fecha = fecha;
 
        }
        #endregion
    }
}
