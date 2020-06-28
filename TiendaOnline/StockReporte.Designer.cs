namespace TiendaOnline
{
    partial class StockReporte
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DetalleStock";
            reportDataSource1.Value = this.StockBindingSource;
            reportDataSource2.Name = "DetalleStock2";
            reportDataSource2.Value = this.ArticuloBindingSource;
            reportDataSource3.Name = "DetalleStock3";
            reportDataSource3.Value = this.ArticuloBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TiendaOnline.InformeStock.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // StockBindingSource
            // 
            this.StockBindingSource.DataSource = typeof(CapaEntidades.Stock);
            // 
            // ArticuloBindingSource
            // 
            this.ArticuloBindingSource.DataSource = typeof(CapaEntidades.Articulo);
            // 
            // StockReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "StockReporte";
            this.Text = "StockReporte";
            this.Load += new System.EventHandler(this.StockReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StockBindingSource;
        private System.Windows.Forms.BindingSource ArticuloBindingSource;
    }
}