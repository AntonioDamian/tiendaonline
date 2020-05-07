using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_datos;
using Capa_Datos;
using Capa_entidades;
    

namespace Capa_negocio
{
   public class NegocioStock
    {

        private StockADO _stockADO;

        public NegocioStock()
        {
            _stockADO = new StockADO();
        }

        public List<Stock> ObtenerStocks()
        {
            return _stockADO.LeerStocks();
        }

        public Stock ObtenerStock(string stockId)
        {

            return _stockADO.LeerStock(stockId);
        }

        public bool Nuevo(string articuloID,int disponible,Entrega entrega)
        {

            return (_stockADO.InsertarStock(articuloID,disponible,entrega));
        }


        public bool Actualizar(Stock stock)
        {

            return (_stockADO.ActualizarStock(stock));
        }

        public bool Borrar(string stc)
        {
            return (_stockADO.BorrarStock(stc));
        }
    }
}
