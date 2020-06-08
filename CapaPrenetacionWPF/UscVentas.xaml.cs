using Capa_entidades;
using Capa_negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UscVentas.xaml
    /// </summary>
    public partial class UscVentas : UserControl,IBuscar
    {

        CultureInfo cultures = new CultureInfo("es-ES");
        private StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

        private NegocioPedido _negpedido;
        private NegocioProducto _negproducto;
        private NegocioLinped _negLinped;
        NegociotipoArticulo _negociotipoArticulo;



        private List<Articulo> _listArticulos;
        List<Linped> linpeds = new List<Linped>();
        Linped li = new Linped();
        Pedido pedido;


        private ObservableCollection<TipoArticulo> ListaProductos;

        DataTable dt;



        decimal importeTotal = 0;
        decimal precio = 0;
        int cantidad = 0;
        string id = "";
        int num_fila = 1;

        decimal total;
        decimal totalConIva;
        decimal totalIva;

        public UscVentas()
        {
            InitializeComponent();
            pedido = new Pedido();
           _negpedido = new NegocioPedido();
           _negLinped = new NegocioLinped();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            _negproducto = new NegocioProducto();

            _listArticulos = new List<Articulo>();
          
            _negociotipoArticulo = new NegociotipoArticulo();
            TxTFecha.SelectedDate = DateTime.Now;
            //  ListaProductos = _negociotipoArticulo.ListadoTipos();


            //  listArticulosStock.ItemsSource = ListaProductos;



        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Reset();
         
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _negpedido.ObtenerPedido();

            int ultimoPedido = pedidos.Last().PedidoID + 1;

            TxTPedidoID.Text = ultimoPedido.ToString();
            pedido.PedidoID = Convert.ToInt32(ultimoPedido.ToString());
            TxTFecha.SelectedDate = DateTime.Now;
        }

        private void Reset()
        {
            TxTPedidoID.Text = "";
            TxTUsuarioID.Text = "";
            TxTNombreCliente.Text = "";
            TxTFecha.Text = "";

            lbIdProducto.Content = "";
            lbNombreProducto.Content = "";
            lbPrecio.Content = "";
            cantdidadArt.Value = 0;
          
              
               num_fila = 1;
               lbSubTotal.Content = "0";
               lbIva.Content = "0";
               lbIva.Content = "0";
               total = 0;
               totalConIva = 0;
               totalIva = 0;

               listaVentas.Items.Clear();
               TxTUsuarioID.Focus(); ;
        }

        //  MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        private void BtnBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            BuscadorUsuario bsUsu = new BuscadorUsuario(this);
         
            bsUsu.ShowDialog();


        }



        public  void ClienteCompra2(IList us)
        {

            foreach (Usuario usua in us)
            {
                TxTNombreCliente.Text = usua.Nombre.ToString();
                TxTUsuarioID.Text = usua.UsuarioID.ToString();
            }




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
            catch (ArgumentNullException)
            {

                throw;
            }

        }
        private void TxtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {

       
        
                decimal precio = Convert.ToDecimal(lbPrecio.Content);
                int cantidad = Convert.ToInt32(cantdidadArt.Text);

                decimal resultado = precio * cantidad;

                lbPrecioTotal.Content = resultado.ToString();
          


        }

        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }


      


      

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
           /* dt = new DataTable();
            dt.Columns.Add("Linea");
            dt.Columns.Add("ArticuloID");
            dt.Columns.Add("Importe");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("ImporteTotal");*/


            try
            {
                if (string.IsNullOrEmpty(lbIdProducto.Content.ToString()) )
                {
                    MessageBox.Show("Faltan  id del producto ");
                    return;
                }
                if(Convert.ToInt32(lbStock.Content.ToString()) == 0)
                {
                    MessageBox.Show("No hay suficiente stock");
                    return;
                }
                if (lbPrecio.Content.ToString().Length == 0)
                {
                    MessageBox.Show("No tenemos ningun precio de venta");
                    return;
                }
                else
                {
                    // bool registro = true;


                    if (linpeds.Count > 0)
                    {
                        var l = linpeds.Where(x => x.ArticuloID.Equals(lbIdProducto.Content.ToString(), comparison)).ToList();

                        if (l.Count > 0)
                        {


                            foreach (var t in l)
                            {
                                cantidad = Convert.ToInt32(t.Cantidad);
                                importeTotal = Convert.ToDecimal(cantidad * t.Importe);
                                id = t.ArticuloID;
                                precio = t.Importe;
                                num_fila = t.Linea;
                            }

                            li = new Linped(Convert.ToInt32(TxTPedidoID.Text), num_fila, id, precio, cantidad + Convert.ToInt32(cantdidadArt.Text));

                            linpeds.RemoveAt(num_fila - 1);
                            linpeds.Insert(num_fila - 1, li);
                            importeTotal += Convert.ToDecimal(cantidad) * Convert.ToDecimal(lbPrecioTotal.Content);

                            listaVentas.Items.RemoveAt(num_fila - 1);
                            listaVentas.Items.Insert(num_fila - 1,
                                new { Linea = num_fila, ArticuloID = id, Importe = precio, Cantidad = cantidad + Convert.ToInt32(cantdidadArt.Text), ImporteTotal =  importeTotal });



                        }
                        else
                        {

                            cantidad = Convert.ToInt32(cantdidadArt.Text);
                            importeTotal = Convert.ToDecimal(lbPrecio.Content.ToString()) * Convert.ToDecimal(cantdidadArt.Text);
                            id = lbIdProducto.Content.ToString();
                            precio = Convert.ToDecimal(lbPrecio.Content.ToString());


                          
                            listaVentas.Items.Add(new { Linea = num_fila, ArticuloID = id, Importe = precio, Cantidad = cantidad, ImporteTotal = importeTotal });
                            li = new Linped(Convert.ToInt32(TxTPedidoID.Text), num_fila , lbIdProducto.Content.ToString(),
                                Convert.ToDecimal(lbPrecio.Content.ToString()),
                                               Convert.ToInt32(cantdidadArt.Text));
                            linpeds.Add(li);


                        }
                    }
                    //nuevo
                    else
                    {

                        importeTotal = Convert.ToDecimal(lbPrecio.Content.ToString()) * Convert.ToDecimal(cantdidadArt.Text);
                        id = lbIdProducto.Content.ToString();
                        precio = Convert.ToDecimal(lbPrecio.Content.ToString());
                        cantidad = Convert.ToInt32(cantdidadArt.Text);

                         /*  DataView dv = new DataView();
                           dt = dv.Table;*/

                         /*  DataRow dr = dt.NewRow();
                           dr["Linea"] = num_fila;
                           dr["ArticuloID"] = id;
                           dr["Importe"] = precio;
                           dr["Cantidad"] = cantidad;
                           dr["ImporteTotal"] = importeTotal;
                           dt.Rows.Add(dr);*/

                      //  listaVentas.DataContext = dt;

                      
                        listaVentas.Items.Add(new {Linea=num_fila,ArticuloID=id,Importe=precio,Cantidad=cantidad,ImporteTotal=importeTotal } );
                        

                        li = new Linped(Convert.ToInt32(TxTPedidoID.Text), num_fila, lbIdProducto.Content.ToString(), Convert.ToDecimal(lbPrecio.Content.ToString()),
                                                 Convert.ToInt32(cantdidadArt.Text));
                        linpeds.Add(li);
                       // listaVentas.Items.Add(li);
                        

                        num_fila++;

                    }


                    pedido.Linpeds = linpeds;
                    decimal iva = Convert.ToDecimal(txtIva.Text);

                    ResumenFactura(pedido, iva);

                   
                }


            }
            catch (FormatException )
            {

                MessageBox.Show("Faltan datos" );
            }
        }

        private void ResumenFactura(Pedido pedido,decimal iva)
        {
            decimal[] resumenFactura = new decimal[4];

            resumenFactura = _negpedido.Datosfactura(pedido, iva);

            total = resumenFactura[0];
            totalIva = resumenFactura[1];
            totalConIva = resumenFactura[2];

            lbSubTotal.Content = total.ToString() + " €";
            lbIva.Content = totalIva.ToString() + " €";
            lbTotalConIva.Content = totalConIva.ToString() + " €";
        }


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

            if(Application.Current.Windows.OfType<BuscadorArticulo2>().Count()==0)
            {
                BuscadorArticulo2 buscadorArticulo = new BuscadorArticulo2();
                buscadorArticulo.Buscar = (IBuscar)this;
                buscadorArticulo.Opacity = 0.8;
                buscadorArticulo.Show();
            }


         

        }

        public void ArticuloSeleccionado(Articulo articuloSeleleccionado)
        {
            if (articuloSeleleccionado != null)
            {

                lbIdProducto.Content = articuloSeleleccionado.ArticuloID;
                lbNombreProducto.Content = articuloSeleleccionado.Nombre;
                lbPrecio.Content = articuloSeleleccionado.Pvp.ToString();
                lbStock.Content = articuloSeleleccionado.Cantidad;

                lbPrecioTotal.Content = "";
                cantdidadArt.Value= 0;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (listaVentas.SelectedCells != null)
            {
                int index = listaVentas.SelectedIndex;
                listaVentas.Items.RemoveAt(index);
                num_fila--;
            }



        }


        private void BtnbuscarPedido_Click(object sender, RoutedEventArgs e)
        {
            BusquedaPedido buspedido = new BusquedaPedido();
            buspedido.Buscar = (IBuscar)this;
            buspedido.Show();

        }

        //metodos interface Ibuscar

        public void Ejecutar(Articulo articulo)
        {

            if (articulo != null)
            {
                lbIdProducto.Content = articulo.ArticuloID;
                lbNombreProducto.Content = articulo.Nombre;
                lbPrecio.Content = articulo.Pvp.ToString();
                lbStock.Content = articulo.Cantidad;

                lbPrecioTotal.Content = "";
                cantdidadArt.Value=0;

            }


        }

        public void DevolucionPedido(Pedido pedido,string nombre)
        {
           if(pedido!=null)
            {
                TxTPedidoID.Text = pedido.PedidoID.ToString();
                TxTUsuarioID.Text = pedido.UsuarioID.ToString();
                TxTNombreCliente.Text = nombre;
                TxTFecha.DisplayDate = Convert.ToDateTime(pedido.Fecha.ToShortDateString());

                foreach(Linped li in pedido.Linpeds)
                {
                    listaVentas.Items.Add(new { Linea= li.Linea, ArticuloID =li.ArticuloID, Importe = li.Importe,
                        Cantidad = li.Cantidad, ImporteTotal = li.Importe*li.Cantidad });
                }
                //  listaVentas.ItemsSource = pedido.Linpeds;
                txtIva.Text = "21";
                ResumenFactura(pedido, 21);
            }
        }

        private void Btnsalir_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool exito = false;
            int lista = linpeds.Count();

            if (TxTPedidoID.Text != null && linpeds.Count>0)
            {
                exito = _negpedido.NuevoPedido(Convert.ToInt32(TxTPedidoID.Text), Convert.ToInt32(TxTUsuarioID.Text),
                                                 DateTime.ParseExact(TxTFecha.SelectedDate.Value.ToShortDateString(), "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture), linpeds);
               

                if(exito==true)
                {
                    foreach (Linped li in linpeds)
                    {
                        int cant = Convert.ToInt32(li.Cantidad);
                        if (_negLinped.NuevoLinped(li.PedidoID, li.Linea, li.ArticuloID, li.Importe, cant))
                        {
                            lista--;
                        }



                    }

                }


            }
            else
            {
                MessageBox.Show("No hay ningun pedido para guardar");
            }

            if(exito==true && lista==0)
            {
                MessageBox.Show("Guardado con exito el pedido nº " + TxTPedidoID.Text);
            }
            else
            {
                MessageBox.Show("No se ha posdido guardae  el pedido nº " + TxTPedidoID.Text);
            }
        }

        private void CantdidadArt_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

         
            int cantidad = Convert.ToInt32(cantdidadArt.Value);
            decimal precio = Convert.ToDecimal(lbPrecio.Content.ToString());
            decimal resultado = precio * cantidad;

            lbPrecioTotal.Content = resultado.ToString();


        }

      
    }
}
