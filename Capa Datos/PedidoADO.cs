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
    public class PedidoADO:ADO
    {
        // Leo todos los Pedidos dela BD
        public List<Pedido> LeerPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Pedidos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaPedidos = JsonConvert.DeserializeObject<List<Pedido>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaPedidos;
        }
        public List<Pedido> LeerPedido(int id)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/Pedidos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaPedidos = JsonConvert.DeserializeObject<List<Pedido>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaPedidos;
        }
        // Creo un nuevo Pedido en la BD
        public bool InsertarPedido(int pedidoID, int usuarioID, DateTime fecha, List<Linped> linpeds)
        {
            try
            {
                Pedido Pedido = new Pedido(pedidoID,usuarioID,fecha,linpeds);

               // HttpResponseMessage response = client.PostAsJsonAsync("api/Pedidos", Pedido).Result;
                var response = client.PostAsync("api/Pedidoss", new StringContent(new JavaScriptSerializer().Serialize(Pedido), Encoding.UTF8, "application/json")).Result;
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
        public bool ActualizarPedido(Pedido Pedido)
        {
            try
            {
               // HttpResponseMessage response = client.PutAsJsonAsync("api/Pedidos/" + Pedido.PedidoID, Pedido).Result;
                var response = client.PutAsync("api/Pedidos", new StringContent(new JavaScriptSerializer().Serialize(Pedido.PedidoID), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarPedido(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/Pedidos/" + id).Result;

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
