using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Backup
    {
        public static bool RealizarBackup(string rutaCarpeta)
        {
            try
            {
                // Obtiene la cadena de conexión desde la clase Conexion en la capa de datos
                string connectionString = Conexion.cadena;
                // Nombre del archivo de backup 
                string backupFileName = rutaCarpeta + "\\Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();              
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"BACKUP DATABASE [DB_posnet] TO DISK = '{backupFileName}'";

                        // Ejecuta el comando
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Puedes manejar las excepciones aquí o propagarlas según tu preferencia
                throw ex;
            }
        }
    }
}
   

