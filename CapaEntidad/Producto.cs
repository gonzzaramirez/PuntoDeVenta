using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Categoria oCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra {  get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado {  get; set; }
        public DateTime FechaRegistro { get; set; }

        public string codigoProducto { get; set; }


    }
}
