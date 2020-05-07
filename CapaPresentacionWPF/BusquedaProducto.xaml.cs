using Capa_entidades;
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
using System.Windows.Shapes;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para BusquedaProducto.xaml
    /// </summary>
    public partial class BusquedaProducto : Window
    {
        public BusquedaProducto()
        {
            InitializeComponent();
        }

        private void Selrccionar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Salir?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                MessageBox.Show("Salir");
            }
            else
            {
                MessageBox.Show("Continuar");
            }
        }
    }
}
