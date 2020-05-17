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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using Capa_entidades;
using Capa_negocio;
using System.Data;
using MiLibreria;
using LiveCharts.Configurations;
using System.Runtime.Serialization;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para PruebaCharts.xaml
    /// </summary>
    public partial class PruebaCharts : UserControl
    {

        NegocioPedido _negPedido;
        List<Pedido> _listaPedidos;
        DateTime[] listaFechas;
        private DataView dv, df;
        private DataTable dt;

        NegocioLinped _negLinped;
        private List<Linped> listArt;
        List<Linped> _listaLinpeds;
        
        public PruebaCharts()
        {
            InitializeComponent();
            _negPedido = new NegocioPedido();
            _negLinped = new NegocioLinped();

          

        }

     //   Func<ChartPoint, string> label = chartpoint => string.Format("{0}({1:p})", chartpoint.Y, chartpoint.Participation);


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            pie.LegendLocation = LegendLocation.Bottom;

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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listArt = listaArticulos(8);
          /*  SeriesCollection series = new SeriesCollection();
            foreach (var obj in listArt)
                series.Add(new PieSeries() { Title = obj.ArticuloID, Values = new ChartValues<int> { obj.Cantidad.Value }, DataLabels = true, LabelPoint = label });
*/

            ChartValues<int> chartvalue = new ChartValues<int>();
            SeriesCollection PieSeriesCollection2 = new SeriesCollection();
          
            for (int i = 0; i <listArt.Count; i++)
            {
                chartvalue = new ChartValues<int>();
                chartvalue.Add(listArt[i].Cantidad.Value);
                PieSeries series2 = new PieSeries();
                series2.DataLabels = true;
                series2.Title = listArt[i].ArticuloID;
                series2.Values = chartvalue;
                PieSeriesCollection2.Add(series2);
               
            }

          

         
            pie.Series = PieSeriesCollection2;
          
          
            GetPieSeriesData();
            GetColunmSeriesData(listArt);
            // pie.LegendLocation = LegendLocation.Right;

            DataContext = this;
        }

        public List<Linped> listaArticulos(int mes)
        {

            List<Linped> linpeds = new List<Linped>();

            List<Pedido> list = _listaPedidos.Where(x => x.Fecha.Month == mes).ToList();



            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < _listaLinpeds.Count; j++)
                {
                    if (_listaLinpeds[j].PedidoID.Equals(list[i].PedidoID))
                    {
                        linpeds.Add(_listaLinpeds[j]);
                    }
                }
            }




            return linpeds;


        }
      

        void GetPieSeriesData()
        {
            List<string> titles = new List<string> { "C#", "Java", "Python" };
            List<double> pieValues = new List<double> { 60, 30, 10 };

            ChartValues<double> chartvalue = new ChartValues<double>();
            SeriesCollection PieSeriesCollection = new SeriesCollection();

            for (int i = 0; i < titles.Count; i++)
            {
                chartvalue = new ChartValues<double>();
                chartvalue.Add(pieValues[i]);
                PieSeries series = new PieSeries();
                series.DataLabels = true;
                series.Title = titles[i];
                series.Values = chartvalue;
                PieSeriesCollection.Add(series);
            }

            pie2.Series = PieSeriesCollection;
        }

       
        List<string> _columnXLabels = new List<string>();

      
        public List<string> ColumnXLabels {
             get
            {
                return _columnXLabels;
            }

            set
            {
                _columnXLabels = value;
            }
        }
        public SeriesCollection ColunmSeriesCollection { get => _colunmSeriesCollection; set => _colunmSeriesCollection = value; }
        public Func<int, string> Formatter { get; set; }

        SeriesCollection _colunmSeriesCollection = new SeriesCollection();

        void GetColunmSeriesData(List<Linped> lista)
        {
           
            List<int?> columValues = new List<int?>();

           
            for (int i = 0; i < lista.Count; i++)
            {
                ColunmSeriesCollection.Add(new ColumnSeries
                {
                    Title = lista[i].ArticuloID,
                    Values = new ChartValues<double> { lista[i].Cantidad.Value }
                });

            }

            ColunmSeriesCollection[1].Values.Add(48d);
            Formatter = value => value.ToString("N");
        }

       
    }
}
