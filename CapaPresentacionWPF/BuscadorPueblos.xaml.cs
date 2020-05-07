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
using Capa_negocio;
using MiLibreria;


namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para BuscadorPueblos.xaml
    /// </summary>
    public partial class BuscadorPueblos : Window
    {
        Negocio _neg;
        NegocioLocalidad _negLocalidad;
        NegocioProvincia _negProvincia;
        public List<Localidad> _localidades = new List<Localidad>();
        public List<Provincia> _provincias = new List<Provincia>();

        public BuscadorPueblos()
        {
            InitializeComponent();
            _neg = new Negocio();
            _negLocalidad = new NegocioLocalidad();
            _negProvincia = new NegocioProvincia();

            _localidades = _negLocalidad.ObtenerLocalidades();
            _provincias = _negProvincia.ObtenerProvincias();

            pueblos.ItemsSource = _localidades;
          
           
           
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
