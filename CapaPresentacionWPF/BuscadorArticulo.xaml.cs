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
    /// Lógica de interacción para buscadorArticulo.xaml
    /// </summary>
    public partial class BuscadorArticulo : Window
    {
        Dictionary<int, string> especi;
        NegociotipoArticulo _negTipo;
        NegocioProducto _negocioProducto;



        public IBuscar Buscar { get; set; }

        private List<TipoArticulo> ListaProductos;
        private ObservableCollection<Articulo> ListaArticulos;
        private ObservableCollection<TipoArticulo> ListaTipoArticulos;

        public BuscadorArticulo()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _negocioProducto = new NegocioProducto();

            //  ListaArticulos = new ObservableCollection<Articulo>(_negocioProducto.ObtenerArticulos());

            _negTipo = new NegociotipoArticulo();

            ListaProductos = _negTipo.ObtenertiposArticulos();
            ListaTipoArticulos = new ObservableCollection<TipoArticulo>(_negTipo.ListadoTipos());


            especi = new Dictionary<int, string>();
            // especi.Add(0, "Null");

            foreach (TipoArticulo tp in ListaTipoArticulos)
            {
                especi.Add(tp.TipoArticuloID, tp.Descripcion);
            }
            especi[0] = "Null";


            ComboTipo.ItemsSource = ListaTipoArticulos;
            // ComboTipo.Text = "Null";
            ComboTipo.SelectedIndex = 0;

        }

        /*  private void ComboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              _negocioProducto = new NegocioProducto();          
              int v2 =Convert.ToInt32(ComboTipo.SelectedValue.ToString());

            //  ListaArticulos= new ObservableCollection<Articulo>(_negocioProducto.ListaArticulos(v2));

              /*  if (v2==0)
                {
                    listArticulos.ItemsSource = ListaArticulos.Where(x => x.TipoArticuloID is null);


                 }
                else
                {
                   // listArticulos.ItemsSource = ListaArticulos.Where(x => x.TipoArticuloID.Equals(v2));
                    listArticulos.ItemsSource = new ObservableCollection<Articulo>(_negocioProducto.ListaArticulos(v2));
                }*/



        //  listArticulos.ItemsSource = ListaArticulos;



        // }

        Articulo articulo;

        private void ListArticulos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            articulo = new Articulo();

            articulo = (Articulo)listArticulos.SelectedItem
                 as Articulo;



            Buscar.Ejecutar(articulo);



        }
    }
}
