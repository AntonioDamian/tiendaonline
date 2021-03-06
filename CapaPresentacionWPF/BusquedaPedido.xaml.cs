﻿using CapaEntidades;
using CapaNegocio;
using MiLibreria;
using System;
using System.Collections.Generic;
using System.Data;
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



        private DataTable Dt { get; set; }

        public IBuscar Buscar { get; set; }

        public BusquedaPedido()
        {
            InitializeComponent();
            _negPedido = new NegocioPedido();
            _negLinped = new NegocioLinped();
            _negUsuario = new Negocio();

        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtNombreUsuario.IsEnabled = false;
             dateFecha.IsEnabled = false;

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

                var nombre = from usu in _listUsuarios
                             where usu.UsuarioID == _ListPedidos[i].UsuarioID
                             select usu.Nombre;


                foreach (var s in nombre)

                    Dt.Rows[i]["Nombre"] = s.ToString();

            }




            dtgPedidos.DataContext = Dt;

            comboBoxFiltro.Text = "Seleccionar Filtro";
            comboBoxFiltro.Items.Add("Nombre Usuario");
            comboBoxFiltro.Items.Add("Fecha Pedido");
            comboBoxFiltro.Items.Add("Nombre Usuario/Fecha Pedido");
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indice = comboBoxFiltro.SelectedIndex;

            if (indice == 0)
            {
                TxtNombreUsuario.IsEnabled = true;
                dateFecha.IsEnabled = false;
            }
            if (indice == 1)
            {
                dateFecha.IsEnabled = true;
                TxtNombreUsuario.IsEnabled = false;
            }
            if (indice == 2)
            {
                TxtNombreUsuario.IsEnabled = true;
                dateFecha.IsEnabled = true;
            }
        }
        private void TxtNombreUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
                if (string.IsNullOrEmpty(TxtNombreUsuario.Text.Trim()) == false)
                {

                    Dt.DefaultView.RowFilter = $"Nombre like'{TxtNombreUsuario.Text}%'";
                }
        }


        private void DateFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = dateFecha.SelectedDate.Value;

            /* DataView dv = new DataView(Dt);
             dv.RowFilter =String.Format("Fecha ='{0}'",date);*/

            Dt.DefaultView.RowFilter = String.Format("Fecha ='{0}'", date);
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
          
            
            if (dtgPedidos.Items.Count == 0)
            {
                return;
            }
            else
            {
             //   IList<Pedido> result = (IList<Pedido>)dtgPedidos.SelectedItem;



                DataGridRow rows = dtgPedidos.ItemContainerGenerator.ContainerFromItem(dtgPedidos.SelectedItem) as DataGridRow;
                DataRowView dr = (DataRowView)rows.Item;

                Pedido pedido = new Pedido();
                pedido.PedidoID = Convert.ToInt32(dr[0].ToString());
                pedido.UsuarioID = Convert.ToInt32(dr[1].ToString());
                pedido.Fecha = Convert.ToDateTime(dr[2].ToString());
                pedido.Linpeds = (List<Linped>)dr[3];

            /*    for (int i = 0; i < _ListPedidos.Count; i++)
                {

                    if (_ListPedidos[i].PedidoID == Convert.ToInt32(dr[1].ToString()))
                    {
                        pedido.Linpeds = _ListPedidos[i].Linpeds;
                    }

                }*/

                string nombre = dr[5].ToString();
               Buscar.DevolucionPedido(pedido,nombre);

                

                this.Close();

            }


        }

        private void Btncancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
