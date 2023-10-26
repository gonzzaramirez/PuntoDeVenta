using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private CD_Compra ocd_compra = new CD_Compra();
        public List<Compra> ObtenerCompras()
        {
            return ocd_compra.ObtenerCompras();
        }

        public bool AgregarCompra(Compra compra)
        {
            // Puedes agregar validaciones u otra lógica de negocio aquí antes de llamar al método en la capa de datos.
            return ocd_compra.AgregarCompra(compra);
        }
    }
}
