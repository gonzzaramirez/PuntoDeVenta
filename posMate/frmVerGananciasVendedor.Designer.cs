namespace CapaPresentacion
{
    partial class frmVerGananciasVendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chartGananciasMeses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridGananciasMeses = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.dropdownMeses = new Bunifu.UI.WinForms.BunifuDropdown();
            this.dropdownAños = new Bunifu.UI.WinForms.BunifuDropdown();
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciasMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGananciasMeses)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGananciasMeses
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGananciasMeses.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGananciasMeses.Legends.Add(legend1);
            this.chartGananciasMeses.Location = new System.Drawing.Point(28, 49);
            this.chartGananciasMeses.Name = "chartGananciasMeses";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartGananciasMeses.Series.Add(series1);
            this.chartGananciasMeses.Size = new System.Drawing.Size(342, 389);
            this.chartGananciasMeses.TabIndex = 0;
            this.chartGananciasMeses.Text = "chart1";
            // 
            // dataGridGananciasMeses
            // 
            this.dataGridGananciasMeses.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridGananciasMeses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridGananciasMeses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridGananciasMeses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridGananciasMeses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridGananciasMeses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridGananciasMeses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridGananciasMeses.ColumnHeadersHeight = 40;
            this.dataGridGananciasMeses.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dataGridGananciasMeses.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGridGananciasMeses.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridGananciasMeses.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataGridGananciasMeses.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridGananciasMeses.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dataGridGananciasMeses.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataGridGananciasMeses.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridGananciasMeses.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dataGridGananciasMeses.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridGananciasMeses.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dataGridGananciasMeses.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridGananciasMeses.CurrentTheme.Name = null;
            this.dataGridGananciasMeses.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridGananciasMeses.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGridGananciasMeses.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridGananciasMeses.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataGridGananciasMeses.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridGananciasMeses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridGananciasMeses.EnableHeadersVisualStyles = false;
            this.dataGridGananciasMeses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataGridGananciasMeses.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridGananciasMeses.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataGridGananciasMeses.HeaderForeColor = System.Drawing.Color.White;
            this.dataGridGananciasMeses.Location = new System.Drawing.Point(385, 49);
            this.dataGridGananciasMeses.Name = "dataGridGananciasMeses";
            this.dataGridGananciasMeses.RowHeadersVisible = false;
            this.dataGridGananciasMeses.RowTemplate.Height = 40;
            this.dataGridGananciasMeses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridGananciasMeses.Size = new System.Drawing.Size(370, 389);
            this.dataGridGananciasMeses.TabIndex = 1;
            this.dataGridGananciasMeses.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dataGridGananciasMeses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridGananciasMeses_CellContentClick);
            // 
            // dropdownMeses
            // 
            this.dropdownMeses.BackColor = System.Drawing.Color.Transparent;
            this.dropdownMeses.BackgroundColor = System.Drawing.Color.White;
            this.dropdownMeses.BorderColor = System.Drawing.Color.Silver;
            this.dropdownMeses.BorderRadius = 1;
            this.dropdownMeses.Color = System.Drawing.Color.Silver;
            this.dropdownMeses.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dropdownMeses.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownMeses.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dropdownMeses.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownMeses.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dropdownMeses.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.dropdownMeses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dropdownMeses.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dropdownMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownMeses.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdownMeses.FillDropDown = true;
            this.dropdownMeses.FillIndicator = false;
            this.dropdownMeses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownMeses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dropdownMeses.ForeColor = System.Drawing.Color.Black;
            this.dropdownMeses.FormattingEnabled = true;
            this.dropdownMeses.Icon = null;
            this.dropdownMeses.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdownMeses.IndicatorColor = System.Drawing.Color.DarkGray;
            this.dropdownMeses.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdownMeses.IndicatorThickness = 2;
            this.dropdownMeses.IsDropdownOpened = false;
            this.dropdownMeses.ItemBackColor = System.Drawing.Color.White;
            this.dropdownMeses.ItemBorderColor = System.Drawing.Color.White;
            this.dropdownMeses.ItemForeColor = System.Drawing.Color.Black;
            this.dropdownMeses.ItemHeight = 26;
            this.dropdownMeses.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.dropdownMeses.ItemHighLightForeColor = System.Drawing.Color.White;
            this.dropdownMeses.ItemTopMargin = 3;
            this.dropdownMeses.Location = new System.Drawing.Point(165, 11);
            this.dropdownMeses.Name = "dropdownMeses";
            this.dropdownMeses.Size = new System.Drawing.Size(260, 32);
            this.dropdownMeses.TabIndex = 2;
            this.dropdownMeses.Text = null;
            this.dropdownMeses.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdownMeses.TextLeftMargin = 5;
            this.dropdownMeses.SelectedIndexChanged += new System.EventHandler(this.dropdownMeses_SelectedIndexChanged);
            // 
            // dropdownAños
            // 
            this.dropdownAños.BackColor = System.Drawing.Color.Transparent;
            this.dropdownAños.BackgroundColor = System.Drawing.Color.White;
            this.dropdownAños.BorderColor = System.Drawing.Color.Silver;
            this.dropdownAños.BorderRadius = 1;
            this.dropdownAños.Color = System.Drawing.Color.Silver;
            this.dropdownAños.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dropdownAños.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownAños.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dropdownAños.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownAños.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dropdownAños.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.dropdownAños.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dropdownAños.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dropdownAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownAños.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdownAños.FillDropDown = true;
            this.dropdownAños.FillIndicator = false;
            this.dropdownAños.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownAños.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dropdownAños.ForeColor = System.Drawing.Color.Black;
            this.dropdownAños.FormattingEnabled = true;
            this.dropdownAños.Icon = null;
            this.dropdownAños.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdownAños.IndicatorColor = System.Drawing.Color.DarkGray;
            this.dropdownAños.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdownAños.IndicatorThickness = 2;
            this.dropdownAños.IsDropdownOpened = false;
            this.dropdownAños.ItemBackColor = System.Drawing.Color.White;
            this.dropdownAños.ItemBorderColor = System.Drawing.Color.White;
            this.dropdownAños.ItemForeColor = System.Drawing.Color.Black;
            this.dropdownAños.ItemHeight = 26;
            this.dropdownAños.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.dropdownAños.ItemHighLightForeColor = System.Drawing.Color.White;
            this.dropdownAños.ItemTopMargin = 3;
            this.dropdownAños.Location = new System.Drawing.Point(516, 11);
            this.dropdownAños.Name = "dropdownAños";
            this.dropdownAños.Size = new System.Drawing.Size(260, 32);
            this.dropdownAños.TabIndex = 3;
            this.dropdownAños.Text = null;
            this.dropdownAños.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdownAños.TextLeftMargin = 5;
            this.dropdownAños.SelectedIndexChanged += new System.EventHandler(this.dropdownAños_SelectedIndexChanged);
            // 
            // frmVerGananciasVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dropdownAños);
            this.Controls.Add(this.dropdownMeses);
            this.Controls.Add(this.dataGridGananciasMeses);
            this.Controls.Add(this.chartGananciasMeses);
            this.Name = "frmVerGananciasVendedor";
            this.Text = "frmVerGananciasVendedor";
            this.Load += new System.EventHandler(this.frmVerGananciasVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciasMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGananciasMeses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGananciasMeses;
        private Bunifu.UI.WinForms.BunifuDataGridView dataGridGananciasMeses;
        private Bunifu.UI.WinForms.BunifuDropdown dropdownMeses;
        private Bunifu.UI.WinForms.BunifuDropdown dropdownAños;
    }
}