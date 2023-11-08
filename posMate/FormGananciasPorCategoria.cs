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
            Dictionary<string, decimal> gananciasPorCategoria = cnDetalleVenta.ObtenerGananciasPorCategoria();

            foreach (KeyValuePair<string, decimal> entry in gananciasPorCategoria)
            {
                // Agrega un punto al gráfico con el nombre de la categoría y las ganancias como etiqueta
                var point = new DataPoint();
                point.SetValueXY(entry.Key, entry.Value);
                point.Label = entry.Key + " " + string.Format("{0:C}", entry.Value);
                chart1.Series["Series1"].Points.Add(point);
            }

            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
        }


    }
}
