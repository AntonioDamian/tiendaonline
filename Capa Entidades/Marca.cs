using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    /// <summary>
    /// Clase marca
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class Marca
    {
        //Atributos
        private string _marcaID;
        private string _empresa;
        private byte[] _logo;

        //Propiedades
        public string MarcaID { get => _marcaID;
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException("MarcaID no puede superar los 4 caracteres");
                }
                _marcaID = value ?? throw new ArgumentNullException("MarcaID no puede ser nulo");
            }
        }
        public string Empresa { get => _empresa;
            set
            {
                if (value.Length > 60)
                {
                    throw new ArgumentOutOfRangeException("La empresa no puede superar los 60 caracteres");
                }
                _empresa = value ?? throw new ArgumentNullException("LocalidadID no puede ser nulo");
            }
        }
        public byte[] Logo { get => _logo; set => _logo = value; }

        //Costructor sin argumentos
        public Marca()
        {
            _marcaID = "marcaID";
            _empresa = "empresa";
            _logo =null;
        }

        //Cosntructor con argumentos
        public Marca(string marcaID, string empresa, byte[] logo)
        {
            _marcaID = marcaID;
            _empresa = empresa;
            _logo = logo;
        }
        //Constructor de copia
        public Marca(Marca otraMarca)
        {
            _marcaID = otraMarca._marcaID;
            _empresa = otraMarca._empresa;
            _logo = otraMarca._logo;
        }

        //Destructor
        ~Marca()
        {
            _marcaID = "";
            _empresa = "";
            _logo =null;
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MarcaID+"#"+Empresa+"#"+Logo;
        }
    }
}
