using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{

    /// <summary>
    /// Clase localidad
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class Localidad
    {
        //Atributos
        private string _localidadID;
        private string _Nombre;
        private string _provinciaID;

        //Propiedades
        public string LocalidadID { get => _localidadID;
            set
            {
                if (value.Length > 4)
                {
                    throw new ArgumentOutOfRangeException("LocalidadID no puede superar los 4 caracteres");
                }
                _localidadID = value ?? throw new ArgumentNullException("LocalidadID no puede ser nulo");
            }
        }
        public string Nombre { get => _Nombre;
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Nombre no puede superar los 50 caracteres");
                }
                _Nombre = value ?? throw new ArgumentNullException("El nombre no puede ser nulo");
            }
        }
        public string ProvinciaID { get => _provinciaID;
            set
            {
                if (value.Length > 2)
                {
                    throw new ArgumentOutOfRangeException("ProvinciaID no puede superar los 2 caracteres");
                }
                _provinciaID = value ?? throw new ArgumentNullException("ProvinciaID no puede ser nulo");
            }
        }
        
        //Constructor sin argumentos
        public Localidad()
        {
            _localidadID = "localidadID";
            _Nombre = "Nombre";
            _provinciaID = "provinciaID";
        }

        //Constructor con argumentos
        public Localidad(string localidadID, string Nombre, string provinciaID)
        {
            _localidadID = localidadID;
            _Nombre = Nombre;
            _provinciaID = provinciaID;
        }

        //Constructor de copia
        public Localidad(Localidad otraLocalidad)
        {
            _localidadID = otraLocalidad._localidadID;
            _Nombre = otraLocalidad._Nombre;
            _provinciaID = otraLocalidad._provinciaID;
        }

        //Destructor
        ~Localidad()
        {
            _localidadID = "";
            _Nombre = "";
            _provinciaID = "";
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return LocalidadID + "#" + Nombre + "#" + ProvinciaID;
        }
    }
}
