using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                insertar();

                Modificar();

                CambiarEstado();

            }
            catch (Exception ex)
            {
                //si hay error sale por aca
                Console.WriteLine(ex.Message);
                throw;
            }

            Console.ReadKey();

        }

        private static void insertar()
        {

            try
            {
                //aca ponemos todo el codigo
                Usuario usuario = new Usuario();

                usuario.Nombre = "Pepe";
                usuario.Apellido = "Argento";
                usuario.Email = "pepe@argento.com.ar";
                usuario.Direccion = "Triunvirato 123";
                usuario.Clave = "123";
                usuario.TipoUsuario = Negocio.Enumerables.TipoUsuarios.Alumno;
                usuario.Edad = 25;
                usuario.Activo = true;
                usuario.Permiso = Permiso.Obtener(2);
                usuario.FechaNacimiento = Convert.ToDateTime("01/01/1990 00:00:00");
                usuario.Estado = Negocio.Enumerables.Estados.Activo;

                int idUsuario = usuario.Grabar();

                Console.WriteLine(string.Format("Se inserto el usuario con exito Id:{0}", idUsuario));



            }
            catch (Exception ex)
            {
                //si hay error sale por aca
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void Modificar()
        {

            try
            {
                //aca ponemos todo el codigo                
                Usuario usuario = Usuario.Obtener(2008);
                usuario.Direccion = "Triunvirato 123";
                int idUsuario = usuario.Grabar();

                Console.WriteLine(string.Format("Se inserto el usuario con exito Id:{0}", idUsuario));



            }
            catch (Exception ex)
            {
                //si hay error sale por aca
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void CambiarEstado()
        {

            try
            {
                //aca ponemos todo el codigo                
                Usuario usuario = Usuario.Obtener(2008);
                Usuario.CambiarEstado(2008, Negocio.Enumerables.Estados.Finalizado);

            }
            catch (Exception ex)
            {
                //si hay error sale por aca
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
