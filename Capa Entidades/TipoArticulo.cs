using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;						
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{

    /// <summary>
    /// Clase tipoArticulo
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class TipoArticulo:INotifyPropertyChanged
    {
      
        //Atributos
        private int _tipoArticuloID;
        private string _descripcion;
         public IEnumerable<Articulo> Articulos { get; set; }

        private ObservableCollection<Articulo> _listaArticulos;
        public ObservableCollection<Articulo> ListaArticulos
        { get => _listaArticulos;
                set { if (value != null){ _listaArticulos = value; } } }

        public event PropertyChangedEventHandler PropertyChanged;

      
        
      
        // Propiedades que necesitamos para el modelo Maestro-Detalle de los alumnos
    
        protected void OnPropertyChanged(string nombrePropiedad)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        //Propiedades
        public int TipoArticuloID { get => _tipoArticuloID;
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException("El tipoArticuloID no puede ser nulo");
                }

                _tipoArticuloID = value > 11 ? throw new ArgumentOutOfRangeException("tipoArticuloID no puede superar los 11 caracteres") : value;
            }
        }
        public string Descripcion { get => _descripcion;
            set
            {
                _descripcion = value.Length > 50 ? throw new ArgumentOutOfRangeException("Descripcion no puede superar los 50 caracteres") : value;
            }
        }

        //Constructor sin argumentos
        public TipoArticulo()
        {
            _tipoArticuloID =0;
            _descripcion = "descripcion";
			     _listaArticulos = new ObservableCollection<Articulo>();
        }

        //Constructor con argumentos
        public TipoArticulo(int tipoArticuloID, string descripcion)
        {
            _tipoArticuloID = tipoArticuloID;
            _descripcion = descripcion;
            _listaArticulos = new ObservableCollection<Articulo>();
        }
        public TipoArticulo(int tipoArticuloID, string descripcion, ObservableCollection<Articulo> listaArticulos)
        {
            _tipoArticuloID = tipoArticuloID;
            _descripcion = descripcion;
            _listaArticulos = listaArticulos;
            
        }
        

        //Constructor de copia
        public TipoArticulo(TipoArticulo otroTipoArticulo)
        {
            _tipoArticuloID = otroTipoArticulo._tipoArticuloID;
            _descripcion = otroTipoArticulo._descripcion;
        }

        //Destructor
        ~TipoArticulo()
        {
            _tipoArticuloID = 0;
            _descripcion = "";
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TipoArticuloID + "#" + Descripcion;
        }
    }
}
