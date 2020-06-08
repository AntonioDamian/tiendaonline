using Capa_datos;
using Capa_Datos;
using Capa_entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;									 
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Capa_negocio
{
    public class Negocio
    {
        private UsuarioADO _dat;

        public Negocio()
        {
            _dat = new UsuarioADO();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _dat.LeerUsuarios();
        }

        public List<Usuario> ObtenerUsuario(int usuarioID) {

            return _dat.LeerUsuario(usuarioID);
        }


        // Valido el login de un usuario
        public bool Validar(string usu, string pas)
        {
            List<Usuario> lista_usuarios = _dat.LeerUsuarios();

            if (lista_usuarios != null)
            {
                for (int i = 0; i < lista_usuarios.Count; i++)
                {
                    if ((lista_usuarios[i].Nombre == usu) &&
                        (lista_usuarios[i].Password == pas))
                        return (true);
                }
            }

            return (false);
        }
        public bool Validar2(string usu, string pass,out Usuario usuario)
        {
            List<Usuario> lista_usuarios = _dat.LeerUsuarios();
            string passMD5 ;
            if (pass.Equals(""))
            {
                passMD5 = null;
            }
            else
            {
                 passMD5 = ConvertirContrasenyaMD5(pass);
            }
            if (lista_usuarios != null)
            {
                List<Usuario> seleccionados = lista_usuarios.Where(x => x.Nombre == usu && x.Password == passMD5).ToList();

                if (seleccionados.Count > 0)
                {
                    usuario = seleccionados[0];
                    return true;
                }
            }
            usuario = new Usuario();
            return (false);
        }

        public string ConvertirContrasenyaMD5(string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] contrasenyaBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] contrasenyaHash = md5.ComputeHash(contrasenyaBytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < contrasenyaHash.Length; i++)
                stringBuilder.Append(contrasenyaHash[i].ToString("x2"));

            return stringBuilder.ToString();
        }

        // Creo un nuevo usuario
        public bool Nuevo( string email, string password, string nombre, string apellidos, string dni, string telefono, string calle, string calle2,
		string codpos, string puebloID, string provinciaID, DateTime nacido)
        {

            return (_dat.InsertarUsuario( email,password, nombre, apellidos, dni, telefono, calle, calle2, codpos, puebloID, provinciaID, nacido));
        }


        public bool Actualizar(Usuario usuario)
        {
          
            return (_dat.ActualizarUsuario(usuario));
        }

        public bool Borrar(int usu)
        {
            return (_dat.BorrarUsuario(usu));
        }
    }
    
}
