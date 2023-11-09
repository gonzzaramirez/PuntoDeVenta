namespace CapaPresentacion
{
    partial class frmVerVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerVentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.laberlVenta5 = new Bunifu.UI.WinForms.BunifuLabel();
            this.laberlVenta3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.laberlVenta4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dgvDetalleVenta = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.dgvDataVenta = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.laberlVenta = new Bunifu.UI.WinForms.BunifuLabel();
            this.laberlVenta2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // laberlVenta5
            // 
            this.laberlVenta5.AllowParentOverrides = false;
            this.laberlVenta5.AutoEllipsis = false;
            this.laberlVenta5.Cursor = System.Windows.Forms.Cursors.Default;
            this.laberlVenta5.CursorType = System.Windows.Forms.Cursors.Default;
            this.laberlVenta5.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laberlVenta5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.laberlVenta5.Location = new System.Drawing.Point(10, 13);
            this.laberlVenta5.Name = "laberlVenta5";
            this.laberlVenta5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.laberlVenta5.Size = new System.Drawing.Size(125, 39);
            this.laberlVenta5.TabIndex = 63;
            this.laberlVenta5.Text = "Reporte";
            this.laberlVenta5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.laberlVenta5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // laberlVenta3
            // 
            this.laberlVenta3.AllowParentOverrides = false;
            this.laberlVenta3.AutoEllipsis = false;
            this.laberlVenta3.Cursor = System.Windows.Forms.Cursors.Default;
            this.laberlVenta3.CursorType = System.Windows.Forms.Cursors.Default;
            this.laberlVenta3.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laberlVenta3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.laberlVenta3.Location = new System.Drawing.Point(677, 13);
            this.laberlVenta3.Name = "laberlVenta3";
            this.laberlVenta3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.laberlVenta3.Size = new System.Drawing.Size(204, 39);
            this.laberlVenta3.TabIndex = 61;
            this.laberlVenta3.Text = "Detalle de la";
            this.laberlVenta3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.laberlVenta3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // laberlVenta4
            // 
            this.laberlVenta4.AllowParentOverrides = false;
            this.laberlVenta4.AutoEllipsis = false;
            this.laberlVenta4.Cursor = System.Windows.Forms.Cursors.Default;
            this.laberlVenta4.CursorType = System.Windows.Forms.Cursors.Default;
            this.laberlVenta4.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laberlVenta4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.laberlVenta4.Location = new System.Drawing.Point(887, 13);
            this.laberlVenta4.Name = "laberlVenta4";
            this.laberlVenta4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.laberlVenta4.Size = new System.Drawing.Size(96, 39);
            this.laberlVenta4.TabIndex = 62;
            this.laberlVenta4.Text = "Venta";
            this.laberlVenta4.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.laberlVenta4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowCustomTheming = false;
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvDetalleVenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVenta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalleVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalleVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleVenta.ColumnHeadersHeight = 40;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.NombreProducto,
            this.PrecioVenta,
            this.Cantidad,
            this.Subtotal});
            this.dgvDetalleVenta.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvDetalleVenta.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDetalleVenta.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDetalleVenta.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvDetalleVenta.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.CurrentTheme.BackColor = System.Drawing.Color.Maroon;
            this.dgvDetalleVenta.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.dgvDetalleVenta.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvDetalleVenta.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvDetalleVenta.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvDetalleVenta.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.CurrentTheme.Name = null;
            this.dgvDetalleVenta.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dgvDetalleVenta.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDetalleVenta.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDetalleVenta.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvDetalleVenta.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleVenta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalleVenta.EnableHeadersVisualStyles = false;
            this.dgvDetalleVenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.dgvDetalleVenta.HeaderBackColor = System.Drawing.Color.Maroon;
            this.dgvDetalleVenta.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvDetalleVenta.HeaderForeColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(616, 67);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalleVenta.RowHeadersVisible = false;
            this.dgvDetalleVenta.RowTemplate.Height = 40;
            this.dgvDetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(466, 445);
            this.dgvDetalleVenta.TabIndex = 60;
            this.dgvDetalleVenta.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Maroon;
            this.dgvDetalleVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellContentClick);
            // 
            // dgvDataVenta
            // 
            this.dgvDataVenta.AllowCustomTheming = false;
            this.dgvDataVenta.AllowUserToAddRows = false;
            this.dgvDataVenta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgvDataVenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDataVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataVenta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDataVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDataVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDataVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDataVenta.ColumnHeadersHeight = 40;
            this.dgvDataVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVenta,
            this.Vendedor,
            this.MontoPago,
            this.MontoCambio,
            this.MontoTotal,
            this.FechaRegistro});
            this.dgvDataVenta.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.dgvDataVenta.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDataVenta.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDataVenta.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvDataVenta.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDataVenta.CurrentTheme.BackColor = System.Drawing.Color.Maroon;
            this.dgvDataVenta.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.dgvDataVenta.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvDataVenta.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvDataVenta.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDataVenta.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvDataVenta.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDataVenta.CurrentTheme.Name = null;
            this.dgvDataVenta.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dgvDataVenta.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDataVenta.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDataVenta.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvDataVenta.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataVenta.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDataVenta.EnableHeadersVisualStyles = false;
            this.dgvDataVenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.dgvDataVenta.HeaderBackColor = System.Drawing.Color.Maroon;
            this.dgvDataVenta.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvDataVenta.HeaderForeColor = System.Drawing.Color.White;
            this.dgvDataVenta.Location = new System.Drawing.Point(11, 67);
            this.dgvDataVenta.Name = "dgvDataVenta";
            this.dgvDataVenta.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDataVenta.RowHeadersVisible = false;
            this.dgvDataVenta.RowTemplate.Height = 40;
            this.dgvDataVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataVenta.Size = new System.Drawing.Size(599, 445);
            this.dgvDataVenta.TabIndex = 59;
            this.dgvDataVenta.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Maroon;
            this.dgvDataVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataVenta_CellContentClick);
            // 
            // laberlVenta
            // 
            this.laberlVenta.AllowParentOverrides = false;
            this.laberlVenta.AutoEllipsis = false;
            this.laberlVenta.Cursor = System.Windows.Forms.Cursors.Default;
            this.laberlVenta.CursorType = System.Windows.Forms.Cursors.Default;
            this.laberlVenta.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laberlVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.laberlVenta.Location = new System.Drawing.Point(224, 13);
            this.laberlVenta.Name = "laberlVenta";
            this.laberlVenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.laberlVenta.Size = new System.Drawing.Size(96, 39);
            this.laberlVenta.TabIndex = 57;
            this.laberlVenta.Text = "Venta";
            this.laberlVenta.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.laberlVenta.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // laberlVenta2
            // 
            this.laberlVenta2.AllowParentOverrides = false;
            this.laberlVenta2.AutoEllipsis = false;
            this.laberlVenta2.Cursor = System.Windows.Forms.Cursors.Default;
            this.laberlVenta2.CursorType = System.Windows.Forms.Cursors.Default;
            this.laberlVenta2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laberlVenta2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.laberlVenta2.Location = new System.Drawing.Point(326, 13);
            this.laberlVenta2.Name = "laberlVenta2";
            this.laberlVenta2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.laberlVenta2.Size = new System.Drawing.Size(166, 39);
            this.laberlVenta2.TabIndex = 58;
            this.laberlVenta2.Text = "realizadas";
            this.laberlVenta2.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.laberlVenta2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // IdVenta
            // 
            this.IdVenta.DataPropertyName = "IdVenta";
            this.IdVenta.FillWeight = 24.02624F;
            this.IdVenta.HeaderText = "IdVenta";
            this.IdVenta.Name = "IdVenta";
            this.IdVenta.ReadOnly = true;
            // 
            // Vendedor
            // 
            this.Vendedor.DataPropertyName = "Vendedor";
            this.Vendedor.FillWeight = 30F;
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            // 
            // MontoPago
            // 
            this.MontoPago.DataPropertyName = "MontoPago";
            this.MontoPago.FillWeight = 36.27516F;
            this.MontoPago.HeaderText = "MontoPago";
            this.MontoPago.Name = "MontoPago";
            this.MontoPago.ReadOnly = true;
            // 
            // MontoCambio
            // 
            this.MontoCambio.DataPropertyName = "MontoCambio";
            this.MontoCambio.FillWeight = 39.92798F;
            this.MontoCambio.HeaderText = "MontoCambio";
            this.MontoCambio.Name = "MontoCambio";
            this.MontoCambio.ReadOnly = true;
            // 
            // MontoTotal
            // 
            this.MontoTotal.FillWeight = 23.86558F;
            this.MontoTotal.HeaderText = "MontoTotal";
            this.MontoTotal.Name = "MontoTotal";
            this.MontoTotal.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            this.FechaRegistro.FillWeight = 36.27516F;
            this.FechaRegistro.HeaderText = "FechaRegistro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "Subtotal";
            this.Subtotal.FillWeight = 46.56324F;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.FillWeight = 62.08146F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.DataPropertyName = "PrecioVenta";
            this.PrecioVenta.FillWeight = 51.49196F;
            this.PrecioVenta.HeaderText = "PrecioVenta";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            // 
            // NombreProducto
            // 
            this.NombreProducto.DataPropertyName = "NombreProducto";
            this.NombreProducto.FillWeight = 60F;
            this.NombreProducto.HeaderText = "NombreProducto";
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            // 
            // IdProducto
            // 
            this.IdProducto.DataPropertyName = "IdProducto";
            this.IdProducto.FillWeight = 35.31608F;
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            // 
            // frmVerVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 528);
            this.Controls.Add(this.laberlVenta5);
            this.Controls.Add(this.laberlVenta3);
            this.Controls.Add(this.laberlVenta4);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.dgvDataVenta);
            this.Controls.Add(this.laberlVenta);
            this.Controls.Add(this.laberlVenta2);
            this.Name = "frmVerVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVerVentas";
            this.Load += new System.EventHandler(this.frmVerVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel laberlVenta5;
        private Bunifu.UI.WinForms.BunifuLabel laberlVenta3;
        private Bunifu.UI.WinForms.BunifuLabel laberlVenta4;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvDetalleVenta;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvDataVenta;
        private Bunifu.UI.WinForms.BunifuLabel laberlVenta;
        private Bunifu.UI.WinForms.BunifuLabel laberlVenta2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
    }
}