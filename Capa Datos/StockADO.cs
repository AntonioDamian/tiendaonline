using System;
using System.Collections.Generic;


// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using CapaEntidades;
using System.Web.Script.Serialization;
using System.Text;

namespace CapaDatos
{
   public class StockADO:ADO
    {
        // Leo todos los Stocks dela BD
        public List<Stock> LeerStocks()
        {
            List<Stock> listaStocks = new List<Stock>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/stocks").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaStocks = JsonConvert.DeserializeObject<List<Stock>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaStocks;
        }
     /*   public List<Stock> LeerStock(string id)
        {
            List<Stock> listaStocks = new List<Stock>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Stock/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaStocks = JsonConvert.DeserializeObject<List<Stock>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaStocks;
        }*/
		
		  public Stock LeerStock(string id)
        {
            List<Stock> listaStocks = new List<Stock>();
            Stock stc = new Stock();

            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/stock/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    stc = JsonConvert.DeserializeObject<Stock>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return stc;
        }
        // Creo un nuevo Stock en la BD
        public bool InsertarStock(string articuloID, int disponible,Entrega entrega)
        {
            try
            {
                Stock Stock = new Stock(articuloID,disponible,entrega);

               // HttpResponseMessage response = client.PostAsJsonAsync("api/Stock", Stock).Result;
                var response = client.PostAsync("api/Stocks", new StringContent(new JavaScriptSerializer().Serialize(Stock), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }

            return true;
        }
        public bool ActualizarStock(Stock Stock)
        {
            try
            {
              //  HttpResponseMessage response = client.PutAsJsonAsync("api/Stock/" + Stock.ArticuloID, Stock).Result;
                var response = client.PutAsync("api/Stock", new StringContent(new JavaScriptSerializer().Serialize(Stock), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }

        public bool BorrarStock(string id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/stock/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }


    }
}
