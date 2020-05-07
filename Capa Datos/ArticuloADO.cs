using System;
using System.Collections.Generic;


// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_entidades;

namespace Capa_Datos
{
    public class ArticuloADO:ADO
    {
        // Leo todos los articulos dela BD
        public List<Articulo> LeerArticulos()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/articulos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaArticulos = JsonConvert.DeserializeObject<List<Articulo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaArticulos;
        }
        public List<Articulo> LeerArticulo(int id)
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/articulos/"+ id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaArticulos = JsonConvert.DeserializeObject<List<Articulo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaArticulos;
        }
        // Creo un nuevo articulo en la BD
        public bool InsertarArticulo(string articuloI, string nombre, decimal pvp, string marcaID, byte[] imagen, string urlimagen, string especificaciones, int tipoArticuloID)

        {
            try
            {
                Articulo articulo = new Articulo(articuloI, nombre, pvp, marcaID, imagen, urlimagen, especificaciones, tipoArticuloID);

                HttpResponseMessage response = client.PostAsJsonAsync("api/articulos", articulo).Result;
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
        public bool ActualizarArticulo(Articulo articulo)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/articulos/" + articulo.ArticuloID, articulo).Result;

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

        public bool BorrarArticulo(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/articulos/" + id).Result;

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
