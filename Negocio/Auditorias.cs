using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Auditorias
    {
    
        #region Metodos publicos
        public static List<Entidades.Auditorias> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Auditorias.Listar();

            List<Entidades.Auditorias> listaAuditorias = new List<Entidades.Auditorias>();

            foreach (DataRow item in dt.Rows)
            {
                listaAuditorias.Add(ArmarDatos(item));
            }


            return listaAuditorias;
        }

 
        #endregion

        #region Metodos privados
        private static int Insertar(Entidades.Auditorias auditorias)
        {
            return Datos.Auditorias.Insertar(auditorias);
        }

        public static Entidades.Auditorias ArmarDatos(DataRow item)
        {
            Entidades.Auditorias auditorias = new Entidades.Auditorias();

            auditorias.IdAuditoria = Convert.ToInt32(item["IdAuditoria"]);
            auditorias.Accion = Convert.ToString(item["Accion"]);
            auditorias.IdUsuario = Convert.ToInt32(item["IdUsuario"]);
            auditorias.Tabla = Convert.ToString(item["Tabla"]);
            auditorias.Fecha = Convert.ToDateTime(item["Fecha"]);
            auditorias.IdObjeto = Convert.ToInt32(item["IdObjeto"]);
            auditorias.Objeto = Convert.ToString(item["Objeto"]);

            return auditorias;
        }
        #endregion
    }
}
