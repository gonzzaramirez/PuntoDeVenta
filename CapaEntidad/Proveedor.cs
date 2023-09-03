using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
