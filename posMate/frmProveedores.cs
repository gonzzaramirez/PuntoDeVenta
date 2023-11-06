using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmProveedores : Form
    {

        private void btnlimpiarCampos_Click(object sender, EventArgs e)
        {

        }

        public frmProveedores()
        {
            InitializeComponent();
            txtBusqueda.TextChanged += new EventHandler(txtBusqueda_TextChanged);
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            // Agregar opciones "Activo" y "No Activo" al ComboBox cboEstado2
            cboEstado2.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado2.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });

            // Configurar el ComboBox cboEstado2 para mostrar el texto y usar el valor al seleccionar
            cboEstado2.DisplayMember = "Texto";
            cboEstado2.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como "Activo"
            cboEstado2.SelectedIndex = 0;

            // Obtener una lista de proveedores y mostrarlos en el dgvData
            List<Proveedor> ObtenerProveedores = new CN_Proveedor().ObtenerProveedores();


            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                // Agregar a cboBusqueda
                if (columna.Visible == true && columna.Name != "Estado")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // Configurar el ComboBox cboBusqueda para mostrar el texto y usar el valor al seleccionar
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como la primera columna visible
            cboBusqueda.SelectedIndex = 0;


            foreach (Proveedor proveedor in ObtenerProveedores)
            {
                string estadoTexto = proveedor.Estado ? "Activo" : "Inactivo";
                dgvData.Rows.Add(
                    proveedor.IdProveedor,
                    proveedor.Documento,
                    proveedor.Nombre,
                    proveedor.Telefono,
                    estadoTexto
                );
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    string valorCelda = row.Cells[columnaFiltro].Value != null ? row.Cells[columnaFiltro].Value.ToString().ToUpper() : "";
                    bool filaVisible = valorCelda.Contains(textoBusqueda);
                    row.Visible = filaVisible;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int indice = e.RowIndex;
                btnGuardar2.Text = "Actualizar datos";

                txtIndice2.Text = indice.ToString();
                txtId2.Text = dgvData.Rows[indice].Cells["IdProveedor"].Value.ToString();

                textNameProvedor.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                textDocumentoProveedor.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                textTelefonoProveedor.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();

                // Obtén el valor de la celda "Estado" en el DataGridView (que debería ser "Activo" o "Inactivo")
                string estadoEnDataGrid = dgvData.Rows[indice].Cells["Estado"].Value.ToString();

                // Establece el ComboBox según el valor de la celda "Estado"
                cboEstado2.SelectedIndex = cboEstado2.FindStringExact(estadoEnDataGrid);
            }
        }

        private void FiltrarUsuarios(bool estadoActivo)
        {
            txtBusqueda.Clear();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                int estadoFila = row.Cells["Estado"].Value.ToString() == "Activo" ? 1 : 0;

                if ((estadoActivo && estadoFila == 1) || (!estadoActivo && estadoFila == 0))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void btnAlta_Click_1(object sender, EventArgs e)
        {
            FiltrarUsuarios(true);

        }

        private void btnBaja_Click_1(object sender, EventArgs e)
        {
            FiltrarUsuarios(false);

        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            // Validar que se hayan completado los campos necesarios, como el nombre del proveedor, documento y teléfono
            if (string.IsNullOrWhiteSpace(textNameProvedor.Text) || string.IsNullOrWhiteSpace(textDocumentoProveedor.Text) || string.IsNullOrWhiteSpace(textTelefonoProveedor.Text) || cboEstado2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            // Crear un objeto de la clase Proveedor con los datos del formulario
            Proveedor proveedor = new Proveedor
            {
                Nombre = textNameProvedor.Text,
                Documento = textDocumentoProveedor.Text,
                Telefono = textTelefonoProveedor.Text,
                Estado = cboEstado2.SelectedIndex == 0, 
            };

            CN_Proveedor negocioProveedor = new CN_Proveedor();

            if (txtId2.Text == "0")
            {
                // Llamar al método de la capa de negocio para agregar el nuevo proveedor
                if (negocioProveedor.AgregarProveedor(proveedor))
                {
                    MessageBox.Show("El proveedor se ha agregado correctamente.");
                    // Puedes realizar acciones adicionales, como limpiar los campos del formulario.
                    limpiarCampos();
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al agregar el proveedor. Verifica la información e inténtalo de nuevo.");
                }
            }
            else
            {
                // Si txtId no es igual a 0, asumimos que deseas editar un proveedor existente.
                int idProveedor = int.Parse(txtId2.Text);
                proveedor.IdProveedor = idProveedor;

                if (negocioProveedor.EditarProveedor(proveedor))
                {
                    MessageBox.Show("El proveedor se ha editado correctamente.");
                    // Puedes realizar acciones adicionales, como limpiar los campos del formulario.
                    limpiarCampos();
                    ActualizarDataGridView();
                }
            }
        }

        private void ActualizarDataGridView()
        {
            // Obtener una nueva lista de proveedores y actualizar el DataGridView
            List<Proveedor> proveedores = new CN_Proveedor().ObtenerProveedores();
            dgvData.Rows.Clear();

            foreach (Proveedor proveedor in proveedores)
            {
                string estadoTexto = proveedor.Estado ? "Activo" : "Inactivo";
                dgvData.Rows.Add(
                    proveedor.IdProveedor,
                    proveedor.Documento,
                    proveedor.Nombre,
                    proveedor.Telefono,
                    estadoTexto
                );
            }
        }

        private void btnlimpiarCampos2_Click(object sender, EventArgs e)
        {
            btnGuardar2.Text = "Guardar";
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            cboEstado.SelectedIndex = -1;
            txtId2.Text = "0";
            textNameProvedor.Clear();
            textDocumentoProveedor.Clear();
            textTelefonoProveedor.Clear();
           
        }

        private void dgvData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
