using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestNegocio
{
    [TestClass]
    public class Auditorias
    {

        [TestMethod]
        public void Listar()
        {
            List<Entidades.Auditorias> listaAuditorias = Negocio.Auditorias.Listar();
        }



    }
}