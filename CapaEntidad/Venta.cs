using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta{ get; set; }
        public Usuario oUsuario { get; set; }

        public Cliente oCliente { get; set; }
      
       
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal {  get; set; }
        public List <DetalleVenta> DetalleVenta {  get; set; }
        public DateTime FechaRegistro { get; set; }
        
    }
}
