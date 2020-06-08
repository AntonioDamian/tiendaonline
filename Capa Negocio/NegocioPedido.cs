using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_datos;
using Capa_entidades;
using Capa_Datos;
using System.Windows.Forms;

namespace Capa_negocio
{
   public  class NegocioPedido
    {
        private PedidoADO _pedido;

        public NegocioPedido()
        {
            _pedido = new PedidoADO();
        }

        public List<Pedido> ObtenerPedido()
        {
            return _pedido.LeerPedidos();
        }

        public List<Pedido> ObtenerPedidos(int pedidoID)
        {

            return _pedido.LeerPedido(pedidoID);
        }


        public bool NuevoPedido(int pedidoID, int usuarioID, DateTime fecha, List<Linped> linpeds)
        {
            return _pedido.InsertarPedido(pedidoID,usuarioID,fecha,linpeds);
        }

        public decimal [] Datosfactura(Pedido pedido,decimal iva )
        {
            decimal[] valores = new decimal[3];
            decimal total ;
            decimal totalConIva;
            decimal totalIva;
           // decimal iva = iva;
          
           /* foreach (DataGridViewRow fila in datos.Rows)
            {
                total += Convert.ToDouble(fila.Cells[4].Value);
                totalIva += total * iva / 100;
                totalConIva += Convert.ToDouble((totalIva)+total);

            }
            */
            


            total =Convert.ToDecimal( pedido.ImporteTotal);
            totalIva = (total * iva) / 100;
            totalConIva = total + totalIva;

            valores[0] = total;
            valores[1] = totalIva;
            valores[2] = totalConIva;


            return valores;



          
        } 
    }
}
