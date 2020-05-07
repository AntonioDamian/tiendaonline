using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{
    /// <summary>
    /// Clase provincia
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class Provincia
    {
        //Atributos
        private string _provinciaID;
        private string _nombre;


        //Propiedades
        public string ProvinciaID
        {
            get => _provinciaID;
            set

            {
                if (value.Length > 2)
                {
                    throw new ArgumentOutOfRangeException("ProvinciaID no puede superar los 2 caracteres");
                }
                _provinciaID = value ?? throw new ArgumentNullException("El provinciaID no puede ser nulo");
            }
        }
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("Nombre no puede superar los 25 caracteres");
                }
                _nombre = value ?? throw new ArgumentNullException("El nombre  no puede ser nulo");
            }
        }

        //Constructor sin argumentos
        public Provincia()
        {
            _provinciaID = "provinciaID";
            _nombre = "nombre";
        }
        //Constructor con argumentos
        public Provincia(string provinciaID, string nombre)
        {
            _provinciaID = provinciaID;
            _nombre = nombre;
        }
        //Constructor de copia
        public Provincia(Provincia otraProvincia)
        {
            _provinciaID = otraProvincia._provinciaID;
            _nombre = otraProvincia._nombre;
        }
        //Destructor
        ~Provincia()
        { 
                _provinciaID = "";
                _nombre = "";
            
        }


        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ProvinciaID + "#" + Nombre;
        }
    }
}
