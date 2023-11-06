using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente ocd_cliente = new CD_Cliente();

        public List<Cliente> ObtenerClientes()
        {
            return ocd_cliente.ObtenerClientes();
        }

        public bool AgregarCliente(Cliente cliente)
        {
            return ocd_cliente.AgregarCliente(cliente);
        }

        public Cliente BuscarClientePorDNI(int dni)
        {
            return ocd_cliente.BuscarClientePorDNI(dni);
        }

        public int ObtenerIdClientePorDNI(int dni)
        {
            return ocd_cliente.ObtenerIdClientePorDNI(dni);
        }

    }
}
