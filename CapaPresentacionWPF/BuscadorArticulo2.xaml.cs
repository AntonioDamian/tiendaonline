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
using Capa_entidades;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para BuscadorArticulo2.xaml
    /// </summary>
    public partial class BuscadorArticulo2 : Window
    {
        public IBuscar Buscar { get; set; }

        public BuscadorArticulo2()
        {
            InitializeComponent();

        }
       

        protected void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uscbuspArticulo.GridSelectorChanged += new UscConsultaProductos.GridSelectorCommandEventHandler(Usc_GridSelectorChanged);
        }

        Articulo _articulo = new Articulo();

        void Usc_GridSelectorChanged(UscConsultaProductos.GridSelectorCommandEventArgs e)
        {
            _articulo = e.arti;

            Buscar.Ejecutar(_articulo);

            this.WindowState = WindowState.Minimized;
        }

    }
}
