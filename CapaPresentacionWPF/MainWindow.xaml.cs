using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Capa_entidades;


namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Variables para controlar la hora mostrada y el tiempo transcurrido
        DispatcherTimer dispatcherTimer;
        DateTime start;
        Usuario usuario = new Usuario();
      

        public MainWindow( Usuario usuario)
        {
            InitializeComponent();
           
            this.usuario = usuario;
            

            Style = (Style)FindResource(typeof(Window));

            datosUsuarioAPP.DataContext = usuario;
            datosUsuarioAPP1.DataContext = usuario;


            // Control del momento de inicio de la aplicación. Se usa para mostrar el tiempo que lleva en marcha
            dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background,
                DispatcherTimer_Tick, Dispatcher.CurrentDispatcher); dispatcherTimer.IsEnabled = true;
            start = DateTime.Now;
            // Cargo un UserControl por defecto
            GridBackground.Children.Clear();
            UserPrincipal uSPrincipal = new UserPrincipal();
            GridBackground.Children.Add(uSPrincipal);
        }

        /// <summary>
        /// Función para controlar el tiempo que lleva la aplicación en ejecución
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void DispatcherTimer_Tick(object Sender, EventArgs e)
        {
            HoraLocal.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
            TiempoEjecucionAplicacion.DataContext = DateTime.Now - start;
        }

        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc;
            GridBackground.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Home":
                    UserPrincipal uscr = new  UserPrincipal();
                    GridBackground.Children.Add(uscr);
                    break;
                case "MantenimientoUsuarios":
                    usc = new UScMantenimientoUsuarios();
                    GridBackground.Children.Add(usc);
                    break;
                case "ConsultaProductos":
                    usc = new UscConsultaProductos();
                    GridBackground.Children.Add(usc);   
                    break;
                case "Ventas":

                    usc = new UscInformes();
                    GridBackground.Children.Add(usc);
                    /*  usc = new UscEstadisticas();
                      GridBackground.Children.Add(usc);
                        usc = new UscVentas();
                         GridBackground.Children.Add(usc);*/
                    break;



               
                default:
                    break;
            }
        }
    }
}
