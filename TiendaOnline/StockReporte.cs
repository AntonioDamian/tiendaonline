using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_entidades;
using Microsoft.Reporting.WinForms;

namespace TiendaOnline
{
    public partial class StockReporte : Form
    {

       public List<Stock> listaStock = new List<Stock>();
      
       public  List<Articulo> articulos = new List<Articulo>();


        public StockReporte()
        {
            InitializeComponent();
        }

        private void StockReporte_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleStock", listaStock));        
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleStock2", articulos));


            this.reportViewer1.RefreshReport();
        }
    }
}
