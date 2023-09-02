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
        public string nombre { get; set; }
        public string Apellido { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }   
        public string Email {  get; set; }
        public string Direccion {  get; set; }
        public String FechaNacimiento { get; set; }
        public string telefono { get; set; }
        public bool Estado { get; set; }
        public Rol oRol { get; set; }
    }
}
