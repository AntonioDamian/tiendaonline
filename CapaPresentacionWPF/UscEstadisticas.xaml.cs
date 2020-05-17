﻿using System;
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
using MiLibreria;
using Capa_entidades;
using Capa_negocio;
using LiveCharts;
using LiveCharts.Wpf;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para UscEstadisticas.xaml
    /// </summary>
    public partial class UscEstadisticas : UserControl
    {
        NegocioPedido _negocioPedido;
        NegocioLinped _negocioLinped;

        List<Pedido> _listaPedidos;
        List<Linped> _listaLinpeds;

        public UscEstadisticas()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _negocioLinped = new NegocioLinped();
            _negocioPedido = new NegocioPedido();

            _listaPedidos = new List<Pedido>();
            _listaPedidos = new List<Pedido>();

            _listaLinpeds = _negocioLinped.ObtenerLinped();
            _listaPedidos = _negocioPedido.ObtenerPedido();


        

            var listaFecha = _listaPedidos
                    .Select(i => i.Fecha)
                    .Distinct()
                    .OrderByDescending(s => s)
                    .ToList();

           // AddSelectedDates(listaFecha);
            
        }

        private void AddSelectedDates(List<DateTime>lista)
        {
           foreach(var f in lista)
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


        List<string> _columnXLabels = new List<string>();


        public List<string> ColumnXLabels
        {
            get
            {
                return _columnXLabels;
            }

            set
            {
                _columnXLabels = value;
            }
        }

        SeriesCollection _colunmSeriesCollection = new SeriesCollection();
        public SeriesCollection ColunmSeriesCollection { get => _colunmSeriesCollection; set => _colunmSeriesCollection = value; }
        public Func<int, string> Formatter { get; set; }
        public List<string> Labels { get => _labels; set => _labels = value; }

        private List<string> _labels = new List<string>();

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

                List<Linped> listArt = listaArticulos(date);



                ChartValues<int> chartvalue = new ChartValues<int>();
                SeriesCollection PieSeriesCollection2 = new SeriesCollection();

                for (int i = 0; i < listArt.Count; i++)
                {
                    chartvalue = new ChartValues<int>();
                    chartvalue.Add(listArt[i].Cantidad.Value);
                    PieSeries series2 = new PieSeries();
                    series2.DataLabels = true;
                    series2.Title = listArt[i].ArticuloID;
                    series2.Values = chartvalue;
                    PieSeriesCollection2.Add(series2);

                }

                Piechart.Series = PieSeriesCollection2;


                List<int?> columValues = new List<int?>();

                

                for (int i = 0; i < listArt.Count; i++)
                {
                    ColunmSeriesCollection.Add(new ColumnSeries
                    {
                        Title = listArt[i].ArticuloID,
                        Values = new ChartValues<int> { listArt[i].Cantidad.Value }
                    });

                    string s = listArt[i].ArticuloID.ToString();
                    Labels.Add(s);

                }

               
                Formatter = value => value.ToString("N");

              
                
            }

            DataContext = this;
        }
    }
}