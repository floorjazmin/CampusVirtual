using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Auditorias
    {

        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Auditorias_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Auditorias: " + ex.Message);
            }
        }

        public static int Insertar(Entidades.Auditorias auditorias)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Auditorias_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdAuditorias", auditorias.IdAuditoria));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", auditorias.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Accion", auditorias.Accion));
                    cmd.Parameters.Add(new SqlParameter("@Tabla", auditorias.Tabla));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", auditorias.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@IdObjeto", auditorias.IdObjeto));
                    cmd.Parameters.Add(new SqlParameter("@Objeto", auditorias.Objeto));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la auditoria: " + ex.Message);
            }

        }

    }
}
