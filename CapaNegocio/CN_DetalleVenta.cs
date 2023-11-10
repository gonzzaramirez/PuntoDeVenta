using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_DetalleVenta
    {

        private CD_DetalleVenta ocd_venta = new CD_DetalleVenta();
        public List<DetalleVenta> ObtenerDetallesVenta(int IdVenta)
        {
            return ocd_venta.ObtenerDetallesVenta(IdVenta);
        }

        public bool AgregarDetalleVenta(DetalleVenta detalleVenta)
        {
            return ocd_venta.AgregarDetalleVenta(detalleVenta);
        }

        public Dictionary<string, decimal> ObtenerGananciasPorCategoria(FranjaHoraria franjaHoraria)
        {
            return ocd_venta.ObtenerGananciasPorCategoria(franjaHoraria);
        }

    }
}
