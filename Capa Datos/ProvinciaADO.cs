using System;
using System.Collections.Generic;


// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_entidades;

namespace Capa_Datos
{
  public class ProvinciaADO:ADO
    {
        // Leo todos los Provincias dela BD
        public List<Provincia> LeerProvincias()
        {
            List<Provincia> listaProvincias = new List<Provincia>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Provincias").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaProvincias = JsonConvert.DeserializeObject<List<Provincia>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaProvincias;
        }
        public List<Provincia> LeerProvincia(int id)
        {
            List<Provincia> listaProvincias = new List<Provincia>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Provincias/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaProvincias = JsonConvert.DeserializeObject<List<Provincia>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaProvincias;
        }
        // Creo un nuevo Provincia en la BD
        public bool InsertarProvincia(string provinciaID, string nombre)
        {
            try
            {
                Provincia Provincia = new Provincia(provinciaID,nombre);
                HttpResponseMessage response = client.PostAsJsonAsync("api/Provincias", Provincia).Result;
                //var response = client.PostAsync("api/usuarios", new StringContent(new JavaScriptSerializer().Serialize(usu), Encoding.UTF8, "application/json")).Result;
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
        public bool ActualizarProvincia(Provincia Provincia)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/Provincias/" + Provincia.ProvinciaID, Provincia).Result;

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

        public bool BorrarProvincia(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/Provincias/" + id).Result;

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
