using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaDatos;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace CapaPresentacion
{
    public partial class frmBackUp : Form
    {

        public frmBackUp()
        {
            InitializeComponent();
        }

        private void frmBackUp_Load(object sender, EventArgs e)
        {
            CargarBasesDeDatos();
        }

        private void CargarBasesDeDatos()
        {
            try
            {
                // Obtener la lista de bases de datos desde la capa de datos
                DataTable dtBasesDeDatos = BaseDatosDAL.ObtenerBasesDeDatos();

                // Enlazar la lista al ComboBox
                cmbBasesDeDatos.DisplayMember = "name";
                cmbBasesDeDatos.DataSource = dtBasesDeDatos;



            }
            catch (Exception ex)
            {
                // Manejar excepciones o propagarlas según sea necesario
                MessageBox.Show("Error al cargar la lista de bases de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnRealizarBackup_Click_1(object sender, EventArgs e)
        {
            try
            {
                string rutaCarpeta = txtRutaCarpeta.Text;
                string baseDeDatosSeleccionada = cmbBasesDeDatos.Text;

                // Verificar si se ha seleccionado una base de datos
                if (string.IsNullOrEmpty(baseDeDatosSeleccionada))
                {
                    MessageBox.Show("Selecciona una base de datos antes de realizar el respaldo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si la carpeta existe
                if (!Directory.Exists(rutaCarpeta))
                {
                    MessageBox.Show("La carpeta de destino no fue seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar y configurar permisos de escritura en la carpeta seleccionada
                try
                {
                    DirectorySecurity directorySecurity = Directory.GetAccessControl(rutaCarpeta);
                    FileSystemAccessRule accessRule = new FileSystemAccessRule(
                        new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                        FileSystemRights.Write,
                        InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                        PropagationFlags.None,
                        AccessControlType.Allow
                    );

                    directorySecurity.AddAccessRule(accessRule);
                    Directory.SetAccessControl(rutaCarpeta, directorySecurity);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al configurar los permisos en la carpeta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Realizar la copia de seguridad
                if (CN_Backup.RealizarBackup(baseDeDatosSeleccionada, rutaCarpeta))
                {
                    // Muestra un mensaje de éxito
                    MessageBox.Show("Copia de seguridad realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la copia de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura y muestra cualquier error que ocurra
                MessageBox.Show("Error al realizar la copia de seguridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            // Abre un diálogo para seleccionar la carpeta de destino para el archivo de backup
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaCarpeta.Text = folderDialog.SelectedPath;
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            // Mostrar la advertencia antes de buscar el archivo
            DialogResult confirmacionInicial = MessageBox.Show("Antes de importar asegúrese de haber seleccionado la base de datos actual sobre la que trabaja el proyecto. ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacionInicial == DialogResult.No)
            {
                return; // No se buscará el archivo
            }

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos de respaldo de bases de datos (*.bak)|*.bak";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Mostrar un segundo aviso antes de la restauración
                    DialogResult confirmacionRestauracion = MessageBox.Show("Al seleccionar si, todos los registros actuales se reemplazarán por los que contenga el archivo de restauración. ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmacionRestauracion == DialogResult.No)
                    {
                        return; // No se realizará la restauración
                    }

                    string rutaArchivoRespaldo = openFileDialog.FileName;

                    string baseDeDatosSeleccionada = cmbBasesDeDatos.Text; // Tiene que ser igual a la del proyecto db_posnet

                    if (string.IsNullOrEmpty(baseDeDatosSeleccionada))
                    {
                        MessageBox.Show("Selecciona una base de datos antes de realizar la restauración.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Llama a la función para restaurar la base de datos
                    if (CN_Backup.RestaurarBaseDeDatos(baseDeDatosSeleccionada, rutaArchivoRespaldo))
                    {
                        MessageBox.Show("Restauración de base de datos completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo restaurar la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
