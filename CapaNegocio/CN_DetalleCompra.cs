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
                return datosDetalleCompra.ObtenerDetallesCompra(idCompra);
        }

        public bool AgregarDetalleCompra(DetalleCompra detalleCompra)
        {      
                return datosDetalleCompra.AgregarDetalleCompra(detalleCompra);                    
        }
    }
}
