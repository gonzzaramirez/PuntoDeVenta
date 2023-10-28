using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class CN_DetalleCompra
    {
        private CD_DetalleCompra datosDetalleCompra;

        public CN_DetalleCompra()
        {
            datosDetalleCompra = new CD_DetalleCompra();
        }

        public List<DetalleCompra> ObtenerDetallesCompra(int idCompra)
        {
            try
            {
                // Puedes agregar aquí la lógica adicional que necesites antes o después de acceder a la capa de datos.
                return datosDetalleCompra.ObtenerDetallesCompra(idCompra);
            }
            catch (Exception ex)
            {
                // Manejo de errores aquí
                return new List<DetalleCompra>();
            }
        }

        public bool AgregarDetalleCompra(DetalleCompra detalleCompra)
        {
            try
            {
                // Puedes agregar aquí la lógica adicional que necesites antes de agregar el detalle de compra.
                return datosDetalleCompra.AgregarDetalleCompra(detalleCompra);
            }
            catch (Exception ex)
            {
                // Manejo de errores aquí
                return false;
            }
        }
    }
}
