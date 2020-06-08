using Capa_entidades;				 
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;							
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{


    /// <summary>
    /// Clase articulo
    /// </summary>
    /// <Author>Antº Damian Galvañ Candela</Author>
    public class Articulo:INotifyPropertyChanged
    {
        //Atributos

        private string _articuloID;
        private string _nombre;
        private decimal? _pvp;
        private string _marcaID;
        private byte[] _imagen;
        private string _urlimagen;
        private string _especificaciones;
        private int? _tipoArticuloID;
		
        public IEnumerable<Object> EspecificacionesisExtra1 { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private int? _cantidad;
        public int? Cantidad 
        {
            get { return _cantidad; }

            set { if (value != null) { _cantidad = value; } }
        }
        
        private ObservableCollection<Object> _espeExtra;      

        public ObservableCollection<Object> EspeExtra
        {
            get { return _espeExtra; }

            set { if (value != null) { _espeExtra = value; } }
        }
           public void OnPropertyChanged(string name)
           {
               if (PropertyChanged != null)
               {
                   PropertyChanged(this, new PropertyChangedEventArgs(name));
               }
           }
        //Propiedades      

        public string ArticuloID { get => _articuloID;
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                   _articuloID=value.Length>7? throw new ArgumentOutOfRangeException("ArticuloI no puede superar los 7 caracteres"):value;
                }
                _articuloID = value ?? throw new ArgumentNullException("El ArticuloI no puede ser nulo");
            }
        }
        public string Nombre { get => _nombre;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _nombre = value;
                }
                else
                {
                    _nombre = value.Length > 100 ? throw new ArgumentOutOfRangeException("El nombre no puede superar los 45 caracteres") : value;
                }
            }
         
            
        }
        public decimal? Pvp { get => _pvp; set => _pvp = value; }
        public string MarcaID
        {
            get => _marcaID;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _marcaID = value;
                }
                else
                {
                    _marcaID = value.Length > 15 ? throw new ArgumentOutOfRangeException("La marcaID no puede superar los 15 caracteres") : value;
                }
            }
           

        }
        public byte[] Imagen { get => _imagen; set => _imagen = value; }
        public string Urlimagen { get => _urlimagen;
            set {

                if (string.IsNullOrEmpty(value))
                {
                    _urlimagen = value;
                }
                else 
                {
                    _urlimagen=value.Length>100?throw new ArgumentOutOfRangeException("La url no puede superar los 100 caracteres"):value;
                }               
              

            }
          
        }
      
       // public string Especificaciones { get => _especificaciones; set => _especificaciones = value; }

        public int? TipoArticuloID
        {
            get => _tipoArticuloID;
            set =>
                 _tipoArticuloID = value > 11 ? throw new ArgumentOutOfRangeException("La tipoArticuloID no puede superar los 11 caracteres") : value;

        }
		  public string Especificaciones
        {
            get { return _especificaciones; }

            set { if (value != null) { _especificaciones = value; } }
        }							  

        //Constructor sin argumentos
        public Articulo()
        {
            _articuloID = "articuloI";
            _nombre = "nombre";
            _pvp = 0;
            _marcaID = "marcaID";
            _imagen = null;
            _urlimagen = "urlimagen";
            _especificaciones = "especificaciones";
            _tipoArticuloID = null;
             _cantidad = 0;
            _espeExtra = new ObservableCollection<Object>();
 
        }

        //Constructor con argumentos
        public Articulo(string articuloI, string nombre, decimal pvp, string marcaID, byte[] imagen,
		string urlimagen, string especificaciones, int tipoArticuloID)
        {
            _articuloID = articuloI;
            _nombre = nombre;
            _pvp = pvp;
            _marcaID = marcaID;
            _imagen = imagen;
            _urlimagen = urlimagen;           
            _especificaciones = especificaciones;
            _tipoArticuloID = tipoArticuloID;
			   _cantidad = 0;
            _espeExtra = new ObservableCollection<Object>();
			   
        }
        //Constructor de copia
        public Articulo(Articulo otroArticulo)
        {
            _articuloID =otroArticulo._articuloID;
            _nombre = otroArticulo._nombre;
            _pvp = otroArticulo._pvp;
            _marcaID = otroArticulo._marcaID;
            _imagen = otroArticulo._imagen;
            _urlimagen = otroArticulo._urlimagen;
            _especificaciones = otroArticulo._especificaciones;
            _tipoArticuloID = otroArticulo._tipoArticuloID;
           
        }
        //Destructor
        ~Articulo()
        {
            _articuloID ="";
            _nombre = "";
            _pvp = 0.0M;
            _marcaID ="";
            _imagen =null;
            _urlimagen = "";
            _especificaciones = "";
            _tipoArticuloID = null;
           

        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ArticuloID + "#" + Nombre + "#" + Pvp + "#" + MarcaID + "#" + Imagen + "#" + Urlimagen + "#" + Especificaciones+"#" + TipoArticuloID;
        }



       

    }
}
