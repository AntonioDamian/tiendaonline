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
    public class TipoArticuloADO:ADO
    {
        // Leo todos los TipoArticulos dela BD
        public List<TipoArticulo> LeerTipoTipoArticulos()
        {
            List<TipoArticulo> listaTipoArticulos = new List<TipoArticulo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/TipoArticulos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTipoArticulos = JsonConvert.DeserializeObject<List<TipoArticulo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTipoArticulos;
        }
        public List<TipoArticulo> LeerTipoArticulo(int id)
        {
            List<TipoArticulo> listaTipoArticulos = new List<TipoArticulo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/TipoArticulos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTipoArticulos = JsonConvert.DeserializeObject<List<TipoArticulo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTipoArticulos;
        }
        // Creo un nuevo TipoArticulo en la BD
        public bool InsertarTipoArticulo(int tipoArticuloID, string descripcion)
        {
            try
            {
                TipoArticulo TipoArticulo = new TipoArticulo(tipoArticuloID, descripcion);
               // HttpResponseMessage response = client.PostAsJsonAsync("api/TipoArticulos", TipoArticulo).Result;
                var response = client.PostAsync("api/TipoArticulos", new StringContent(new JavaScriptSerializer().Serialize(TipoArticulo), Encoding.UTF8, "application/json")).Result;
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
        public bool ActualizarTipoArticulo(TipoArticulo TipoArticulo)
        {
            try
            {
              //  HttpResponseMessage response = client.PutAsJsonAsync("api/TipoArticulos/" + TipoArticulo.TipoArticuloID, TipoArticulo).Result;
                var response = client.PutAsync("api/TipoArticulos", new StringContent(new JavaScriptSerializer().Serialize(TipoArticulo), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarTipoArticulo(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/TipoArticulos/" + id).Result;

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
