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
            bunifuLoader1.Visible = true;
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
                    bunifuLoader1.Visible = false;
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

        

    }
}
