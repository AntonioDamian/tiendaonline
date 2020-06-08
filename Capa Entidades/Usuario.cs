using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_entidades
{

    /// <summary>
    /// Clase usuario
    /// </summary>
    /// <Author>Antº Damian Galvañ Candela</Author>
    public class Usuario :IComparable<Usuario>
    {
        //Atributos
        private int _usuarioID;
        private string _email;
        private string _password;
        private string _nombre;
        private string _apellidos;
        private string _dni;
        private string _telefono;
        private string _calle;
        private string _calle2;
        private string _codpos;
        private string _puebloID;
        private string _provinciaID;
        private DateTime? _nacido;
		string _repepas;				

        //Peopiedades

        /*    public string Email { get => _email;
                set
                {
                    if (value.Length > 50)
                    {
                        throw new ArgumentOutOfRangeException("Email no puede superar los 50 caracteres");
                    }
                    _email = value ?? throw new ArgumentNullException("EmailID no puede ser nulo");
                }
            }


            public string Nombre { get => _nombre; set
                {
                    if (value.Length > 35)
                    {
                        throw new ArgumentOutOfRangeException("Nombre no puede superar los 35 caracteres");
                    }
                    _nombre = value ?? throw new ArgumentNullException("Nombre no puede ser nulo");
                }
            }
            public string Apellidos { get => _apellidos;
                set
                {
                    if (value.Length > 35)
                    {
                        throw new ArgumentOutOfRangeException("Apellidos no puede superar los 35 caracteres");
                    }
                    _apellidos = value ?? throw new ArgumentNullException("Apellidos no puede ser nulo");
                }
            }
            public string Dni { get => _dni; set
                {
                    if (value.Length > 12)
                    {
                        throw new ArgumentOutOfRangeException("Dni no puede superar los 12 caracteres");
                    }
                    _dni = value ?? throw new ArgumentNullException("Dni no puede ser nulo");
                }
            }

            public string Codpos { get => _codpos;
                set
                { 
                        if(string.IsNullOrEmpty(value))
                    {
                        _codpos = value;
                    }

                   else  if (value.Length < 5 && !string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentOutOfRangeException("Codpos no puede ser inferior a los 5 caracteres");
                    }
                    else
                    {
                        _codpos = value;
                    }

                }
            }*/
        public int UsuarioID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get;set; }       
        public string Calle { get; set; }
        public string Calle2 { get; set; }
        public string Codpos { get; set; }
        public string PuebloID { get; set; }
        public string ProvinciaID { get; set; }
        public DateTime? Nacido { get; set; }
	    public string Repepas { get => _repepas; set => _repepas = value; }

      //  public string Error => throw new NotImplementedException();

     //   public string this[string columnName] => throw new NotImplementedException();











        //Constructor sobrecargado
        public Usuario(int usuarioID, string email, string password, string nombre, string apellidos, string dni, string telefono, string calle, string calle2, string codpos, string puebloID, string provinciaID, DateTime? nacido)
        {
            UsuarioID = usuarioID;
            Email= email;
            Password = password;
            Nombre= nombre;
            Apellidos = apellidos;
            Dni = dni;
            Telefono = telefono;
            Calle= calle;
            Calle2 = calle2;
            Codpos = codpos;
            PuebloID = puebloID;
            ProvinciaID = provinciaID;
            Nacido = nacido;
        }

        //Constructor sin argumentos
        public Usuario()
        {
            _usuarioID = 0;
            _email = "email";
            _password = "password";
            _nombre = "nombre";
            _apellidos = "apellidos";
            _dni = "dni";
            _telefono = "1111";
            _calle = "cal";
            _calle2 = "cal2";
            _codpos = "cod";
            _puebloID = "puebloID";
            _provinciaID = "provinciaID";
            _nacido = DateTime.Now;
        }
        //Constructor copia
        public Usuario(Usuario otroUsuario)
        {
            _usuarioID = otroUsuario._usuarioID;
            _email = otroUsuario._email;
            _password = otroUsuario._password;
            _nombre = otroUsuario._nombre;
            _apellidos = otroUsuario._apellidos;
            _dni = otroUsuario._dni;
            _telefono = otroUsuario._telefono;
            _calle = otroUsuario._calle;
            _calle2 = otroUsuario._calle2;
            _codpos = otroUsuario._codpos;
            _puebloID = otroUsuario._puebloID;
            _provinciaID = otroUsuario._provinciaID;
            _nacido = otroUsuario._nacido;
        }
        //Destructor
        ~Usuario()  
        {
            _usuarioID = 0;
            _email = "";
            _password = "";
            _nombre = "";
            _apellidos = "";
            _dni = "";
            _telefono = "";
            _calle = "";
            _calle2 = "";
            _codpos = "";
            _puebloID = "";
            _provinciaID = "";
            _nacido = DateTime.MinValue;
        }

        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return UsuarioID+"#"+Email+"#"+Password+"#"+Nombre+"#"+Apellidos+"#"+Dni+"#"+Telefono+"#"+Calle+"#"+Calle2+"#"
                +"#"+Codpos+"#"+PuebloID+"#"+ProvinciaID+"#"+Nacido;
        }

        /// <summary>
        /// metodo para comparar usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int CompareTo(Usuario usuario)
        {
            return usuario.Email.CompareTo(this.Email);
        }
    }
}
