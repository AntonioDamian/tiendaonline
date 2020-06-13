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
    public class TvADO:ADO
    {
        // Leo todos las tv dela BD
        public List<Tv> LeerTvs()
        {
            List<Tv> listaTvs = new List<Tv>();
            string aux;

            try
            {
               HttpResponseMessage response = client.GetAsync("api/Tv").Result;
             
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTvs = JsonConvert.DeserializeObject<List<Tv>>(aux);
                   
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTvs;
        }
        public List<Tv> Leertv(string id)
        {
            List<Tv> listaTvs = new List<Tv>();
            Tv tv = new Tv();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Tv/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                  // listaTvs = JsonConvert.DeserializeObject<List<Tv>>(aux);
                    tv= JsonConvert.DeserializeObject<Tv>(aux);
                    listaTvs.Add(tv);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTvs;
        }
        // Creo un nuevo articulo en la BD
        public bool InsertarTv(string tvID, string panel, short pantalla, string resolucion, string hdreadyfullhd, bool? tdt)
        {
            try
            {
                Tv tv = new Tv(tvID,panel,pantalla,resolucion,hdreadyfullhd,tdt);
               // HttpResponseMessage response = client.PostAsJsonAsync("api/tv", tv).Result;
                var response = client.PostAsync("api/tv", new StringContent(new JavaScriptSerializer().Serialize(tv), Encoding.UTF8, "application/json")).Result;
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
        public bool ActualizarTv(Tv tv)
        {
            try
            {
                //HttpResponseMessage response = client.PutAsJsonAsync("api/tv/" + tv.TvID,tv).Result;
                var response = client.PutAsync("api/tv", new StringContent(new JavaScriptSerializer().Serialize(tv.TvID), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarTv(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/tv/" + id).Result;

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
