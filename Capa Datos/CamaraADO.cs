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
    public class CamaraADO:ADO
    {

        // Leo todas las camaras dela BD
        public List<Camara> LeerCamaras()
        {
            List<Camara> listaCamaras = new List<Camara>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/camaras").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaCamaras = JsonConvert.DeserializeObject<List<Camara>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaCamaras;
        }
        public List<Camara> LeerCamara(string id)
        {
            List<Camara> listaCamaras = new List<Camara>();
            Camara camara = new Camara();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/camaras/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                   //  listaCamaras = JsonConvert.DeserializeObject<List<Camara>>(aux);
                    camara = JsonConvert.DeserializeObject<Camara>(aux);
                    listaCamaras.Add(camara);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaCamaras;
        }
        // Creo una nueva camara en la BD
        public bool InsertarCamara(string camaraID, string resolucion, string sensor, string tipo, string factor, string objetivo, string pantalla, string zoom)

        {
            try
            {
                Camara camara = new Camara(camaraID, resolucion, sensor, tipo, factor, objetivo, pantalla, zoom);
       

               // HttpResponseMessage response = client.PostAsJsonAsync("api/camaras", camara).Result;
                var response = client.PostAsync("api/camaras", new StringContent(new JavaScriptSerializer().Serialize(camara), Encoding.UTF8, "application/json")).Result;
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
        public bool ActualizarCamara(Camara camara)
        {
            try
            {
              //HttpResponseMessage response = client.PutAsJsonAsync("api/camaras/" +camara.CamaraID,camara).Result;
                var response = client.PutAsync("api/camaras", new StringContent(new JavaScriptSerializer().Serialize(camara), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarCamara(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/camaras/" + id).Result;

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
