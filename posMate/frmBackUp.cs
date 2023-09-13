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
    }
}
