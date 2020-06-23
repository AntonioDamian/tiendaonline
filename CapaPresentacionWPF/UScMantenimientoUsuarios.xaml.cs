using Capa_entidades;
using Capa_negocio;
using MiLibreria;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para UScMantenimientoUsuarios.xaml
    /// </summary>
    public partial class UScMantenimientoUsuarios : UserControl,IBuscar
    {

        CultureInfo cultures = new CultureInfo("es-ES");
        private StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

        Negocio neg;
        List<Usuario> _listaUsuarios;
        Usuario usuario;

        private bool IsNuevo = false;
        private bool IsEditar = false;
        private bool IsEliminar = false;

        private int _errors = 0;
        List<int> listaIdUsuarios;


        DataTable dt = new DataTable();
        NegocioLocalidad negLocalidad;
        NegocioProvincia negProvincia;
        private ObservableCollection<Localidad> ListaPueblos;
        private ObservableCollection<Provincia> ListaProvincias;


        private string _repePass;


        public string RepePass
        {
            get { return _repePass; }
            set { _repePass = value; }
        }



        public UScMantenimientoUsuarios()
        {
            InitializeComponent();
            neg = new Negocio();

            negLocalidad = new NegocioLocalidad();
            negProvincia = new NegocioProvincia();

            ListaPueblos = new ObservableCollection<Localidad>(negLocalidad.ObtenerLocalidades() as List<Localidad>);
            ListaProvincias = new ObservableCollection<Provincia>(negProvincia.ObtenerProvincias() as List<Provincia>);


            Mostrar();
            this.Habilitar(true);
            txtRepePass.IsReadOnly = true;

            this.Botones();

            listaIdUsuarios = new List<int>();
            usuario = new Usuario();

        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Apitienda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Apitienda", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Limpiar(DependencyObject obj)
        {
            TextBox tb = obj as TextBox;
            if (tb != null)
                // tb.Text = "";
                tb.Clear();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
                Limpiar(VisualTreeHelper.GetChild(obj, i));

            /*  foreach (object c in tabControl.Items)
              {
                  if (c is TextBox)
                  {

                      (c as TextBox).Text = string.Empty;
                      //Enfoco en el primer TextBox
                      this.txtEmail.Focus();                

                  }
              }*/

            lbUsuario.Content = "";


            maskedTextTelefono.Text = "";
        }

        private void Limpiar2(DependencyObject obj)
        {
            TextBox tb = obj as TextBox;


            if (tb != null && tb.Name != "txtRepePass" && tb.Name != "PART_TextBox")
            {
                Validation.ClearInvalid(tb.GetBindingExpression(TextBox.TextProperty));
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
            {

                Limpiar2(VisualTreeHelper.GetChild(obj, i));
            }

        }

        private void Habilitar(bool valor)
        {
            this.txtApellidos.IsReadOnly = valor;
            this.txtEmail.IsReadOnly = valor;
            this.txtNombre.IsReadOnly = valor;

            txtPass.IsReadOnly = valor;
            // txtRepePass.IsReadOnly = valor;
            txtDni.IsReadOnly = valor;
            maskedTextTelefono.IsReadOnly = valor;
            txtCalle.IsReadOnly = valor;
            txtCalle2.IsReadOnly = valor;
            txtCodigoPostal.IsReadOnly = valor;
            CodPueblo.IsReadOnly = valor;
            CodProvincia.IsReadOnly = valor;

        }

        private void Botones()
        {
            if (this.IsNuevo == true && this.IsEditar == false)
            {
                this.Habilitar(true);
                this.btnNuevo.IsEnabled = true;
                //  this.btnGuardar.IsEnabled = true;
                this.btnEditar.IsEnabled = false;
                this.btnCancelar.IsEnabled = true;

            }
            if (this.IsEditar == true && IsNuevo == false)
            {
                this.Habilitar(true);
                this.btnNuevo.IsEnabled = false;
                //  this.btnGuardar.IsEnabled = true;
                this.btnEditar.IsEnabled = true;
                this.btnCancelar.IsEnabled = true;
            }
            if (IsEditar == false && IsNuevo == false)
            {
                this.Habilitar(false);
                this.btnNuevo.IsEnabled = true;
                this.btnEditar.IsEnabled = false;
                //  this.btnGuardar.IsEnabled = false;
                this.btnCancelar.IsEnabled = false;
            }
        }


        private void Mostrar()
        {


            _listaUsuarios = new List<Usuario>();
            _listaUsuarios = neg.ObtenerUsuarios();


            /*  dt = Utilidades.ConvertToDataTable(_listaUsuarios);
              dt.DefaultView.Sort = "UsuarioID";*/

            dgUsers.ItemsSource = _listaUsuarios;
            lbtotal.Content = "Total de registros: " + Convert.ToString(dgUsers.Items.Count, cultures);

            // List<Localidad> listaLocalidades = negLocalidad.ObtenerLocalidades();



            /* dictionarylocalidades = negLocalidad.TablaLocalidades();        

             DataView dvLocalidades = dictionarylocalidades.AsDataView();

             comboPueblo.DataContext = dvLocalidades;*/




            // dictionaryProvincias = negProvincia.TablaProvincias();
            // comboProvincia.ItemsSource = new System.Windows.Forms.BindingSource(dictionaryProvincias, null);
            // comboProvincia.DataContext = dictionaryProvincias;
            /* comboProvincia.Text = "ProvinciaID";
             comboProvincia.DisplayMemberPath = "nombre";*/
        }



        //controles y metodos de la pestaña listado

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


        private void DgUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;



            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {

                DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                Usuario us = (Usuario)dgr.Item;

                // DevolverUsuario(us);

            }

            tabControl.SelectedIndex = 1;


            IsEditar = true;
            Botones();
        }
        private void DgUsers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {

                DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                Usuario us = (Usuario)dgr.Item;

                TablaUsuarios.DataContext = us;
                //  DevolverUsuario(us);              

            }

            tabControl.SelectedIndex = 1;


            IsEditar = true;
            Habilitar(true);
            Botones();
        }



        private void DevolverUsuario(Usuario usuario)
        {


            lbUsuario.IsEnabled = true;
            lbUsuarioID.IsEnabled = true;



            lbUsuario.Content = usuario.UsuarioID.ToString(cultures);
            txtEmail.Text = usuario.Email;
            txtPass.Text = usuario.Password;
            txtRepePass.Text = usuario.Password;
            txtNombre.Text = usuario.Nombre;
            txtApellidos.Text = usuario.Apellidos;
            txtDni.Text = usuario.Dni;
            if (usuario.Telefono.Length == 9)
            {
                maskedTextTelefono.Text = usuario.Telefono.PadLeft(11, '#');

                /*  maskedTextTelefono.Text =
                      maskedTextTelefono.Text.PadLeft(11, '#');*/
            }
            else
            {
                maskedTextTelefono.Text = usuario.Telefono;
            }

            txtCalle.Text = usuario.Calle;
            txtCalle2.Text = usuario.Calle2;
            txtCodigoPostal.Text = usuario.Codpos;

            IEnumerable<Localidad> pueblo = from p in ListaPueblos where (p.LocalidadID == usuario.PuebloID) && (p.ProvinciaID == usuario.ProvinciaID) select p;
            IEnumerable<Provincia> provincia = from p in ListaProvincias where (p.ProvinciaID == usuario.ProvinciaID) select p;

            foreach (Localidad l in pueblo)
            {
                CodPueblo.Text = l.Nombre;
            }

            foreach (Provincia l in provincia)
            {
                CodProvincia.Text = l.Nombre;
            }


            if (usuario.Nacido == null)
            {

                cbNacido.Visibility = Visibility.Collapsed;
            }
            else
            {
                cbNacido.SelectedDate = Convert.ToDateTime(usuario.Nacido, cultures);
            }


        }

        private void ChkEliminar_Checked(object sender, RoutedEventArgs e)
        {
            this.dgUsers.Columns[0].Visibility = Visibility.Visible;


            btnEliminar.Visibility = Visibility.Visible;
        }
        private void ChkEliminar_Unchecked(object sender, RoutedEventArgs e)
        {
            this.dgUsers.Columns[0].Visibility = Visibility.Collapsed;
            btnEliminar.Visibility = Visibility.Collapsed;
        }






        private void BtnEliminar_Click_1(object sender, RoutedEventArgs e)
        {

            if (seleccionado == true)
            {
                Usuario usu = usuSeleccionado;
            }

            MessageBoxResult opcion;

            try
            {

                opcion = MessageBox.Show("Realmente desea eliminar los registros", "Apiventas", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (opcion == MessageBoxResult.OK)
                {
                    int count = 0;
                    bool valido = true;



                    foreach (int ius in listaIdUsuarios)
                    {

                        valido = neg.Borrar(Convert.ToInt32(ius));

                        if (valido)
                        {
                            count++;
                        }

                    }

                    if (count > 0)
                    {
                        this.MensajeOK(count + "Usarios se eliminarón correctamente ");
                    }
                    else
                    {
                        this.MensajeError("No se pudo eliminar el registro");
                    }
                }

                this.Mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }






        }







        //controles y metodos de la pestaña mantenimiento
        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar(this);
            Habilitar(false);

            // txtRepePass.Text = "Repepass";

            this.txtEmail.Focus();

            Usuario usuario = new Usuario();

            TablaUsuarios.DataContext = usuario;



        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

            // this.IsEditar = true;
            this.Botones();
            this.Habilitar(false);

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar(this);
            this.Habilitar(true);

            Mostrar();
            Limpiar2(this);


        }

        private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            usuario = new Usuario();
            btnGuardar.IsEnabled = true;

            e.Handled = true;

        }
        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // e.CanExecute = _errors == 0;
            e.CanExecute = TablaUsuarios.BindingGroup.CommitEdit();

            e.Handled = true;
        }



        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;
        }


        /*  private void BtnGuardar_Click(object sender, RoutedEventArgs e)
          {


              try
              {
                  bool bValidarEmail = ValidarEmail();
                  bool bValidarPass = ValidarPass();
                  bool bValidarRepPass = ValidarRePass();
                  bool bValidarNombre = ValidarNombre();
                  bool bValidarApellidos = ValidarApellidos();
                  bool bValidarDni = ValidarDni();
                  bool bValidarCodPOs = ValidarCodpos(); ;

                  bool bValidarDateTimePickerNacido = ValidarDateTimePickerNacido();


                  if (bValidarEmail && bValidarPass && bValidarRepPass && bValidarNombre && bValidarApellidos && bValidarDni && bValidarCodPOs 
                           && bValidarDateTimePickerNacido)
                  {
                      bool añadido = false;
                      string passMD5 = NegocioUsuario.ConvertirContrasenyaMD5(txtPass.Text);

                      string codigoLocalidad = CodPueblo.Text;
                      string codigoProvincia = CodProvincia.Text;

                      if (this.IsNuevo)
                      {


                          añadido = neg.Nuevo(txtEmail.Text, passMD5, txtNombre.Text, txtApellidos.Text, txtDni.Text, maskedTextTelefono.Text, txtCalle.Text, txtCalle2.Text, txtCodigoPostal.Text, codigoLocalidad, codigoProvincia, cbNacido.SelectedDate.Value);

                      }
                      else
                      {
                          añadido = neg.Actualizar(new Usuario(usuario.UsuarioID, txtEmail.Text, passMD5, txtNombre.Text, txtApellidos.Text, txtDni.Text, maskedTextTelefono.Text, txtCalle.Text, txtCalle2.Text, txtCodigoPostal.Text, codigoLocalidad, codigoProvincia, cbNacido.SelectedDate.Value));

                      }


                      if (añadido)
                      {
                          if (this.IsNuevo)
                          {
                              this.MensajeOK("Se insertó de forma correcta el registro");
                          }
                          else
                          {
                              this.MensajeOK("Se actualizó de forma correcta el registro");
                          }


                      }
                      else
                      {
                          this.MensajeError("ERROR,no se han podido introducir los datos");


                      }

                      this.IsNuevo = false;
                      this.IsEditar = false;
                      this.Botones();
                      // this.Limpiar();
                      this.Mostrar();
                  }
                  else
                  {
                      MensajeError("Falta ingresar algunos datos, serán remarcados");
                  }


              }
              catch (Exception ex)
              {

                  MessageBox.Show(ex.Message + ex.StackTrace);
              }
          }*/

      





        private void TxtPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPass.Text.Length == 0)
            {
                txtRepePass.IsReadOnly = false;
            }
        }

        bool seleccionado = false;
        Usuario usuSeleccionado;
        private void radio_Checked(object sender, RoutedEventArgs e)
        {
            seleccionado = true;

            usuSeleccionado = dgUsers.SelectedItem as Usuario;

        }

        private void radio_Unchecked(object sender, RoutedEventArgs e)
        {
            seleccionado = false;
        }

        private void BuscarPu_Click(object sender, RoutedEventArgs e)
        {
            BuscadorPueblo pueblo = new BuscadorPueblo();
            pueblo.Buscar = (IBuscar)this;
            pueblo.Show();
        }

        void IBuscar.Ejecutar(Articulo articulo)
        {
            throw new NotImplementedException();
        }

        void IBuscar.DevolucionPedido(Pedido pedido, string nombre)
        {
            throw new NotImplementedException();
        }

        void IBuscar.DevolucionLocalidad(Localidad localidad)
        {
            CodPueblo.Text=localidad.LocalidadID;
            CodProvincia.Text = localidad.ProvinciaID;
        }
    }
}
