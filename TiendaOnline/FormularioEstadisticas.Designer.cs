namespace TiendaOnline
{
    partial class FormularioEstadisticas
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPedidosDia = new System.Windows.Forms.DataGridView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.numericAnyo = new System.Windows.Forms.NumericUpDown();
            this.comboMeses = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnyo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.918736F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.73545F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.27784F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.14811F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPedidosDia, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.monthCalendar1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericAnyo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboMeses, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.77429F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.518664F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.31373F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.431373F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 510);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvPedidosDia
            // 
            this.dgvPedidosDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosDia.Location = new System.Drawing.Point(224, 91);
            this.dgvPedidosDia.Name = "dgvPedidosDia";
            this.dgvPedidosDia.Size = new System.Drawing.Size(310, 372);
            this.dgvPedidosDia.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(27, 97);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // numericAnyo
            // 
            this.numericAnyo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericAnyo.Location = new System.Drawing.Point(21, 22);
            this.numericAnyo.Name = "numericAnyo";
            this.numericAnyo.Size = new System.Drawing.Size(197, 20);
            this.numericAnyo.TabIndex = 3;
            this.numericAnyo.ValueChanged += new System.EventHandler(this.numericAnyo_ValueChanged);
            // 
            // comboMeses
            // 
            this.comboMeses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboMeses.FormattingEnabled = true;
            this.comboMeses.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.comboMeses.Location = new System.Drawing.Point(224, 22);
            this.comboMeses.Name = "comboMeses";
            this.comboMeses.Size = new System.Drawing.Size(310, 21);
            this.comboMeses.TabIndex = 4;
            this.comboMeses.Text = "Enero";
            this.comboMeses.SelectedIndexChanged += new System.EventHandler(this.comboMeses_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(540, 91);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Articulo";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(436, 372);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // FormularioEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1001, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioEstadisticas";
            this.Text = "FormularioEstadisticas";
            this.Load += new System.EventHandler(this.FormularioEstadisticas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnyo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPedidosDia;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NumericUpDown numericAnyo;
        private System.Windows.Forms.ComboBox comboMeses;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
