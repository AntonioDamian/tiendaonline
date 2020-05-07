using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_entidades;
using Capa_negocio;
using MiLibreria;


namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UscUsuarioMantenimiento.xaml
    /// </summary>
    public partial class UscUsuarioMantenimiento : UserControl
    {
        CultureInfo cultures = new CultureInfo("es-ES");
        private StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

        Negocio _neg;       
        List<Usuario> _listaUsuarios;
        Usuario usu;

        string _nombreAplicacion = "Apitienda";

        private bool IsNuevo = false;

        private bool IsEditar = false;

        ObservableCollection<Usuario> filtradoUsuarios;

        private int _errors = 0;

        public UscUsuarioMantenimiento()
        {
            InitializeComponent();
            _neg = new Negocio();
            usu = new Usuario();
            Habilitar(false);
            Mostrar();
            Botones();

        }
		
		  private void Habilitar(bool valor)
        {
           
            this.txtApellidos.IsReadOnly = !valor;
            this.txtEmail.IsReadOnly = !valor;
            this.txtNombre.IsReadOnly = !valor;

            txtPass.IsReadOnly = !valor;
            txtRepePass.IsReadOnly = !valor;
            txtDni.IsReadOnly = !valor;
            txtTelefono.IsReadOnly = !valor;
            txtCalle.IsReadOnly = !valor;
            txtCalle2.IsReadOnly = !valor;
            txtCodigoPostal.IsReadOnly = !valor;
            ListPueblo.IsReadOnly = !valor;
            ListPueblo.IsReadOnly = !valor;
           
           

        }
		
		 private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.IsEnabled = false;
                this.btnGuardar.IsEnabled = true;
                this.btnEditar.IsEnabled = false;
                this.btnCancelar.IsEnabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.IsEnabled = true;
                this.btnGuardar.IsEnabled = false;
                this.btnEditar.IsEnabled = true;
                this.btnCancelar.IsEnabled = false;
            }
        }

        private void Mostrar()
        {
            _listaUsuarios = new List<Usuario>();
            _listaUsuarios = _neg.ObtenerUsuarios();

            filtradoUsuarios = new ObservableCollection<Usuario>(_neg.ObtenerUsuarios());


            DgUsuarios.ItemsSource=filtradoUsuarios;
            lbTotal.Content = "Total de registros: " + Convert.ToString(DgUsuarios.Items.Count,cultures);
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            Window wd = new BuscadorPueblos();

            wd.ShowDialog();

        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, _nombreAplicacion, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje,_nombreAplicacion, MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void Limpiar()
        {
            txtApellidos.Clear();
            txtEmail.Clear();
            txtNombre.Clear();

            txtPass.Clear();
            txtRepePass.Clear(); 
            txtDni.Clear();
            txtTelefono.Text = "";
            txtCalle.Clear(); ;
            txtCalle2.Clear();
            txtCodigoPostal.Clear();

            ListPueblo.Clear();
            ListProvincia.Clear();


            lbUsuario.Content = "";
            cbNacido.Text = "";
			
			
          
          
        }
		
		 private void Limpiar2(DependencyObject obj)
        {
            TextBox tb = obj as TextBox;
            if (tb != null)
            {
                Validation.ClearInvalid(tb.GetBindingExpression(TextBox.TextProperty));
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
                Limpiar2(VisualTreeHelper.GetChild(obj, i));           
        }


        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _errors == 0;
            e.Handled = true;
        }

        private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            usu = new Usuario();
            DatosUsuarios.DataContext = usu;
            e.Handled = true;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;
        }



        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
           
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtEmail.Focus();

            usu = new Usuario();
           // usu.PropertyChanged += new PropertyChangedEventHandler(usuario_PropertyChanged);
            DatosUsuarios.DataContext = usu;         
            
            DgUsuarios.IsEnabled = false;           

        }






        private void ChkEliminar_Checked(object sender, RoutedEventArgs e)
        {
            this.DgUsuarios.Columns[0].Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
        }

        private void ChkEliminar_Unchecked(object sender, RoutedEventArgs e)
        {
            this.DgUsuarios.Columns[0].Visibility = Visibility.Collapsed;
            btnEliminar.Visibility = Visibility.Collapsed;
        }

        private void RbNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (RbNombre.IsChecked == true)
            {
                this.txtBusqueda.IsEnabled = true;

               
            }
            else
            {
                this.txtBusqueda.IsEnabled = false;
               
            }

        }

        private void RbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (RbDni.IsChecked == true)
            {
                txtBusqueda.IsEnabled = true;

            }
            else
            {
                txtBusqueda.IsEnabled = false;
            }

        }

        private void RbEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (RbEmail.IsChecked == true)
            {
                txtBusqueda.IsEnabled = true;

            }
            else
            {
                txtBusqueda.IsEnabled = false;
            }

        }

        private void TxtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            if (string.IsNullOrEmpty(txtBusqueda.Text.Trim()) == false)
            {


                 if (RbNombre.IsChecked == true)
                {

                    lbApellidos.Visibility = Visibility.Visible;
                    txtApellido.IsEnabled = true;
                    txtApellido.Visibility = Visibility.Visible;                  

                    IEnumerable<Usuario> query = from l in filtradoUsuarios where l.Nombre.StartsWith(txtBusqueda.Text,comparison) select l;

                    DgUsuarios.ItemsSource = query.ToList();
                    _listaUsuarios = query.ToList();

                    lbTotal.Content = "Total de registros: " + Convert.ToString(DgUsuarios.Items.Count,cultures);

                }
                else if (RbDni.IsChecked == true)
                {

                    var query = from l in _listaUsuarios where l.Dni.StartsWith(txtBusqueda.Text,comparison) select l;

                    DgUsuarios.ItemsSource = query.ToList();

                    lbTotal.Content = "Total de registros: " + Convert.ToString(DgUsuarios.Items.Count,cultures);
                }

                else if (RbEmail.IsChecked == true)
                {

                    var query = from l in _listaUsuarios where l.Email.StartsWith(txtBusqueda.Text,comparison) select l;

                    DgUsuarios.ItemsSource = query.ToList();
                    lbTotal.Content = "Total de registros: " + Convert.ToString(DgUsuarios.Items.Count,cultures);
                }
                else
                {
                    DgUsuarios.ItemsSource = _listaUsuarios;
                    txtBusqueda.Text = "";

                }


            }
            else
            {

               
                lbApellidos.Visibility = Visibility.Collapsed;
                txtApellido.IsEnabled = false;
                txtApellido.Visibility = Visibility.Collapsed;
                Mostrar();

            }
        }

        private void TxtApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()) == false)
            {

                IEnumerable<Usuario> query = from l in _listaUsuarios where l.Apellidos.StartsWith(txtApellido.Text,comparison) select l;

                  DgUsuarios.ItemsSource = query.ToList();

            }
            else
            {
                DgUsuarios.ItemsSource = _listaUsuarios.ToList();
            }
        }

      

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
          

          /// BindingExpression bi = txtNombre.GetBindingExpression(TextBox.TextProperty);
            //bi.UpdateSource();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);          
           // Limpiar2(DatosUsuarios);
            DgUsuarios.IsEnabled = true;
          //  Validation.ClearInvalid(txtEmail.GetBindingExpression(TextBox.TextProperty));

        }


        private void TxtNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
        }

        private void TxtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEmail.Clear();
        }

        private void TxtEmail_GotFocus_1(object sender, RoutedEventArgs e)
        {
            txtEmail.Clear();
        }

        private void TxtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPass.Clear();
        }

        private void txtRepePass_GotFocus(object sender, RoutedEventArgs e)
        {
            txtRepePass.Clear();
        }

        private void TxtApellidos_GotFocus(object sender, RoutedEventArgs e)
        {
            txtApellidos.Clear();
        }

        private void TxtDni_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDni.Clear();
        }

      

        private void TxtCalle_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCalle.Clear();
        }

        private void TxtCalle2_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCalle2.Clear();
        }

        private void TxtCodigoPostal_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCodigoPostal.Clear();
        }

        private void ListPueblo_GotFocus(object sender, RoutedEventArgs e)
        {
            ListPueblo.Clear();
        }

        private void ListProvincia_GotFocus(object sender, RoutedEventArgs e)
        {
            ListProvincia.Clear();
        }

        private void CbNacido_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

    

        private void TxtTelefono_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
