using System;
using System.Collections.Generic;


// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_entidades;

namespace Capa_Datos
{
    public class LocalidadADO:ADO
    {
        // Leo todos los articulos dela BD
        public List<Localidad> LeerLocalidades()
        {
            List<Localidad> listaLocalidades = new List<Localidad>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/localidades").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaLocalidades = JsonConvert.DeserializeObject<List<Localidad>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaLocalidades;
        }
        public List<Localidad> LeerLocalidad(int id)
        {
            List<Localidad> listaLocalidades = new List<Localidad>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/localidades/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaLocalidades = JsonConvert.DeserializeObject<List<Localidad>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaLocalidades;
        }
        // Creo un nuevo articulo en la BD
        public bool InsertarLocalidad(string localidadID, string Nombre, string provinciaID)
        {
            try
            {
                Localidad localidad = new Localidad(localidadID, Nombre,provinciaID);

                HttpResponseMessage response = client.PostAsJsonAsync("api/localidades", localidad).Result;
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
        public bool ActualizarLocalidad(Localidad localidad)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/localidades/" + localidad.LocalidadID,localidad).Result;

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

        public bool BorrarLocalidad(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/localidades/" + id).Result;

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
