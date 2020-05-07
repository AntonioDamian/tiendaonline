using Capa_entidades;
using Capa_negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Lógica de interacción para UscVentas.xaml
    /// </summary>
    public partial class UscVentas : UserControl
    {

        CultureInfo cultures = new CultureInfo("es-ES");
        private StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

        private NegocioPedido _pedido;
        private NegocioProducto _negproducto;
        private NegocioLinped _negLinped;
        NegociotipoArticulo _negociotipoArticulo;

         Articulo _articulo;

        private List<Articulo> _listArticulos;
        List<Linped> linpeds = new List<Linped>();
        Linped li = new Linped();
        Pedido pedido;


        private ObservableCollection<TipoArticulo> ListaProductos;

        public UscVentas()
        {
            InitializeComponent();
          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _pedido = new NegocioPedido();
            _negproducto = new NegocioProducto();

            _listArticulos = new List<Articulo>();
            _negLinped = new NegocioLinped();
            _negociotipoArticulo = new NegociotipoArticulo();
            ListaProductos = _negociotipoArticulo.ListadoTipos();


            listArticulosStock.ItemsSource = ListaProductos;


            pedido = new Pedido();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Reset();

            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _pedido.ObtenerPedido();

            int ultimoPedido = pedidos.Last().PedidoID + 1;

            TxTPedidoID.Text = ultimoPedido.ToString();
            pedido.PedidoID = Convert.ToInt32(ultimoPedido.ToString());
        }

        private void Reset()
        {
            TxTPedidoID.Text = "";
            TxTUsuarioID.Text = "";
            TxTNombreCliente.Text = "";
            
          /*   txtPrecioArticulo.Text = "";
             txtCantidadArticulo.Text = "";
             cont_filas = 0;
             lbTotal.Text = "0";
             lbIva.Text = "0";
             lbTotalIVa.Text = "0";
             total = 0;
             totalConIva = 0;
             totalIva = 0;

             dgvLinped.Rows.Clear();*/
            TxTUsuarioID.Focus(); ;
        }

       //  MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        private void BtnBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            BuscadorUsuario bsUsu = new BuscadorUsuario(this);

            bsUsu.Opacity = 0.8;
            bsUsu.ShowDialog();     


        }


        public void ClienteCompra(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    TxTUsuarioID.Text = usuario.UsuarioID.ToString(cultures);
                    TxTNombreCliente.Text = usuario.Nombre.ToString(cultures);
                }
              
            }
            catch (ArgumentNullException )
            {

                throw;
            }
           
        }

        

        private void Articulos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
<<<<<<< Updated upstream
         
         /*   Window wd = new Window();
=======
>>>>>>> Stashed changes

            Articulo articuloSelecionado = Articulos.SelectedItem as Articulo;

            lbIdProducto.Content = articuloSelecionado.ArticuloID;
            lbNombreProducto.Content = articuloSelecionado.Nombre;
            lbPrecio.Content =articuloSelecionado.Pvp.ToString();
            lbStock.Content = articuloSelecionado.Cantidad;

            lbPrecioTotal.Content = "";
            txtCantidad.Text = "";

        }     


<<<<<<< Updated upstream
            wd.ShowDialog();*/
=======
    
>>>>>>> Stashed changes

        private void TxtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            decimal precio = Convert.ToDecimal(lbPrecio.Content);
            try
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                decimal resultado = precio * cantidad;

                lbPrecioTotal.Content = resultado.ToString();

<<<<<<< Updated upstream
            BusquedaProducto busqueda = new BusquedaProducto();
            busqueda.Owner = Window.GetWindow(this);
            busqueda.Opacity = 0.5;
            busqueda.ShowDialog();
=======

            }
            catch (FormatException)
            {
                MessageBox.Show("Solo numeros", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
>>>>>>> Stashed changes
        }

        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

      
        List<object> listao = new List<object>();
        decimal importeTotal = 0;
        decimal precio = 0;
        int cantidad = 0;
        string id = "";
        int cont_fila = 0;


        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
           

            try
            {
                if(string.IsNullOrEmpty(lbIdProducto.Content.ToString()) || lbStock.Content.ToString().Length==0  )
                {
                    MessageBox.Show("Faltan ingresar algunos datos");

                }
                else if(lbPrecio.Content.ToString().Length==0)
                {
                    MessageBox.Show("No tenemos ningun precio de venta");
                }
                else
                {
                   // bool registro = true;
                    int num_fila = 0;

                    if (linpeds.Count > 0)
                    {
                        var l = linpeds.Where(x => x.ArticuloID.Equals(lbIdProducto.Content.ToString(),comparison)).ToList();

                        if(l.Count>0)
                        {
                           // registro = false;

                            foreach(var t in l)
                            {
                                cantidad = Convert.ToInt32(t.Cantidad) +Convert.ToInt32( txtCantidad.Text);
                                importeTotal = Convert.ToDecimal(cantidad * t.Importe);
                                id = t.ArticuloID;
                                precio = t.Importe;
                                num_fila = t.Linea;
                            }

                            li = new Linped(Convert.ToInt32(TxTPedidoID.Text), num_fila, id, precio, cantidad);

                            linpeds.RemoveAt(num_fila);
                            linpeds.Insert(num_fila, li);

                            listaVentas.Items.RemoveAt(num_fila);
                            listaVentas.Items.Insert(num_fila,new { num_fila, id, precio, cantidad, importeTotal });


                        }
                        else
                        {
                            li = new Linped(Convert.ToInt32(TxTPedidoID.Text), num_fila, lbIdProducto.Content.ToString(), Convert.ToDecimal(lbPrecio.Content.ToString()),
                                                 Convert.ToInt32(txtCantidad.Text));
                            linpeds.Add(li);

                            importeTotal = Convert.ToDecimal(lbPrecio.Content.ToString()) * Convert.ToDecimal(txtCantidad.Text);
                            id = lbIdProducto.Content.ToString();
                            precio = Convert.ToDecimal(lbPrecio.Content.ToString());
                            num_fila = num_fila + 1;
                            ListViewItem item = new ListViewItem();
                            item.Content = new { num_fila, id, precio, txtCantidad.Text, importeTotal };
                            listao.Add(item);
                            listaVentas.Items.Add(new { num_fila, id, precio, txtCantidad.Text, importeTotal });

                            cont_fila++;
                        }


                    }
                    else
                    {
                        li = new Linped(Convert.ToInt32(TxTPedidoID.Text), num_fila, lbIdProducto.Content.ToString(), Convert.ToDecimal(lbPrecio.Content.ToString()),
                                                  Convert.ToInt32(txtCantidad.Text));
                        linpeds.Add(li);

                        importeTotal = Convert.ToDecimal(lbPrecio.Content.ToString()) * Convert.ToDecimal(txtCantidad.Text);
                        id = lbIdProducto.Content.ToString();
                        precio = Convert.ToDecimal(lbPrecio.Content.ToString());
                        cantidad =Convert.ToInt32( txtCantidad.Text);
                        num_fila = num_fila + 1;
                        ListViewItem item = new ListViewItem();
                        item.Content = new { num_fila, id, precio, txtCantidad.Text, importeTotal };
                        listao.Add(item);
                        listaVentas.Items.Add(new { num_fila, id, precio,cantidad, importeTotal });

                       
                        cont_fila++;

                    }
                   
                 


                     

                
                  
                }

            }
            catch (FormatException)
            {

                MessageBox.Show("Faltan datos");
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscadorArticulo buscadorArticulo = new BuscadorArticulo();
            buscadorArticulo.Opacity = 0.8;
            buscadorArticulo.ShowDialog();
        }
    }
}
