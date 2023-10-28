using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Usuario  oUsuario { get; set; }
        public Proveedor oProveedor { get; set; }
        public decimal  MontoTotal { get; set; }
        public List <DetalleCompra> DetallesCompra {  get; set; }
        public DateTime FechaRegistro {  get; set; }

    }
}
