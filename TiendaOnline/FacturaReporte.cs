 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using Microsoft.Reporting.WinForms;

namespace TiendaOnline
{
    public partial class FacturaReporte : Form
    {
        public List<Pedido> listaPedido = new List<Pedido>();
        public List<Linped> listaLinpeds = new List<Linped>();

        public string NombreRemitenteFactura { get; set; }
        public string DireccionRemitenteFactura { get; set; }
        public string LocalidadRemitenteFactura { get; set; }
        public string DniRemitenteFactura { get; set; }

        public FacturaReporte()
        {
            InitializeComponent();
        }

        private void FacturaReport_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter[] parametrosFactura = new ReportParameter[4];
            parametrosFactura[0] = new ReportParameter("NombreRemitenteFactura", NombreRemitenteFactura);
            parametrosFactura[1] = new ReportParameter("DireccionRemitenteFactura", DireccionRemitenteFactura);
            parametrosFactura[2] = new ReportParameter("LocalidadRemitenteFactura", LocalidadRemitenteFactura);
            parametrosFactura[3] = new ReportParameter("DniRemitenteFactura", DniRemitenteFactura);

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("EncabezadoFactura",listaPedido));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleFactura", listaLinpeds));

            reportViewer1.LocalReport.SetParameters(parametrosFactura);

            reportViewer1.RefreshReport();

        }
    }
}
