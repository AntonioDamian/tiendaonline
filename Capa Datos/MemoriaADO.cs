using System;
using System.Collections.Generic;


// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_entidades;
using System.Web.Script.Serialization;
using System.Text;

namespace Capa_Datos
{
    public class MemoriaADO:ADO
    {
        // Leo todos las Memorias dela BD
        public List<Memoria> LeerMemorias()
        {
            List<Memoria> listaMemorias = new List<Memoria>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Memorias").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaMemorias = JsonConvert.DeserializeObject<List<Memoria>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaMemorias;
        }
        public List<Memoria> LeerMemoria(string id)
        {
             List<Memoria> listaMemorias = new List<Memoria>();
            Memoria memo = new Memoria();
          
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Memorias/"+ id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    // listaMemorias = JsonConvert.DeserializeObject<List<Memoria>>(aux);
                    memo = JsonConvert.DeserializeObject<Memoria>(aux);
                    listaMemorias.Add(memo);
                } 
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaMemorias;
        }
        // Creo una nueva Memoria en la BD
        public bool InsertarMemoria(string memoriaID, string tipo)
        {
            try
            {
                Memoria Memoria = new Memoria(memoriaID,tipo);

               // HttpResponseMessage response = client.PostAsJsonAsync("api/Memorias", Memoria).Result;
                var response = client.PostAsync("api/Memorias", new StringContent(new JavaScriptSerializer().Serialize(Memoria), Encoding.UTF8, "application/json")).Result;
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
        public bool ActualizarMemoria(Memoria Memoria)
        {
            try
            {
               // HttpResponseMessage response = client.PutAsJsonAsync("api/Memorias/" + Memoria.MemoriaID, Memoria).Result;
                var response = client.PutAsync("api/Memorias", new StringContent(new JavaScriptSerializer().Serialize(Memoria.MemoriaID), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarMemoria(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/Memorias/" + id).Result;

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
