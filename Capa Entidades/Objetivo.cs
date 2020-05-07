using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{
    /// <summary>
    /// Clase objetivo
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class Objetivo
    {
        //Atributos
        private string _objetivoID;
        private string _tipo;
        private string _montura;
        private string _focal;
        private string _apertura;
        private string _especiales;

        //Propiedades
        public string ObjetivoID { get => _objetivoID;
            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentOutOfRangeException("ObjetivoID no puede superar los 7 caracteres");
                }
                _objetivoID = value ?? throw new ArgumentNullException("ObjetivoID no puede ser nulo");
            }
        }
        public string Tipo { get => _tipo;
            set
            {

                _tipo = value.Length > 15 ? throw new ArgumentNullException("La descripcion del tipo no puede ser mayor a 15 caracteres") : value;
            }
        }
        public string Montura { get => _montura;
            set
            {

                _montura = value.Length > 30 ? throw new ArgumentNullException("Montura no puede ser mayor a 15 caracteres") : value;
            }
        }
        public string Focal { get => _focal;
            set
            {

                _focal = value.Length > 30 ? throw new ArgumentNullException("Focal no puede ser mayor a 30 caracteres") : value;
            }
        }
        public string Apertura { get => _apertura;
            set
            {

                _apertura = value.Length > 10 ? throw new ArgumentNullException("La descripcion del tipo no puede ser mayor a 10 caracteres") : value;
            }
        }
        public string Especiales { get => _especiales;
            set
            {

                _especiales = value.Length > 35 ? throw new ArgumentNullException("La descripcion del tipo no puede ser mayor a 35 caracteres") : value;
            }
        }
        //Constructor sin argumentos
        public Objetivo()
        {
            _objetivoID = "objetivoID";
            _tipo = "tipo";
            _montura = "montura";
            _focal = "focal";
            _apertura = "apertura";
            _especiales = "especiales";
        }

        //Constructor con argumentos
        public Objetivo(string objetivoID, string tipo, string montura, string focal, string apertura, string especiales)
        {
            _objetivoID = objetivoID;
            _tipo = tipo;
            _montura = montura;
            _focal = focal;
            _apertura = apertura;
            _especiales = especiales;
        }


        //Constructor de copia
        public Objetivo(Objetivo otroObjetivo)
        {
            _objetivoID = otroObjetivo._objetivoID;
            _tipo = otroObjetivo._tipo;
            _montura = otroObjetivo._montura;
            _focal = otroObjetivo._focal;
            _apertura = otroObjetivo._apertura;
            _especiales =otroObjetivo._especiales;
        }
        //Destructor
        ~Objetivo()
        {
            _objetivoID = "";
            _tipo = "";
            _montura = "";
            _focal = "";
            _apertura = "";
            _especiales = "";
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ObjetivoID + "#" + Tipo + "#" + Montura + "#" + Focal + "#" + Apertura + "#" + Especiales;
        }
    }
}
