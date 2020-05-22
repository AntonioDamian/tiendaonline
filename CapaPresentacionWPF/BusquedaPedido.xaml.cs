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
using System.Windows.Shapes;
using Capa_negocio;
using Capa_entidades;
using System.Data;
using MiLibreria;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para BusquedaPedido.xaml
    /// </summary>
    public partial class BusquedaPedido : Window
    {

        NegocioPedido _negPedido;
        List<Pedido> _ListPedidos;

        NegocioLinped _negLinped;
        List<Linped> _listLinpeds;

        Negocio _negUsuario;
        List<Usuario> _listUsuarios;



        public DataTable Dt { get; set; }

        public BusquedaPedido()
        {
            InitializeComponent(); 
            _negPedido = new NegocioPedido();
            _negLinped = new NegocioLinped();
            _negUsuario = new Negocio();


          
        }

      

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            DataView dv;
            _listLinpeds = new List<Linped>();
            _listLinpeds = _negLinped.ObtenerLinped();
            _ListPedidos = new List<Pedido>();
            _ListPedidos = _negPedido.ObtenerPedido();
            _listUsuarios = new List<Usuario>();
            _listUsuarios = _negUsuario.ObtenerUsuarios();



            for (int i = 0; i < _ListPedidos.Count; i++)
            {
                for (int j = 0; j < _listLinpeds.Count; j++)
                {
                    if (_ListPedidos[i].PedidoID == _listLinpeds[j].PedidoID)
                    {
                        _ListPedidos[i].AddLinped(_listLinpeds[j]);
                    }
                }

            }

            dt = Utilidades.ConvertToDataTable(_ListPedidos);

            DataColumn dtColum = dt.Columns.Add("Nombre", typeof(string));


            for (int i = 0; i < _ListPedidos.Count; i++)
            {

                var nombre = from usu in _listUsuarios
                             where usu.UsuarioID == _ListPedidos[i].UsuarioID
                             select usu.Nombre;


                foreach (var s in nombre)

                    dt.Rows[i]["Nombre"] = s.ToString();

            }


          //  dv = new DataView(Dt);

            return dt;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

          

            _listLinpeds = new List<Linped>();
            _listLinpeds = _negLinped.ObtenerLinped();
            _ListPedidos = new List<Pedido>();
            _ListPedidos = _negPedido.ObtenerPedido();
            _listUsuarios = new List<Usuario>();
            _listUsuarios = _negUsuario.ObtenerUsuarios();



            for (int i = 0; i < _ListPedidos.Count; i++)
            {
                for (int j = 0; j < _listLinpeds.Count; j++)
                {
                    if (_ListPedidos[i].PedidoID == _listLinpeds[j].PedidoID)
                    {
                        _ListPedidos[i].AddLinped(_listLinpeds[j]);
                    }
                }

            }

            Dt = Utilidades.ConvertToDataTable(_ListPedidos);

            DataColumn dtColum = Dt.Columns.Add("Nombre", typeof(string));
           

            for (int i = 0; i < _ListPedidos.Count; i++)
            {

                var  nombre = from usu in _listUsuarios
                             where usu.UsuarioID == _ListPedidos[i].UsuarioID
                             select usu.Nombre;

               
              foreach(var s in nombre)
                
                Dt.Rows[i]["Nombre"] = s.ToString();

            }


           // dv = new DataView(Dt);

            dtgPedidos.DataContext = Dt.DefaultView;
        }
    }
}
