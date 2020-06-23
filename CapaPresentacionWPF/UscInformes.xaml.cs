using Capa_entidades;
using Capa_negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaPresentacionWPF;
using System.Windows.Xps; // refenecia ReachFramework
using System.Windows.Xps.Packaging;
using System.IO;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UscInformes.xaml
    /// </summary>
    public partial class UscInformes : UserControl,IBuscar
    {

        Negocio _usuario;
        NegocioPedido _negPedido;

        decimal total;
        decimal totalConIva;
        decimal totalIva;


        public UscInformes()
        {
            InitializeComponent();
            _usuario = new Negocio();
            _negPedido = new NegocioPedido();

        }

      

        private void BuscarFactura_Click(object sender, RoutedEventArgs e)
        {
            listaVentas.Items.Clear();
            
            BusquedaPedido busPedido = new BusquedaPedido();
            busPedido.Buscar = (IBuscar)this;
            busPedido.ShowDialog();
        }

        public void Ejecutar(Articulo articulo)
        {
            throw new NotImplementedException();
        }

        public void DevolucionPedido(Pedido pedido, string nombre)
        {
            foreach(Linped li in pedido.Linpeds)
                {
                    _ = listaVentas.Items.Add(new
                    {
                        Linea = li.Linea,
                        ArticuloID = li.ArticuloID,
                        Importe = li.Importe,
                        Cantidad = li.Cantidad,
                        ImporteTotal = li.Importe * li.Cantidad
                    });
                }

          

            UsuarioID.DataContext = pedido.UsuarioID;
            NombreCliente.DataContext = nombre;
            FechaPedido.DataContext = pedido.Fecha;
            NumPedidoCliente.DataContext = pedido.PedidoID;

            ResumenFactura(pedido, 21);

        }

        private void ResumenFactura(Pedido pedido, decimal iva)
        {
            decimal[] resumenFactura = new decimal[4];

            resumenFactura = _negPedido.Datosfactura(pedido, iva);

            total = resumenFactura[0];
            totalIva = resumenFactura[1];
            totalConIva = resumenFactura[2];

            Subtotal.DataContext = total.ToString() + " €";
            IVA.DataContext= totalIva.ToString() + " €";
            Total.DataContext= totalConIva.ToString() + " €";
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            FlowDocumentScrollViewer visual = (FlowDocumentScrollViewer)(this.FindName("FlowDocViewer"));
            try
            {
                // write the XPS document
                using (XpsDocument doc = new XpsDocument("printPreview.xps", FileAccess.ReadWrite))
                {
                    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                    writer.Write(visual);
                }

                // Read the XPS document into a dynamically generated
                // preview Window 
                Window preview = new PrintWindow();
                using (XpsDocument doc = new XpsDocument("printPreview.xps", FileAccess.Read))
                {
                    FixedDocumentSequence fds = doc.GetFixedDocumentSequence();

                    DocumentViewer dv1 = LogicalTreeHelper.FindLogicalNode(preview, "PreviewD") as DocumentViewer;
                    dv1.Document = fds as IDocumentPaginatorSource;

                    // Eliminamos la ventana de búsqueda
                    ContentControl cc = dv1.Template.FindName("PART_FindToolBarHost", dv1) as ContentControl;
                    cc.Visibility = Visibility.Collapsed;
                }
                preview.ShowDialog();
            }
            finally
            {
                if (File.Exists("printPreview.xps"))
                {
                    try
                    {
                        File.Delete("printPreview.xps");
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void DevolucionLocalidad(Localidad localidad)
        {
            throw new NotImplementedException();
        }
    }
}
