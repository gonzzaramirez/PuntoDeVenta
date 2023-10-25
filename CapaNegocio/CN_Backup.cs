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
        public static bool RealizarBackup(string nombreBaseDeDatos, string rutaCarpeta)
        {
            try
            {
                string connectionString = Conexion.cadena;
                string backupFileName = rutaCarpeta + "\\Backup_" + nombreBaseDeDatos + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"BACKUP DATABASE [{nombreBaseDeDatos}] TO DISK = '{backupFileName}'";
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

      


    }
}
   

