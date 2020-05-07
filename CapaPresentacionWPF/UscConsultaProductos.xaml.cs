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

        public UscConsultaProductos()
        {
            InitializeComponent();

         
        }


           
    



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _negociotipoArticulo = new NegociotipoArticulo();

            ListaProductos = _negociotipoArticulo.ListadoTipos();

            this.TipoaArt.ItemsSource = ListaProductos;
        }



        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Salir?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                
              
            }
           
             
        }

      


        }

      

    }

