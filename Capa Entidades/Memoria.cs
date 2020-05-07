using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{
    /// <summary>
    /// Clase memoria
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class Memoria
    {
        //Atributos
        private string _memoriaID;
        private string _tipo;

        public string MemoriaID { get => _memoriaID; set => _memoriaID = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }

        //Propiedades
        /*    public string MemoriaID { get => _memoriaID; set
                {
                    if (value.Length > 7)
                    {
                        throw new ArgumentOutOfRangeException("MemoriaID no puede superar los 7 caracteres");
                    }
                    _memoriaID = value ?? throw new ArgumentNullException("MemoriaID no puede ser nulo");
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
                        _tipo = value.Length > 30 ? throw new ArgumentNullException("La descripcion del tipo no puede ser mayor a 30 caracteres") : value;
                    }


                }
            }*/
        //Constructor sin argumentos
        public Memoria()
        {
            _memoriaID ="memoriaID";
            _tipo = "tipo";
        }

        //Constructor con argumentos
        public Memoria(string memoriaID, string tipo)
        {
            _memoriaID = memoriaID;
            _tipo = tipo;
        }

        //Constructor copia
        public Memoria(Memoria otraMemoria)
        {
            _memoriaID =otraMemoria._memoriaID;
            _tipo = otraMemoria._tipo;
        }
        //Destructor
        ~Memoria()
        {
            _memoriaID = "";
            _tipo = "";
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MemoriaID + "#" + Tipo + "#";
        }
    }
}
