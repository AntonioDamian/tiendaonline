using Capa_entidades;
using Capa_negocio;
using MiLibreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Lógica de interacción para BuscadorUsuario.xaml
    /// </summary>
    public partial class BuscadorUsuario : Window
    {
        CultureInfo cultures = new CultureInfo("es-ES");
        private StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

        Negocio neg;
        List<Usuario> _listaUsuarios;
        
        List<int> listaIdUsuarios;

        DataTable dt = new DataTable();

        UscVentas uscventa;
        private int indice;

        public BuscadorUsuario()
        {
            InitializeComponent();
        }

        public BuscadorUsuario(UscVentas usc)
        {
            InitializeComponent();

            neg = new Negocio();

            listaIdUsuarios = new List<int>();

            uscventa = usc;

            Mostrar();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgUsers.ItemsSource);
          //  view.Filter= UserFilter;
        }

      

        private void Mostrar()
        {
            _listaUsuarios = new List<Usuario>();
            _listaUsuarios = neg.ObtenerUsuarios();

            dgUsers.ItemsSource = _listaUsuarios;
            lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);
        }


        private void RbNombre_Checked(object sender, RoutedEventArgs e)
        {
            if (rbNombre.IsChecked == true)
            {
                indice = 1;
                
                txtBusqueda.Text = "";
                Mostrar();
                

            }
        }

        private void RbDni_Checked(object sender, RoutedEventArgs e)
        {
            if (rbDni.IsChecked == true)
            {
                indice = 2;
                txtBusqueda.Text = "";
                lbApellido.Visibility = Visibility.Collapsed;
                txtApellido.IsEnabled = false;
                txtApellido.Visibility = Visibility.Collapsed;
                Mostrar();

            }
        }

        private void RbEmail_Checked(object sender, RoutedEventArgs e)
        {
            if (rbEmail.IsChecked == true)
            {
                indice = 3;
                txtBusqueda.Text = "";
                lbApellido.Visibility = Visibility.Collapsed;
                txtApellido.IsEnabled = false;
                txtApellido.Visibility = Visibility.Collapsed;
                Mostrar();
            }
        }



        private void TxtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
          

            if (string.IsNullOrEmpty(txtBusqueda.Text.Trim()) == false)
            {


                if (indice == 1)
                {

                    lbApellido.Visibility = Visibility.Visible;
                    txtApellido.IsEnabled = true;
                    txtApellido.Visibility = Visibility.Visible;

                    var query = from l in _listaUsuarios where l.Nombre.ToUpper().StartsWith(txtBusqueda.Text.ToUpper(), comparison) select l;
                  

                  dgUsers.ItemsSource = query;                


                     dt = Utilidades.ConvertToDataTable(query.ToList());
                      dt.DefaultView.Sort = "UsuarioID";


                    CollectionViewSource.GetDefaultView(dgUsers.ItemsSource).Refresh();
                    lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);
                }
                if (indice ==2)
                {

                    var query = from l in _listaUsuarios where l.Dni.StartsWith(txtBusqueda.Text, comparison) select l;

                    dgUsers.ItemsSource = query.ToList();

                    lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);
                }

                if(indice==3)
                {

                    var query = from l in _listaUsuarios where l.Email.StartsWith(txtBusqueda.Text, comparison) select l;

                    dgUsers.ItemsSource = query.ToList();
                    lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);
                }
              


            }
            else
            {

             
                lbApellido.Visibility = Visibility.Collapsed;
                txtApellido.IsEnabled = false;
                txtApellido.Visibility = Visibility.Collapsed;
                dgUsers.ItemsSource = _listaUsuarios;
                txtBusqueda.Text = "";

            }
        }


      
        private void TxtApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            dt.DefaultView.RowFilter = $"apellidos like'{txtApellido.Text.ToUpper().Trim()}%'";

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }

        private void DgUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;


            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {

                DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                Usuario us = (Usuario)dgr.Item;

                uscventa.ClienteCompra(us);
               
                this.Close();


            }
        }

     

        private void DgUsers_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {

            

            
            if (dgUsers.SelectedItems.Count > 0)
            {
                var us = dgUsers.SelectedItems ;

                
                uscventa.ClienteCompra2(us);

                this.Close();
            }
        }
    }
}
