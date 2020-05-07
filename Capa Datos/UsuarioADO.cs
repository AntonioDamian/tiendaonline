using System;
using System.Collections.Generic;
using Capa_entidades;

// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_Datos;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Capa_datos
{
    public class UsuarioADO : ADO
    {

        // Leo todos los usuarios dela BD
        public List<Usuario> LeerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/usuarios").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            } 

            return listaUsuarios;
        }
        public List<Usuario> LeerUsuario(int id)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/usuarios/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaUsuarios;
        }
        // Creo un nuevo usuario en la BD
        public bool InsertarUsuario( string email, string password, string nombre, string apellidos, string dni, string telefono,
            string calle, string calle2, string codpos, string puebloID, string provinciaID, DateTime? nacido)
        {
            try
            {
                Usuario usu = new Usuario(0,email,password,nombre,apellidos,dni,telefono,calle,calle2,codpos,puebloID,provinciaID,nacido);

                HttpResponseMessage response = client.PostAsJsonAsync("api/usuarios",usu).Result;

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
        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/usuarios/"+usuario.UsuarioID, usuario).Result;

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

        public bool BorrarUsuario(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/usuarios/"+id).Result;

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

     


        public List<Usuario> LoginUsuario(string usuario, string pass)
        {

            List<Usuario> listaUsuarios = new List<Usuario>();
            string aux;

            try
            {
               
                HttpResponseMessage response = client.GetAsync("api/usuarios/" + usuario).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                }


            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaUsuarios;
        }




    }
}
