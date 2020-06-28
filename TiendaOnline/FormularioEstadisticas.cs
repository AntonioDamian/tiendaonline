using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using CapaEntidades;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MiLibreria;

namespace TiendaOnline
{
    public partial class FormularioEstadisticas : Form
    {

        NegocioPedido _negPedido;
        List<Pedido> _listaPedidos;
        DateTime[] listaFechas;
        private DataView dv, df;
        private DataTable dt;

        NegocioLinped _negLinped;
        List<Linped> _listaLinpeds;

        




        public FormularioEstadisticas()
        {
             InitializeComponent();
            _negPedido = new NegocioPedido();
            _negLinped = new NegocioLinped();
        }

    

        private void FormularioEstadisticas_Load(object sender, EventArgs e)
        {

           
            _listaPedidos = new List<Pedido>();
            _listaLinpeds = _negLinped.ObtenerLinped();
          // chart1.ChartAreas.Clear();

             dt = new DataTable();
            DataTable distinc = new DataTable();


            _listaPedidos = _negPedido.ObtenerPedido();

            dt = Utilidades.ConvertToDataTable(_listaPedidos);
            dv = new DataView(dt);
 

            distinc = dv.ToTable(true, "Fecha");
            df = new DataView(distinc);

           
            listaFechas = new DateTime[df.Count];
            int i = 0;
            foreach (DataRowView rowView in df)
            {
                listaFechas[i] = Convert.ToDateTime(rowView["Fecha"].ToString()); 

                i++;
            }

          

            monthCalendar1.BoldedDates = listaFechas;


         /*  DateTime fecha = new DateTime(listaFechas[0].Year, listaFechas[0].Month, listaFechas[0].Day); 
            
            monthCalendar1.SetDate(fecha);*/


           
            numericAnyo.Maximum = listaFechas[listaFechas.Length - 1].Year;
            numericAnyo.Minimum = listaFechas[0].Year;
            numericAnyo.Value = listaFechas[0].Year;
            numericAnyo.Increment = 1;

        }

        private void comboMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
            int indesMes = comboMeses.SelectedIndex+1;
            string mes;
            mes = indesMes.ToString("D" + 2);

          

            List<Linped> listArt = listaArticulos(indesMes);

            EnumerableRowCollection<DataRow> query = from order in dt.AsEnumerable()
                                                     where order.Field<DateTime>("fecha").Month == indesMes
                                                     orderby order.Field<DateTime>("fecha").Month

                                                     select order;

            DataView view = query.AsDataView();

            dgvPedidosDia.DataSource = view;


            chart1.DataSource = listArt;
            chart1.Series["Articulo"].XValueMember = "articuloID";
            chart1.Series["Articulo"].XValueType =ChartValueType.String;
            chart1.Series["Articulo"].YValueMembers = "cantidad";
            chart1.Series["Articulo"].YValueType = ChartValueType.Int32;

           

        }


        public List<Linped> listaArticulos(int mes)
        {
          
            List<Linped> linpeds = new List<Linped>();

            List<Pedido> list = _listaPedidos.Where(x => x.Fecha.Month == mes ).ToList();



            for(int i=0;i<list.Count;i++)
            {
                for(int j=0;j<_listaLinpeds.Count;j++)
                {
                    if(_listaLinpeds[j].PedidoID.Equals(list[i].PedidoID))
                    {
                        linpeds.Add(_listaLinpeds[j]);
                    }
                }
            }




            return linpeds;
                 

        }

        private void numericAnyo_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fecham = new DateTime();

            fecham = monthCalendar1.SelectionRange.Start;

            dv.RowFilter = "fecha ='" + fecham + "'";

            dgvPedidosDia.DataSource = dv;

            /*  EnumerableRowCollection<DataRow> query = from order in dt.AsEnumerable()
                                                       where order.Field<DateTime>("fecha").Month == fecham.Month

                                                       select order;

              DataView view = query.AsDataView();

              dgvPedidosDia.DataSource = view;*/





        }
    }
}
