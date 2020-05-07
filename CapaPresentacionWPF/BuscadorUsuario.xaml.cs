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
      
       
        private bool IsEliminar = false;

        private int _errors = 0;
        List<int> listaIdUsuarios;

        DataTable dt = new DataTable();

        UscVentas usventa;


        public BuscadorUsuario(UscVentas usc)
        {
           
            InitializeComponent();
            neg = new Negocio();
          

            Mostrar();
          

            listaIdUsuarios = new List<int>();
         
            usventa = usc;
        }

     



      



        private void Mostrar()
        {


            _listaUsuarios = new List<Usuario>();
            _listaUsuarios = neg.ObtenerUsuarios();



            dgUsers.ItemsSource = _listaUsuarios;
            lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);
        }



      

        private void RbNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNombre.IsChecked == true)
            {
                this.txtBusqueda.IsEnabled = true;

            }

        }

        private void RbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDni.IsChecked == true)
            {
                this.txtBusqueda.IsEnabled = true;

            }

        }

        private void Rbemail_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmail.IsChecked == true)
            {
                this.txtBusqueda.IsEnabled = true;

            }

        }

        private void TxtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtBusqueda.Text.Trim()) == false)
            {


                if (rbNombre.IsChecked == true)
                {

                    lbApellido.Visibility = Visibility.Visible;
                    txtApellido.IsEnabled = false;
                    txtApellido.Visibility = Visibility.Visible;

                    var query = from l in _listaUsuarios where l.Nombre.StartsWith(txtBusqueda.Text, comparison) select l;

                    dgUsers.ItemsSource = query.ToList();

                    lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);


                      dt = Utilidades.ConvertToDataTable(query.ToList());
                      dt.DefaultView.Sort = "UsuarioID";


                }
                if (rbDni.IsChecked == true)
                {

                    var query = from l in _listaUsuarios where l.Dni.StartsWith(txtBusqueda.Text, comparison) select l;

                    dgUsers.ItemsSource = query.ToList();

                    lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);
                }

                if (rbEmail.IsChecked == true)
                {

                    var query = from l in _listaUsuarios where l.Email.StartsWith(txtBusqueda.Text, comparison) select l;

                    dgUsers.ItemsSource = query.ToList();
                    lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);
                }
                else
                {
                    dgUsers.ItemsSource = _listaUsuarios;
                    txtBusqueda.Text = "";

                }


            }
            else
            {

                txtBusqueda.IsEnabled = false;
                lbApellido.Visibility = Visibility.Collapsed;
                txtApellido.IsEnabled = false;
                txtApellido.Visibility = Visibility.Collapsed;
            }
        }


        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"apellidos like'{txtApellido.Text.Trim()}%'";
        }     

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
          /*  MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1;*/
        }

        private void DgUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
           

            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {

                DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                Usuario us = (Usuario)dgr.Item;

               

                usventa.ClienteCompra(us);

              /*  usventa.TxTUsuarioID.Text = us.UsuarioID.ToString(cultures);
                usventa.TxTNombreCliente.Text = us.Nombre.ToString(cultures);*/

                this.Close();
             

            }
           
        }
    }
}
