 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{

    /// <summary>
    /// Clase articulo
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>
    public class Linped
    {
        //Atributos
        private int _pedidoID;
        private int _linea;
        private string _articuloID;
        private decimal _importe;
        private int? _cantidad;

        //Propiedades
        public int PedidoID
        {
            get => _pedidoID;
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException("El pedidoID no puede ser nulo");
                }

                _pedidoID = value.ToString().Length > 11 ? throw new ArgumentOutOfRangeException("El pedidoID no puede superar los 11 caracteres") : value;
            }
        }


        public int Linea
        {
            get => _linea;
            set
            {
                if (value.Equals(null)) 
                {
                    throw new ArgumentNullException("La linea no puede ser nulo");
                }

                _linea = value > 11 ? throw new ArgumentOutOfRangeException("La linea no puede superar los 11 caracteres") : value;
            }
        }
        public string ArticuloID
        {
            get => _articuloID;
            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentOutOfRangeException("ArticuloID no puede superar los 7 caracteres");
                }
                _articuloID = value ?? throw new ArgumentNullException("ArticuloID no puede ser nulo");
            }
        }
        public decimal Importe
        {
            get => _importe;
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException("El importe no puede ser nulo");
                }

                _importe = value.ToString().Length > 9 ? throw new ArgumentOutOfRangeException("El importe no puede superar los 9 caracteres") : value;
            }
        }
        public int? Cantidad
        {
            get => _cantidad;
            set
            {
                _cantidad = value.ToString().Length > 11 ? throw new ArgumentOutOfRangeException("La cantidad no puede ser mayor a 11 caracteres") : value;
            } 

        }

        //Constructor sin argumentos
        public Linped()
        {
            _pedidoID = 0;
            _linea = 0;
            _articuloID = "articuloID";
            _importe = 0.0M;
            _cantidad = 0;
        }
        //Cosnstructor con argumentos
        public Linped(int pedidoID, int linea, string articuloID, decimal importe, int cantidad)
        {
            _pedidoID = pedidoID;
            _linea = linea;
            _articuloID = articuloID;
            _importe = importe;
            _cantidad = cantidad;
        }
        //Constructor de copia
        public Linped(Linped otroLinped)
        {
            _pedidoID = otroLinped._pedidoID;
            _linea = otroLinped._linea;
            _articuloID = otroLinped._articuloID;
            _importe = otroLinped._importe;
            _cantidad = otroLinped._cantidad;
        }

        //Destructor
        ~Linped()
        {
            _pedidoID = 0;
            _linea = 0;
            _articuloID = "articuloID";
            _importe = 0.0M;
            _cantidad = 0;
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return PedidoID + "#" + Linea + "#" + ArticuloID + "#" + Importe + "#" + Cantidad;
        }

      
    }
}
