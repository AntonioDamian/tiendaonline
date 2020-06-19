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

namespace CapaPresentacionWPF
{
    /// <summary>
    /// Lógica de interacción para PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {

        private FixedDocumentSequence _document;
        public PrintWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _document = null;
        }
    }
}
