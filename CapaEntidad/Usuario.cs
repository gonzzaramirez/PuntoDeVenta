using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
      
        public string Clave { get; set; }   
        public string Email {  get; set; }
        public string DNI { get; set; }
        public string Direccion {  get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public Rol oRol { get; set; }
    }
}
