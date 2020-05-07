using MiLibreria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capa_entidades
{

    /// <summary>
    /// Clase usuario
    /// </summary>
    /// <Author>Antº Damian Galvañ Candela</Author>
    public class Usuario : IComparable<Usuario>, IDataErrorInfo
    {
        //Atributos
        int _usuarioID;
        string _email;
        string _password;
        string _nombre;
        string _apellidos;
        string _dni;
        string _telefono;
        string _calle;
        string _calle2;
        string _codpos;
        string _puebloID;
        string _provinciaID;
        DateTime? _nacido;
        string _repepas;









        //Propiedades

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








        //Constructor sin argumentos
        public Usuario()
        {
            /*_usuarioID = 0;
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
            _nacido = DateTime.Now;*/

            UsuarioID = 0;
            Email = "email";
            Password = "password";
            Nombre = "nombre";
            Apellidos = "apellidos";
            Dni = "dni";
            Telefono = "##999999999";
            Calle = "calle";
            Calle2 = "calle2";
            Codpos = "codpos";
            PuebloID = "puebloID";
            ProvinciaID = "provinciaID";
            Nacido = DateTime.Now;

        }






        //Constructor sobrecargado
        public Usuario(int usuarioID, string email, string password, string nombre, string apellidos, string dni, string telefono, string calle, string calle2, string codpos, string puebloID, string provinciaID, DateTime? nacido)
        {
            UsuarioID = usuarioID;
            Email = email;
            Password = password;
            Nombre = nombre;
            Apellidos = apellidos;
            Dni = dni;
            Telefono = telefono;
            Calle = calle;
            Calle2 = calle2;
            Codpos = codpos;
            PuebloID = puebloID;
            ProvinciaID = provinciaID;
            Nacido = nacido;
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


        public int UsuarioID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Calle2 { get; set; }
        public string Codpos { get; set; }
        public string PuebloID { get; set; }
        public string ProvinciaID { get; set; }
        public DateTime? Nacido { get; set; }
        public string Repepas { get => _repepas; set => _repepas = value; }

        /*   private string error = string.Empty;
           public string Error { get { return error; } }*/

        /*    public string this[string columnName]
            {
                get
                {
                    string result = null;

                    if (columnName == "Nombre")
                    {
                        if (string.IsNullOrEmpty(Nombre) || Nombre.Length < 3)
                            result = "Please enter a Name";

                        if(string.IsNullOrEmpty(Nombre) )
                        {
                            result = "Nombre no puede ser nulo";
                        }
                        else
                        {
                            result = "Nombre no puede superar los 35 caracteres";
                        }                 

                    }
                    return result;
                }
            }*/


        private string IsValid(string propertyName)

        {

            switch (propertyName)

            {



                case "Nombre":

                        if (string.IsNullOrWhiteSpace(Nombre))

                            return "Nombre es requerido";

                        else if (35 < Nombre.Length)

                            return "Nombre no debe " +

                            "contener más de 35 caracteres";

                    break;

                case "Apellidos":

                    if (string.IsNullOrWhiteSpace(Apellidos))

                        return "Apellidos es requerido";

                    else if (55 < Apellidos.Length)

                        return "Apellidos no debe " +

                        "contener más de 55 caracteres";

                    break;

                case "Email":

                    if (string.IsNullOrWhiteSpace(Email))

                        return "CorreoElectronico es requerido";

                    else if (50 < Email.Length)

                        return "CorreoElectronico no debe "

                        + "contener más de 50 caracteres";

                    else

                    {

                        Regex regEx;                       

                        regEx = new Regex("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$");

                        if (!regEx.IsMatch(Email))

                            return "CorreoElectronico no " +

                            "tiene un formato correcto";

                    }

                    break;
                case "Password":
                    if (!string.IsNullOrWhiteSpace(Password))
                    {  
                        string patronContrasenyaValido = (@"[A-Z0-9!@#\$%\^&\*\?_~\/]{8,}$");

                        if (!Regex.IsMatch(Password, patronContrasenyaValido))
                        {
                            return "El formato de la contraseña no es correcto"+Environment.NewLine+"deberá tener una complejidad de al menos 1 número, una mayúscula y un carácter no alfanumérico" ;

                        }
                        else if (32 < Password.Length)
                        {
                            return "Password no debe "

                       + "contener más de 32 caracteres";
                        }
                    }


                    break;

                case "Dni":
                    if(!string.IsNullOrWhiteSpace(Dni))
                    {
                        string txdni = Dni;

                        string error = ValidarDni(txdni);

                        return error;

                    }
                   

                    break;
                case "Telefono":

                    if (!string.IsNullOrWhiteSpace(Telefono))
                    {
                        if (Telefono.Length < 9 || Telefono.Length > 12)
                            return "El nº telefono no tiene la longitud correcta" + Environment.NewLine + "Min 9 y max 12";
                    }

                    break;
                case "Calle":

                    if (!string.IsNullOrWhiteSpace(Calle)) { 
                 
                        if (Calle.Length >45)

                            return "Calle no debe contener más de 45 caracteres";
                    }

                    break;
                case "Calle2":

                    if (!string.IsNullOrWhiteSpace(Calle2))
                    {
                        if (Calle2.Length>45)
                            return "Calle2 no debe contener más de 45 caracteres";
                    }

                    break;

                case "Codpos":
                    if (!string.IsNullOrWhiteSpace(Codpos))
                    {
                        if (Codpos.Length > 5)
                            return "Codigo Postal no debe contener más de 5 caracteres";
                    }
                        break;
                case "PuebloID":

                    if (string.IsNullOrWhiteSpace(PuebloID))

                        return "PuebloID es requerido";

                    else if (4 < PuebloID.Length)

                        return "PuebloID no debe contener más de 4 caracteres";

                    break;

                case "ProvinciaID":

                    if (string.IsNullOrWhiteSpace(ProvinciaID))

                        return "ProvinciaID es requerido";

                    else if (4 < ProvinciaID.Length)

                        return "ProvinciaID no debe contener más de 4 caracteres";

                    break;
                case "Nacido":

                    string mensajesErrores = "La fecha de alta no puede ser mayor que la actual" + Environment.NewLine;
                    try
                    {
                        if (Nacido.Value.Date > DateTime.Now.Date)
                        {
                           return  mensajesErrores;
                            
                        }
                     
                    }
                    catch (FormatException)
                    {
                        return "La fecha seleccionada no es válida";
                       
                    }

                    break;







            }

            return null;

        }

        private string ValidarDni(string dni)
        {
          

            string mensajesErrores = Utilidades.ValidaCadena("DNI", dni, 9, true);
            string patronNIFValido = "^([0-9]{8}[A-Z]{1})|[XYZ][0-9]{7}[A-Z]{1}$";
            if (!"".Equals(mensajesErrores) || !Regex.IsMatch(dni, patronNIFValido))
            {
                mensajesErrores += "El formato del DNI no es correcto" + Environment.NewLine;             
               
            }
            else
            {
                // Calculamos la letra del documento
                string numeroDNI = "";
                if (dni.StartsWith("X"))
                    numeroDNI = 0 + dni.Substring(1, 7);
                else if (dni.StartsWith("Y"))
                    numeroDNI = 1 + dni.Substring(1, 7);
                else if (dni.StartsWith("Z"))
                    numeroDNI = 2 + dni.Substring(1, 7);
                else
                    numeroDNI = dni.Substring(0, 8);

                string letraNIF = "TRWAGMYFPDXBNJZSQVHLCKE";
                int posicionLetra = Int32.Parse(numeroDNI) % 23;

                if (!letraNIF[posicionLetra].Equals(dni[8]))
                {
                    mensajesErrores +=( "Introduce un DNI o un DNI válido");
                    
                }
              
               
            }


            return mensajesErrores;
        }

        public bool IsValid()

        {

            return string.IsNullOrEmpty(IsValid("Nombre"))

                && string.IsNullOrEmpty(IsValid("Apellidos"))

                && string.IsNullOrEmpty(IsValid("Email"));



        }

        public string Error
        {
            get

            {

                return null;

            }
        }

        public string this[string propertyName]
        {
            get

            {

                return IsValid(propertyName);

            }
        }



        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return UsuarioID + "#" + Email + "#" + Password + "#" + Nombre + "#" + Apellidos + "#" + Dni + "#" + Telefono + "#" + Calle + "#" + Calle2 + "#"
                + Codpos + "#" + PuebloID + "#" + ProvinciaID + "#" + Nacido;
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
