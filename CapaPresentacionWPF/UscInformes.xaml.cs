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
using Capa_entidades;
using Capa_negocio;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UscInformes.xaml
    /// </summary>
    public partial class UscInformes : UserControl
    {

        Negocio _usuario;
        NegocioPedido _negPedido;
        List<Pedido> _listaPedidos = new List<Pedido>();

        public UscInformes()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _usuario = new Negocio();
            _negPedido = new NegocioPedido();
        }

        private void BuscarFactura_Click(object sender, RoutedEventArgs e)
        {
            BusquedaPedido busPedido = new BusquedaPedido();
            busPedido.Show();
        }
    }
}
