using System;
using System.Collections.Generic;
using Capa_entidades;
/// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Capa_Datos;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Capa_datos

    {/// <summary>
    /// Clase  con los metodos que utilizaremos para contactar con la web Api y la base de datos,refrente a los usuarios registrados en la base de dstos
    /// </summary>
    public class UsuarioADO : ADO
    {

        // Leo todos los usuarios dela BD
        /// <summary>
        /// Método que nos devuelve una lista con la informacion  completa de los usuarios cuando realizamos una consulta a la base de datos 
        /// <remarks>Vea<see cref="List{T}"/>para mas detalles del objeto devuelto</remarks>
        /// </summary>
        /// <remarks>
        /// <example>
        /// Ejemplo de obtencion de todos los usuarios de la base de datos
        /// </example>
        /// <code>    
        ///       UsuarioADO usuADO=new UsuarioADO();
        ///       List<Usuario>listaUsuarios=new List</Usuario>();
        ///       listaUsuarios=usuADO.LeerUsuarios();
        /// </code>
        /// </remarks>
        /// <returns>lista con la informacion de todos los usuarios registrados en la base de datos</returns>
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

        /// <summary>
        /// <remarks>Método que nos devuelve una lista con la información de los usuarios que coinciden con la búsqueda realizada</remarks>
        /// <remarks>Vea<see cref="List{T}"/>para mas detalles del objeto devuelto</remarks>
        /// </summary>
        /// <param name="id">Entero que representa el id del usuario a buscar </param>
        /// <remarks>
        /// <example>
        /// Ejemplo de obtencion de todos los usuarios de la base de datos,que coincidan con el id de usuario buscado
        /// </example>
        /// <code>          
        ///       UsuarioADO usuADO=new UsuarioADO();
        ///       List<Usuario>listaUsuarios=new List</Usuario>();
        ///       int usuarioID=2;
        ///       listausuarios=usuaADO.LeerUsuario(2);
        /// </code> 
        /// </remarks>
       /// <returns>lista con todos los usuarios que cumplen con la condicion</returns>
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
        /// <summary>
        /// <para>Metodo que valida la inserccion de un nuevo usuario en la base de datos</para>
        /// </summary>      
        /// <param name="email">  cadena que representa el email del usuario</param>
        /// <param name="password">  cadena que representa el password del usuario</param>
        /// <param name="nombre">  cadena que representa el nombre del usuario</param>
        /// <param name="apellidos">  cadena que representa el apellidos del usuario</param>
        /// <param name="dni">  cadena que representa el dni del usuario</param>
        /// <param name="telefono">  cadena que representa el teléfono del usuario</param>
        /// <param name="calle">  cadena que representa el calle del usuario</param>
        /// <param name="calle2"> cadena que representa el calle2 del usuario</param>
        /// <param name="codpos">  cadena que representa el código postal del usuario</param>
        /// <param name="puebloID">  cadena que representa el id del piueblo del usuario</param>
        /// <param name="provinciaID">  cadena que representa el id de la provincia del usuario</param>
        /// <param name="nacido">fecha que representa la fecha de nacimiento del usuario</param>
        /// <remarks> Inserccion de un usuario por sus campos
        /// <example> Ejemplo de utilizacion del metodo insertar un Usuario en la base de datos
        /// </example>
        /// <code>
        ///  
        ///    UsuarioADO usuADO=new UsuarioADO();
        ///    bool insertado=false;           
        ///     insertado=usuADO.InsertarUsuario((0,ada@da.es,1234,Juan,Cremades,25365419B,961483799,Piles-Infanzon, Del,Carretera, 7, 1 A,null,46055,2331,46,10-05-1980);
        /// 
        /// </code>
        /// </remarks>        
        /// <returns>Nos devuelve true si la insercción ha sido correcta y false si no lo ha sido</returns>        
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

        /// <summary>
        /// <para>Metodo que actualizara el usuario en la base de datos</para>
        /// </summary>
        /// <param name="usuario"> Usuario que vamos a actualizar</param>
        /// <remarks>Actualiza el usuario <paramref name="usuario"/>
        /// <para>Utilizamos el id que obtendremos del usuario que tenemos como parametro,para actualizar el usuario que coincida con el id de la base de datos</para>
        /// </remarks>
        /// <returns>Nos devuelve true si la actualización ha sido correcta y false si no lo ha sido</returns>
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
        /// <summary>
        /// <para>Metodo que nos permite borrar toda la informacion de un usuario de la base de datos</para>
        /// </summary>
        /// <remarks>Borra el Usuario con el parametro de referencia <paramref name="id"/>
        /// <para> Utilizamos el id del usuario del  parametro para eliminar el usuario que coincida con el id de la base de datos</para></remarks>
        /// <param name="id"> campo que reprenta el id del usuario a eliminar</param>
        /// <returns>Nos devuelve true si la eliminacion ha sido correcta y false si no lo ha sido</returns>
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
      




    }
}
