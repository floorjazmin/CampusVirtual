using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auditorias
    {
        public int? IdAuditoria { get; set; }
        public string Accion { get; set; }
        public int? IdUsuario { get; set; }
        public string Tabla { get; set; }
        public DateTime Fecha { get; set; }
        public int IdObjeto { get; set; }
        public string Objeto { get; set; }

    }
}
