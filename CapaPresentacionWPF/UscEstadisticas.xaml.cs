using Capa_entidades;
using Capa_negocio;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Xceed.Wpf.AvalonDock.Controls;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UscEstadisticas.xaml
    /// </summary>
    public partial class UscEstadisticas : UserControl
    {
        NegocioPedido _negocioPedido;
        NegocioLinped _negocioLinped;
        NegocioProducto _negProducto;

        List<Pedido> _listaPedidos;
        List<Linped> _listaLinpeds;
        List<Articulo> _listaArticulos;
        List<Linped> listArt1;

        public UscEstadisticas()
        {
            InitializeComponent();

          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _negocioLinped = new NegocioLinped();
            _negocioPedido = new NegocioPedido();
            _negProducto = new NegocioProducto();

            _listaPedidos = new List<Pedido>();
            _listaPedidos = new List<Pedido>();
            _listaArticulos = new List<Articulo>();

            _listaLinpeds = _negocioLinped.ObtenerLinped();
            _listaPedidos = _negocioPedido.ObtenerPedido();
            _listaArticulos = _negProducto.ObtenerArticulos();




            var listaFecha = _listaPedidos
                    .Select(i => i.Fecha)
                    .Distinct()
                    .OrderByDescending(s => s)
                    .ToList();

            CalendarioFechas.DisplayDate = DateTime.Now;

           

         // AddSelectedDates(listaFecha);

            

        }

        private void AddSelectedDates(List<DateTime> lista)
        {
            foreach (var f in lista)
            {

                CalendarioFechas.SelectedDates.Add(f);
               
            }



        }

        public List<Linped> listaArticulos(DateTime fecha)
        {

            List<Linped> linpeds = new List<Linped>();

            List<Pedido> list = _listaPedidos.Where(x => x.Fecha == fecha).ToList();

       
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


        public List<Linped> listaArticulosMes(DateTime fecha)
        {

            List<Linped> linpeds = new List<Linped>();

            List<Pedido> list = _listaPedidos.Where(x => x.Fecha.Month == fecha.Month).ToList();



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










        private void CalendarioFechas_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;

            if (calendar.SelectedDate.HasValue)
            {
                // ... Display SelectedDate in Title.
                DateTime date = calendar.SelectedDate.Value;

                string fecha = date.Year.ToString();
                string dia = date.Day.ToString();
                string mes = date.Month.ToString();

                DibujarGraficaColumnas(date);
                DibujarGraficaPiechart(date);
                DibujarGraficaPiechartTipos(date);


            }

            
        }

       private void DibujarGraficaColumnas(DateTime date)
       {
            List<Linped> listArt = listaArticulos(date);
            listArt.OrderBy(x => x.Cantidad).ToList();

            //grafico de barras

            if (listArt.Count > 0)
            {
                 SeriesCollection serie1 = new SeriesCollection();

                  if (listArt[0].Cantidad.Value != 0)
                  {
                      cart_ejeY.MaxValue = listArt[0].Cantidad.Value + 1;
                  }

                  string[] productos = new string[listArt.Count];

                  for (int i = 0; i < listArt.Count; i++)
                  {

                      serie1.Add(new ColumnSeries
                      {
                          Title=listArt[i].ArticuloID.ToString(),
                          Values = new ChartValues<int> { listArt[i].Cantidad.Value },
                          DataLabels = true,
                          LabelPoint = point => point.Y.ToString(),
                          MaxColumnWidth = 25

                      });

                      productos[i] = listArt[i].ArticuloID.ToString();


                  }

                cart_ejeX.LabelsRotation = 135;
                cart_ejeX.Labels = productos;                 
                BarraPedidos.Series = serie1;

              
                

                labelDia.Content = date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            }
            else
            {
                BarraPedidos.Series.Clear();
                labelDia.Content = "";
                MessageBox.Show("No hay Pedidos en la fecha" + date);
            }

        }



       
        private void DibujarGraficaPiechart(DateTime date)
       {
           

             listArt1 = listaArticulosMes(date);


            listArt1.OrderBy(x => x.Cantidad).ToList();



            //piechart
            if (listArt1.Count > 0)
            {
                ChartValues<int> chartvalue = new ChartValues<int>();
                SeriesCollection PieSeriesCollection2 = new SeriesCollection();

                for (int i = 0; i < listArt1.Count; i++)
                {
                    chartvalue = new ChartValues<int>();
                    chartvalue.Add(listArt1[i].Cantidad.Value);
                    PieSeries series2 = new PieSeries();
                    series2.DataLabels = true;
                    series2.Title = listArt1[i].ArticuloID;
                    series2.Values = chartvalue;
                    PieSeriesCollection2.Add(series2);

                }

                Piechart.Series = PieSeriesCollection2;

              

                labelmes.Content = date.Month;
            }
            //si no hay pedidos


           else
            {
                Piechart.Series.Clear();
                labelmes.Content = "";
                MessageBox.Show("No hay pedidos en el mes de " + date.Month);
            }
        }

        private void DibujarGraficaPiechartTipos(DateTime date)
        {
            List<Linped> listArt1 = listaArticulosMes(date);


            listArt1.OrderBy(x => x.Cantidad).ToList();

             Dictionary<string,int> tipos=TiposArticulo(listArt1);

            //piechart
            if (tipos.Count > 0)
            {
                ChartValues<int> chartvalue = new ChartValues<int>();
                SeriesCollection PieSeriesCollection2 = new SeriesCollection();

              
                foreach(var d in tipos)
                {
                   
                    chartvalue = new ChartValues<int>();
                    chartvalue.Add(d.Value);
                    PieSeries series2 = new PieSeries();                    
                    series2.DataLabels = true;
                    series2.Title = d.Key;
                    series2.Values = chartvalue;
                    PieSeriesCollection2.Add(series2);
                  
                    
                }

                


                Piechart1.Series = PieSeriesCollection2;               

                labelmes.Content = date.Month;
            }
            //si no hay pedidos


            else
            {
                Piechart1.Series.Clear();
                labelmes.Content = "";
                MessageBox.Show("No hay pedidos en el mes de " + date.Month);
            }
        }

        private Dictionary<string,int> TiposArticulo( List<Linped>lista)
        {
            Dictionary<string,int> tiposArticulo = new Dictionary<string,int>();

            int tv = 0, memoria = 0, camara = 0, objetivo = 0, paquete = 0;


            var list = (from l in _listaArticulos where (from b in listArt1 select b.ArticuloID).Contains(l.ArticuloID) select l).Distinct().ToList();

            for(int i=0;i<list.Count;i++)
            {
              

                switch(list[i].TipoArticuloID)
                {
                    case 1:
                        tv++;
                    break;
                    case 2:
                        memoria++;
                        break;
                    case 3:
                        camara++;
                        break;
                    case 4:
                        objetivo++;
                        break;
                    default:
                        paquete++;
                        break;

                }
            }


            tiposArticulo.Add("TV",tv);
            tiposArticulo.Add("Memoria",memoria);
            tiposArticulo.Add("Camara", camara);
            tiposArticulo.Add( "Objetivo", objetivo);
            tiposArticulo.Add( "Paquetes",paquete);






            return tiposArticulo;
        }

    }
}
