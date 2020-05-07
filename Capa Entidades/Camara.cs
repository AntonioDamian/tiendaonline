using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{


    /// <summary>
    /// Clase camara
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class Camara
    {
        //Atributos
        private string _camaraID;
        private string _resolucion;
        private string _sensor;
        private string _tipo;
        private string _factor;
        private string _objetivo;
        private string _pantalla;
        private string _zoom;

        //Propiedades 
        public string CamaraID { get => _camaraID;
            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentOutOfRangeException("CamaraID no puede superar los 7 caracteres");
                }
                _camaraID = value ?? throw new ArgumentNullException("CamaraID no puede ser nulo");
            }
        }
        public string Resolucion { get => _resolucion;
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    _resolucion = value;
                }
                else
                {
                    _resolucion = value.Length > 15 ? throw new ArgumentOutOfRangeException("La descripcion de  resolucion no puede ser mayor a 15 caracteres") : value;
                }
               
              
            }
        }
        public string Sensor { get => _sensor;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _sensor = value;
                }
                else
                {
                    _sensor = value.Length > 45 ? throw new ArgumentOutOfRangeException("La descripcion del sensor no puede ser mayor a 45 caracteres") : value;
                }

                
            }
        }
        public string Tipo { get => _tipo;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tipo = value;
                }
                else
                {
                    _tipo = value.Length > 45 ? throw new ArgumentOutOfRangeException("La descripcion del tipo no puede ser mayor a 45 caracteres") : value;
                }

                
            }
        }
        public string Factor { get => _factor;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _factor = value;
                }
                else
                {
                    _factor = value.Length > 10 ? throw new ArgumentOutOfRangeException("La descripcion del factor no puede ser mayor a 10 caracteres") : value;
                }

               
            }
        }
        public string Objetivo { get => _objetivo;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _objetivo = value;
                }
                else
                {
                    _objetivo = value.Length > 15 ? throw new ArgumentOutOfRangeException("La descripcion del objetivo no puede ser mayor a 15 caracteres") : value;
                }
               
            }
        }
        public string Pantalla { get => _pantalla;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _pantalla = value;
                }
                else
                {
                    _pantalla = value.Length > 20 ? throw new ArgumentOutOfRangeException("La descripcion de la pantalla no puede ser mayor a 20 caracteres") : value;
                }

               
            }
        }
        public string Zoom { get => _zoom;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _zoom= value;
                }
                else
                {
                    _zoom = value.Length > 40 ? throw new ArgumentOutOfRangeException("La descripcion del zoom no puede ser mayor a 40 caracteres") : value;
                }

               
            }
        }

        //Constructor sin argumentos
        public Camara()
        {
            _camaraID = "camaraID";
            _resolucion = "resolucion";
            _sensor = "sensor";
            _tipo = "tipo";
            _factor = "factor";
            _objetivo = "objetivo";
            _pantalla = "pantalla";
            _zoom = "zoom";
        }

        //Constructor con argumentos
        public Camara(string camaraID, string resolucion, string sensor, string tipo, string factor, string objetivo, string pantalla, string zoom)
        {
            _camaraID = camaraID;
            _resolucion = resolucion;
            _sensor = sensor;
            _tipo = tipo;
            _factor = factor;
            _objetivo = objetivo;
            _pantalla = pantalla;
            _zoom = zoom;
        }

        //Constructor de copia
        public Camara(Camara otraCamara)
        {
            _camaraID = otraCamara._camaraID;
            _resolucion = otraCamara._resolucion;
            _sensor = otraCamara._sensor;
            _tipo = otraCamara._tipo;
            _factor = otraCamara._factor;
            _objetivo = otraCamara._objetivo;
            _pantalla = otraCamara._pantalla;
            _zoom = otraCamara._zoom;
        }
        //Destructor
        ~Camara()
        {
            _camaraID = "";
            _resolucion = "";
            _sensor = "";
            _tipo = "";
            _factor = "";
            _objetivo = "";
            _pantalla = "";
            _zoom = "";
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CamaraID + "#" + Resolucion + "#" + Sensor + "#" + Tipo + "#" + Factor + "#" + Objetivo + "#" + Pantalla + "#" + Zoom;
        }
    }
}
