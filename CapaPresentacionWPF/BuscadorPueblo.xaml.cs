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
using CapaNegocio;
using CapaEntidades;
using System.Data;
using MiLibreria;

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para BuscadorPueblo.xaml
    /// </summary>
    public partial class BuscadorPueblo : Window
    {
        NegocioLocalidad _negocioLocalidad;
        NegocioProvincia _negocioProvincia;
        List<Localidad> _listLocalidades;
        List<Provincia> _listProvincias;

        public IBuscar Buscar { get; set; }

        DataTable Dt { get; set; }

        private StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

       

        public BuscadorPueblo()
        {
            InitializeComponent();
            _negocioLocalidad = new NegocioLocalidad();
            _negocioProvincia = new NegocioProvincia();

            CargarLocalidades();

        }


        private void CargarLocalidades()
        {
            _listLocalidades = new List<Localidad>();
            _listProvincias = new List<Provincia>();

            _listLocalidades = _negocioLocalidad.ObtenerLocalidades();
            _listProvincias = _negocioProvincia.ObtenerProvincias();

            Dt = Utilidades.ConvertToDataTable(_listLocalidades);

            DataColumn dtColum = Dt.Columns.Add("Provincia", typeof(string));

            for (int i = 0; i < _listLocalidades.Count; i++)
            {

                var nombre = from nom in _listProvincias
                             where nom.ProvinciaID == _listLocalidades[i].ProvinciaID
                             select nom.Nombre;


                foreach (var s in nombre)

                    Dt.Rows[i]["Provincia"] = s.ToString();

            }

            dataGrid.DataContext = Dt;


        }

        private void txtPueblo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPueblo.Text.Trim()) == false)
            {            

               // Dt.DefaultView.RowFilter = $"Nombre like'{txtPueblo.Text}%'";

                var query = from l in _listLocalidades where l.Nombre.ToUpper().StartsWith(txtPueblo.Text.ToUpper(), comparison) select l;

                dataGrid.DataContext = query;
            }                    
            else
            {
                CargarLocalidades();
            }


        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Items.Count == 0)
            {
                return;
            }
            else
            {
              
                Localidad loc = (Localidad)dataGrid.SelectedItem;
            
                Buscar.DevolucionLocalidad(loc);

                this.Close();

            }

        }
      

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
    }
}
