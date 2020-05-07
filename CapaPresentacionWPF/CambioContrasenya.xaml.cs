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


namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para CambioContraseña.xaml
    /// </summary>
    public partial class CambioContrasenya : Window
    {
        public CambioContrasenya()
        {
            InitializeComponent();
        }
        public CambioContrasenya(Usuario usu)
        {
            InitializeComponent();
        }


    }
}
