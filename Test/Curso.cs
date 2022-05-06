using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class Curso
    {
        [TestMethod]
        public void Listar()
        {
            Negocio.Curso.Listar();
        }


        [TestMethod]
        public void Obtener()
        {
            Negocio.Curso.Obtener(1);
        }


        [TestMethod]
        public void Grabar()
        {
            Negocio.Curso curso = new Negocio.Curso();
            curso.Anio = 2021;
            curso.Cuatrimestre = 3;
            curso.Materia = new Negocio.Materia(1,"Materia1" );
            curso.Profesor = Negocio.Usuario.Obtener(1008);



            curso.Grabar();
        }
    }
}
