
using System;
using Capa_datos;
using Capa_entidades;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Capa_negocio
{

   
    public class NegocioUsuario
    {
      

        private UsuarioADO _dat;

        public NegocioUsuario()
        {
            _dat = new UsuarioADO();
        }

        public  void CrearUsuarioCliente()
        {
            string nombre = "cliente";
            string passMD5 = ConvertirContrasenyaMD5("1234");

            List<Usuario> lista_usuarios = _dat.LeerUsuarios();

            if (lista_usuarios != null)
            {
                bool existe = lista_usuarios.Any(x => x.Nombre == nombre && x.Password == passMD5);

                if (!existe)
                {


                    string email = "default@default.es";
                    string password = passMD5;
                    string apellidos = "default";
                    string dni = "22136993E";
                    string telefono = "999999999";
                    string calle = "";
                    string calle2 = "";
                    string codpos = "00000";
                    string puebloID = "0149";
                    string provinciaID = "03";
                    DateTime? nacido = null;

                    if (_dat.InsertarUsuario(email, password, nombre, apellidos, dni, telefono, calle, calle2, codpos, puebloID, provinciaID, nacido))
                    {

                        Console.WriteLine("Se ha introducido el usuario cliente en BBDD.");
                    }
                    else
                    {
                        Console.WriteLine("No Se ha introducido el usuario cliente en BBDD.");
                    }
                }
                else
                {
                    Console.WriteLine("El usuario cliente ya existe en la Base de Datos");
                }

            }



           
        }

        public static  string ConvertirContrasenyaMD5(string contrasenya)
        {
            MD5 md5 = MD5.Create();
            byte[] contrasenyaBytes = System.Text.Encoding.ASCII.GetBytes(contrasenya);
            byte[] contrasenyaHash = md5.ComputeHash(contrasenyaBytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < contrasenyaHash.Length; i++)
                stringBuilder.Append(contrasenyaHash[i].ToString("x2"));

            return stringBuilder.ToString();
        }
    }
}
