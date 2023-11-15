using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;
using CapaEntidad;
using CapaPresentacion.Utilidades;
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion
{
    public partial class FormGananciasPorCategoria : Form
    {
        private CN_DetalleVenta cnDetalleVenta = new CN_DetalleVenta();

        public FormGananciasPorCategoria()
        {
            InitializeComponent();
        }

        private void FormGananciasPorCategoria_Load(object sender, EventArgs e)
        {
            ActualizarGananciasPorCategoria(FranjaHoraria.Total);


        }

        private void ActualizarGananciasPorCategoria(FranjaHoraria franjaHoraria)
        {
            Dictionary<string, decimal> gananciasPorCategoria = cnDetalleVenta.ObtenerGananciasPorCategoria(franjaHoraria);

            // Limpia el gráfico y el DataGridView
            chart1.Series["Series1"].Points.Clear();
            dataGridView1.Rows.Clear();

            foreach (KeyValuePair<string, decimal> entry in gananciasPorCategoria)
            {
                // Agrega un punto al gráfico con el nombre de la categoría y las ganancias como etiqueta
                var point = new DataPoint();
                point.SetValueXY(entry.Key, entry.Value);
                point.Label = entry.Key + " " + string.Format("{0:C}", entry.Value);
                point["Exploded"] = "true"; // separacion de cada porción
                chart1.Series["Series1"].Points.Add(point);

                // Agrega una fila al DataGridView con el nombre de la categoría y las ganancias
                dataGridView1.Rows.Add(entry.Key, string.Format("{0:C}", entry.Value));
            }

            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true; // habilita efecto 3D
        }

        private void btnMañana_Click(object sender, EventArgs e)
        {
            ActualizarGananciasPorCategoria(FranjaHoraria.Mañana);
        }

        private void btnTarde_Click(object sender, EventArgs e)
        {
            ActualizarGananciasPorCategoria(FranjaHoraria.Tarde);
        }

        private void btnNoche_Click(object sender, EventArgs e)
        {
            ActualizarGananciasPorCategoria(FranjaHoraria.Noche);
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            ActualizarGananciasPorCategoria(FranjaHoraria.Total);
        }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
    }   
    
}
