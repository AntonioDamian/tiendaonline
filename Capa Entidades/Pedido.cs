using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{

    /// <summary>
    /// Clase pedido
    /// </summary>
    /// <Author>Antº Damian Galvañ Candela</Author>
    public class Pedido
    {
        //Atributos
        private int _pedidoID;
        private int _usuarioID = default(int);
        private DateTime _fecha;

        //Propiedades


     
        public int PedidoID
        {
            get => _pedidoID;
         
            set
            {
                if (value.ToString().Length > 11)
                {
                    throw new ArgumentOutOfRangeException("PedidoID no puede superar los 11 caracteres");
                }
                else if (value.Equals(null))
                {
                    throw new ArgumentNullException("El PedidoID no puede ser nulo");
                }
                else
                {
                    _pedidoID = value;
                }
            }
        }
        public int UsuarioID
        {
            get => _usuarioID;

            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException("El usuarioID no puede ser nulo");
                }
                else if(value.ToString().Length>11)
                {
                    throw new ArgumentOutOfRangeException("El usuarioID no puede superar los 11 caracteres");
                }
                else
                {
                    _usuarioID = value;
                }
               



            }

        }
        public DateTime Fecha { get; set; }
        public List<Linped> Linpeds { get; set; }


        public void AddLinped(Linped linped)
        {
            Linpeds.Add(linped);
        }

        public decimal ImporteTotal
        {
            get
            {
                decimal imp = 0.0M;
                for (int i = 0; i < Linpeds.Count; i++)
                {
                    imp += Linpeds[i].Importe * (decimal)Linpeds[i].Cantidad;

                }
                return imp;
            }

        }


        //Constructor  sin argumentos
        public Pedido()
        {
            _pedidoID = 0;
            _usuarioID = 0;
            _fecha = DateTime.Now;
            Linpeds = new List<Linped>();
           

        }

        //Constructor con argumentos


        public Pedido(int pedidoID, int usuarioID, DateTime fecha)
        {
            _pedidoID = pedidoID;
            _usuarioID = usuarioID;
            _fecha = fecha;
        }
        public Pedido(int pedidoID, int usuarioID, DateTime fecha, List<Linped> linpeds)
        {
            _pedidoID = pedidoID;
            _usuarioID = usuarioID;
            _fecha = fecha;
            this.Linpeds = linpeds;
        }

        //Constructor de copia
        public Pedido(Pedido otroPedido)
        {
            _pedidoID = otroPedido._pedidoID;
            _usuarioID = otroPedido._usuarioID;
            _fecha = otroPedido._fecha;
            Linpeds = otroPedido.Linpeds;
        }




        //Destructor
        ~Pedido()
        {
            _pedidoID = 0;
            _usuarioID = 0;
            _fecha = DateTime.MinValue;
            Linpeds = null;

           
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in Linpeds)
            {
                strBuilder.AppendLine(item.ToString());
            }


            return PedidoID + "#" + UsuarioID + "#" + Fecha;
        }


      
    }
}
