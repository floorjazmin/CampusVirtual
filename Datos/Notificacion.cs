using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Notificacion
    {
            public static DataTable Listar()
            {
                try
                {
                    DataTable dt = new DataTable();

                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                    {
                        cn.Open();

                        // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                        SqlCommand cmd = new SqlCommand("SP_Notificaciones_Listar", cn);

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
                    throw new Exception("Error al obtener la lista de notificaciones: " + ex.Message);
                }
            }
        public static DataTable ListarPorUsuarioEmisor(int idUsuarioEmisor)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_ListarPorUsuarioEmisor", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", idUsuarioEmisor));

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
                throw new Exception("Error al obtener la lista de usuarios receptores: " + ex.Message);
            }
        }

        public static DataTable ListarPorUsuarioReceptor(int idUsuarioReceptor)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_ListarPorUsuarioReceptor", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", idUsuarioReceptor));

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
                throw new Exception("Error al obtener la lista de usuarios receptores: " + ex.Message);
            }
        }

        public static int Insertar(Entidades.Notificacion notificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", notificacion.IdUsuarioEmisor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", notificacion.IdUsuarioReceptor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", notificacion.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Vista", notificacion.Vista));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", DateTime.Now));

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
                throw new Exception("Error al insertar la notificacion: " + ex.Message);
            }

        }
        public static void Modificar(Entidades.Notificacion notificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Modificar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", notificacion.IdUsuarioEmisor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", notificacion.IdUsuarioReceptor.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", notificacion.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Vista", notificacion.Vista));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", DateTime.Now));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar la notificacion: " + ex.Message);
            }

        }

        public static void Eliminar(int idNotificacion)
            {
                try
                {
                    DataTable dt = new DataTable();

                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                    {
                        cn.Open();

                        // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                        SqlCommand cmd = new SqlCommand("SP_Notificaciones_Eliminar", cn);

                        //1.A Agregamos parametros a nuestro SP
                        cmd.Parameters.Add(new SqlParameter("@IdNotificacion", idNotificacion));

                        // 2. Especifico el tipo de Comando
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Ejecuto el comando y asigo el valor al DataReader
                        var dataReader = cmd.ExecuteReader();

                        dt.Load(dataReader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al Eliminar la Notificacion: " + ex.Message);
                }
            }
        public static DataTable Buscar(string descripcion)
        {
            return Listar();
        }
        public static void CambiarVista(int idNotificacion, int idVista)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_ModificarEstado", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdNotificacion", idNotificacion));
                    cmd.Parameters.Add(new SqlParameter("@IdVista", idVista));
                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la vista de la notificacion: " + ex.Message);
            }
        }
    }
}

