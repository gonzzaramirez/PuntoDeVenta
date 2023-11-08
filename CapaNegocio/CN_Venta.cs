using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_Venta ocd_venta = new CD_Venta();

        public List<Venta> ObtenerVentas()
        {
            return ocd_venta.ObtenerVentas();
        }

        public bool AgregarVenta(Venta venta)
        {
            
            return ocd_venta.AgregarVenta(venta);
        }

        public int ObtenerUltimoIDVenta()
        {
            return ocd_venta.ObtenerUltimoIDVenta();
        }
    }
}
