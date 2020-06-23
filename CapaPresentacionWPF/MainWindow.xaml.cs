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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using CapaPresentacionWPF;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"> Usuario con sus datos que recibimos despues de loguearnos</param>
        public MainWindow(Usuario usuario)
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));

            // Enlazo el StackPanel dónde muestro los datos del usuario logueado al objeto 'usuario'
            datosUsuarioAPP.DataContext = usuario;
            datosUsuarioAPP1.DataContext = usuario;

            // Control del momento de inicio de la aplicación. Se usa para mostrar el tiempo que lleva en marcha
            dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background,
                DispatcherTimer_Tick, Dispatcher.CurrentDispatcher); dispatcherTimer.IsEnabled = true;
            start = DateTime.Now;

            // Cargo un UserControl por defecto
            GridContenido.Children.Clear();

            UscPrincipal uSPrincipal = new UscPrincipal();
            GridContenido.Children.Add(uSPrincipal);
        }

        /// <summary>
        /// Función para controlar el tiempo que lleva la aplicación en ejecución
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void DispatcherTimer_Tick(object Sender, EventArgs e)
        {
            Hora.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
            TiempoEjecucion.DataContext = DateTime.Now - start;
        }

        /// <summary>
        /// Metodo para controlar las distintas opciones del menu ,segun el control pulsado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Instancio un UserControl en función de la opción de menú pulsada
            ListViewItem listViewItem = ((ListViewItem)sender);
            switch (listViewItem.Name)
            {
                     case "listHome":
                          GridContenido.Children.Clear();
                          UscPrincipal uSPrincipal = new UscPrincipal();
                          GridContenido.Children.Add(uSPrincipal);
                          break;
                     case "listAñadirUsuario":
                          GridContenido.Children.Clear();
                          UScMantenimientoUsuarios uScMantenimientoUsuarios = new UScMantenimientoUsuarios();                        
                          GridContenido.Children.Add(uScMantenimientoUsuarios);
                          break;                
                      case "listConsultarProducto":
                          GridContenido.Children.Clear();
                          UscConsultaProductos uCproducto = new UscConsultaProductos();
                          GridContenido.Children.Add(uCproducto);
                          break;                  
                      case "listNuevoPedido":
                          GridContenido.Children.Clear();
                          UscVentas uCventas = new UscVentas();
                          GridContenido.Children.Add(uCventas);
                          break;
                      case "listEstadisticas":
                          GridContenido.Children.Clear();
                          UscEstadisticas uCEstadisticas = new UscEstadisticas();
                          GridContenido.Children.Add(uCEstadisticas);
                          break;
                      case "listInformeFactura":
                          GridContenido.Children.Clear();
                          UscInformes uCFacturas = new UscInformes();
                          GridContenido.Children.Add(uCFacturas);
                          break;                    
                      case "listAcercaDe":
                          GridContenido.Children.Clear();
                          UscAcercaDe uCAcercaDe = new UscAcercaDe();
                          GridContenido.Children.Add(uCAcercaDe);
                    break;
                case "listSalir":

                    MessageBoxResult result = MessageBox.Show("¿Desea cerrar la aplicación?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                        Application.Current.Shutdown();

                    break;
                default:
                    break;
            }
        }

        private void btnPopupSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea cerrar la aplicación?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
