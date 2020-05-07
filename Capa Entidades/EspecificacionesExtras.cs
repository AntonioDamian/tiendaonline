using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_entidades;

namespace Capa_Entidades
{
    public class EspecificacionesExtras : INotifyPropertyChanged
    {
      

        private Camara _camara;

        public Camara Camara
        {
            get
            {
                return _camara;
            }

            set
            {
                _camara = value;
                OnPropertyChanged("Camara");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nombrePropiedad)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
