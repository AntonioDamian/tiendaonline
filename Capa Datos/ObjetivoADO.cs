using System;
using System.Collections.Generic;


// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_entidades;

namespace Capa_Datos
{
    public class ObjetivoADO:ADO
    {
        // Leo todos los onjetivos dela BD
        public List<Objetivo> LeerObjetivos()
        {
            List<Objetivo> listaOnjetivos = new List<Objetivo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Onjetivos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaOnjetivos = JsonConvert.DeserializeObject<List<Objetivo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaOnjetivos;
        }
        public List<Objetivo> LeerObjetivo(string id)
        {
            List<Objetivo> listaObjetivos = new List<Objetivo>();
            Objetivo objetivo = new Objetivo();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Objetivos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    // listaObjetivos = JsonConvert.DeserializeObject<List<Objetivo>>(aux);
                    objetivo = JsonConvert.DeserializeObject<Objetivo>(aux);
                    listaObjetivos.Add(objetivo);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaObjetivos;
        }
        // Creo un nuevo Objetivo en la BD
        public bool InsertarObjetivo(string objetivoID, string tipo, string montura, string focal, string apertura, string especiales)
        {
            try
            {
                Objetivo Objetivo = new Objetivo(objetivoID, tipo, montura, focal, apertura, especiales);
                HttpResponseMessage response = client.PostAsJsonAsync("api/Objetivos", Objetivo).Result;
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
        public bool ActualizarObjetivo(Objetivo Objetivo)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/Objetivos/" + Objetivo.ObjetivoID, Objetivo).Result;

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

        public bool BorrarObjetivo(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/Objetivos/" + id).Result;

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
