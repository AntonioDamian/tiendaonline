using System;
using System.Collections.Generic;


// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_entidades;

namespace Capa_Datos
{
   public class LinpedADO:ADO
    {

        // Leo todos los linped dela BD
        public List<Linped> LeerLinped()
        {
            List<Linped> linpeds = new List<Linped>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/linpeds").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    linpeds = JsonConvert.DeserializeObject<List<Linped>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return linpeds;
        }
        public List<Linped> LeerLinped(int id)
        {
            List<Linped> listaLinpeds = new List<Linped>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/linpeds/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaLinpeds = JsonConvert.DeserializeObject<List<Linped>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaLinpeds;
        }
        // Creo un nuevo linbped en la BD
        public bool InsertarLinped(int pedidoID, int linea, string articuloID, decimal importe, int cantidad)
        {
            try
            {
                Linped linped = new Linped(pedidoID,linea,articuloID,importe,cantidad);

                HttpResponseMessage response = client.PostAsJsonAsync("api/linpeds",linped).Result;              
                
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
        public bool ActualizarLinped(Linped linped)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/linpeds/" + linped.PedidoID,linped).Result;

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

        public bool BorrarLinped(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/linpeds/" + id).Result;

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
