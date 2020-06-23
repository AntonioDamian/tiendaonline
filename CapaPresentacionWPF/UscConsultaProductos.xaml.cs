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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UscConsultaProductos.xaml
    /// </summary>
    public partial class UscConsultaProductos : UserControl
    {
        private ObservableCollection<TipoArticulo> ListaProductos;
        NegociotipoArticulo _negociotipoArticulo;


        public delegate void GridSelectorCommandEventHandler(GridSelectorCommandEventArgs e);
        public event GridSelectorCommandEventHandler GridSelectorChanged;

        public class GridSelectorCommandEventArgs
        {
            public Articulo arti { get; protected set; }
          

            public GridSelectorCommandEventArgs(Articulo articulo)
            {
                this.arti = articulo;
               
            }
        }

        public UscConsultaProductos()
        {
          
            InitializeComponent();        
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //this.lblEjemplo.Content = "Iniciando la aplicación...";
            this.loading.Visibility = Visibility.Visible;
            Loading2.Content= "Loading...";

            await ArranqueAplicacionAsync();
            Loading2.Content = "Carga finalizada";
            progressbar.Visibility = Visibility.Collapsed;
           // this.loading.Visibility = Visibility.Collapsed;

            this.TipoaArt.ItemsSource = ListaProductos;
           
        }




        public void ArranqueApp()
        {
            _negociotipoArticulo = new NegociotipoArticulo();
            ListaProductos = _negociotipoArticulo.ListadoTipos();

            ListaProductos.Add(new TipoArticulo(0, null));

           //this.TipoaArt.ItemsSource = ListaProductos;


        }

        public async Task ArranqueAplicacionAsync()
        {
            await Task.Run(() => ArranqueApp());
        }

       
        Articulo articulo;



        private void listArticulos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            articulo = new Articulo();

            articulo = (Articulo)listArticulos.SelectedItem
                 as Articulo;

            if (GridSelectorChanged != null)
                GridSelectorChanged(new GridSelectorCommandEventArgs(articulo));

           
            
        }
    }
    }

