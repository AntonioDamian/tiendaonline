using Capa_entidades;
using Capa_negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para BuscadorArticulo.xaml
    /// </summary>
    public partial class BuscadorArticulo : Window
    {
        Dictionary<int, string> especi;        
        NegociotipoArticulo _negTipo;
        NegocioProducto _negocioProducto;

        private ObservableCollection<TipoArticulo> ListaProductos;
        private ObservableCollection<Articulo> ListaArticulos;

        public BuscadorArticulo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _negocioProducto = new NegocioProducto();

            ListaArticulos = new ObservableCollection<Articulo>(_negocioProducto.ObtenerArticulos());

            _negTipo = new NegociotipoArticulo();

            ListaProductos = _negTipo.ListadoTipos();

            especi = new Dictionary<int, string>();
            especi.Add(0, "Null");

            foreach (TipoArticulo tp in ListaProductos)
            {
                especi.Add(tp.TipoArticuloID, tp.Descripcion);
            }

            ComboTipo.ItemsSource = especi;
            ComboTipo.SelectedIndex = 0;

        }

        private void ComboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _negocioProducto = new NegocioProducto();          
            int v2 =Convert.ToInt32(ComboTipo.SelectedValue.ToString());         

            if (v2==0)
            {
                listArticulos.ItemsSource = ListaArticulos.Where(x => x.TipoArticuloID is null);

                 
             }
            else
            {
                listArticulos.ItemsSource = ListaArticulos.Where(x => x.TipoArticuloID.Equals(v2));
            }
          
          



        }

    }
}
