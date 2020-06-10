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
    }
}
