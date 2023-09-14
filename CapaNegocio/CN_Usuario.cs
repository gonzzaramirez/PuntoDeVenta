using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario ocd_usuario = new CD_Usuario();
        public List<Usuario> Listar()
        {
            return ocd_usuario.Listar();
        }


        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje += "Es necesario registrar el nombre del usuario. \n";
            }

            if (string.IsNullOrEmpty(obj.Apellido))
            {
                Mensaje += "Es necesario registrar el apellido del usuario.\n ";
            }

            if (string.IsNullOrEmpty(obj.Clave))
            {
                Mensaje += "Es necesario registrar la clave del usuario.\n ";
            }

            if (string.IsNullOrEmpty(obj.Email))
            {
                Mensaje += "Es necesario registrar el email del usuario.\n ";
            }
            else
            {
                // Validar el formato del correo electrónico
                if (!IsValidEmail(obj.Email))
                {
                    Mensaje += "El formato del correo electrónico no es válido.\n ";
                }
            }

            if (string.IsNullOrEmpty(obj.DNI))
            {
                Mensaje += "Es necesario registrar el DNI del usuario. \n ";
            }

            if (string.IsNullOrEmpty(obj.Direccion))
            {
                Mensaje += "Es necesario registrar la dirección del usuario. \n";
            }



            if (Mensaje == string.Empty)
            {

                return ocd_usuario.Registrar(obj, out Mensaje);
            }
            else
            {
                // Al menos una validación falló
                return -1;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj == null)
            {
                Mensaje = "El objeto de usuario es nulo.";
                return false;
            }

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje += "Es necesario especificar el nombre del usuario. ";
            }

            if (string.IsNullOrEmpty(obj.Apellido))
            {
                Mensaje += "Es necesario especificar el apellido del usuario. ";
            }

            if (string.IsNullOrEmpty(obj.Clave))
            {
                Mensaje += "Es necesario especificar la clave del usuario. ";
            }

            if (string.IsNullOrEmpty(obj.Email))
            {
                Mensaje += "Es necesario especificar el email del usuario. ";
            }
            else
            {
                // Validar el formato del correo electrónico
                if (!IsValidEmail(obj.Email))
                {
                    Mensaje += "El formato del correo electrónico no es válido. ";
                }
            }

            if (string.IsNullOrEmpty(obj.DNI))
            {
                Mensaje += "Es necesario especificar el DNI del usuario. ";
            }

            if (string.IsNullOrEmpty(obj.Direccion))
            {
                Mensaje += "Es necesario especificar la dirección del usuario. ";
            }

           

            if (Mensaje == string.Empty)
            {
                // Todas las validaciones pasaron, llamar al método de edición en la capa de datos
                return ocd_usuario.Editar(obj, out Mensaje);
            }
            else
            {
                // Al menos una validación falló
                return false;
            }
        }
    }
}

