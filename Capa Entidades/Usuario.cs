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
    /// <Author>Antº Damian Galvañ Candela</Author>
    /// <summary>
    /// Clase Usuario contiene los atributos,propiedades,constructores y mètodos relacionados con Usuarios.
    /// </summary>
    ///<remarks>
    /// Permite crear  usuarios.
    ///</remarks>
    public class Usuario : IComparable<Usuario>, IDataErrorInfo
    {
        //Atributos

        /// <summary>Campo de tipo entero que representa el código del usuario </summary>
        int _usuarioID;
        /// <summary> Campo de tipo cadena que representa el email del usuario</summary>
        string _email;
        /// <summary> Campo de tipo cadena que representa el password del usuario</summary>
        string _password;
        /// <summary> Campo de tipo cadena que representa el nombre del usuario</summary>
        string _nombre;
        /// <summary> Campo de tipo cadena que representa el apellidos del usuario</summary>
        string _apellidos;
        /// <summary> Campo de tipo cadena que representa el dni del usuario</summary>
        string _dni;
        /// <summary> Campo de tipo cadena que representa el teléfono del usuario</summary>
        string _telefono;
        /// <summary> Campo de tipo cadena que representa el calle del usuario</summary>
        string _calle;
        /// <summary> Campo de tipo cadena que representa el calle2 del usuario</summary>
        string _calle2;
        /// <summary> Campo de tipo cadena que representa el codigo postal del usuario</summary>
        string _codpos;
        /// <summary> Campo de tipo cadena que representa el id del pueblo del usuario</summary>
        string _puebloID;
        /// <summary> Campo de tipo cadena que representa el id de la provincia del usuario</summary>
        string _provinciaID;
        /// <summary>Campo de tipo fecha que representa la fecha de nacimiento del usuario</summary>
        DateTime? _nacido;
      


        /// <summary>
        ///     <para>Método constructor de la clase que inicializa las variables a su valor por defecto</para>
        ///     <para>Vea también cómo construir un usuario con datos concretos en <see cref="Usuario.Usuario(int,string,string,string,string,
        ///     string,string,string,string,string,string,string,DateTime)"/></para>
        /// </summary>
        /// <remarks>
        ///   El campo UsuarioID es autoincremental y se realizara desde la base de datos,aunque en se le asigan un 0 por defecto,y se le debe asignar 0 al construir un usuario
        /// </remarks>
        /// <example>
        /// Ejemplo de cómo se debe realizar una llamada al constructor <see cref="Usuario"/> por defecto
        /// <code>
        ///     // Crear un usuario por defecto
        ///     Usuario nuevoUsuario = new Usuario();
        /// </code>
        /// </example>
        //Constructor sin argumentos
        public Usuario()
        {    

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

        /// <summary>
        /// Constructor de la clase Usuario que recibe como argumento ,usuarioid,email,password,nombre apelllidos,dni,teléfono,calle,calle2,codigo postal,
        /// id del pueblo  ,id de la provincia y fecha de nacimiento del usuario
        /// </summary>
        /// <param name="usuarioID">entero que representa el código del usuario</param>
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
        ///<example>
        ///Ejemplo de como se debe realizar una llamada al constructor <see cref="Usuario"/> con parametros
        ///<code>
        ///   //Crear un usuario con distintas combinaciones.
        ///   Usuario newUsuario=new Usuario(0,ada@da.es,1234,Juan,Cremades,25365419B,961483799,Piles-Infanzon, Del,Carretera, 7, 1 A,null,46055,2331,46,10-05-1980);
        ///          representan en ese orden los datos introducidos
        ///          usuarioID,email,password,nombre,apellidos,dni,telefono,calle,calle2,codpos,puebloID,provinciaID,nacido
        ///</code>
        ///</example>
        ///<remarks>
        ///<para>
        /// Hay atributos que no pueden ser nulos,como usuarioId,email,nombre,apellidos,dni,puebloId y provinciaId,
        /// que son validados al intentar crear el usuario en la base de datos,en el constructor y las propiedades no son validados</para>
        /// <para>Aunque podria admitir algun nulo en el constructor,sin estar registrado en la base no podria actuar,por lo tanto se valida al intentar agragarlo a la base de datos</para>
        ///</remarks>
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

        /// <summary>
        /// Constructor de copia de usuario
        /// </summary>
        /// <param name="otroUsuario"> Repreenta el usuario al que vamos a copiar</param>

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


        /// <summary>
        ///  Destructor de la clase Usuario que permite la liberación de la memoria una vez que no se emplean sus componentes
        /// </summary>
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

        //propiedades


        /// <summary>
        /// Propiedad UsuarioID que representa el UsuarioID del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad UsuarioID con el valor del campo _usuarioID</value>
        public int UsuarioID { get; set; }
        /// <summary>
        /// Propiedad Email que representa el Email del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Email con el valor del campo _email</value>
        public string Email { get; set; }
        /// <summary>
        /// Propiedad Password que representa el Password del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Password con el valor del campo _password</value>
        public string Password { get; set; }
        /// <summary>
        /// Propiedad Nombre que representa el Nombre del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Nombre con el valor del campo _nombre</value>
        public string Nombre { get; set; }
        /// <summary>
        /// Propiedad Apellidos que representa el Apellidos del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Apellidos con el valor del campo _apellidos</value>
        public string Apellidos { get; set; }
        /// <summary>
        /// Propiedad Dni que representa el Dni del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Dni con el valor del campo _dni</value>
        public string Dni { get; set; }
        /// <summary>
        /// Propiedad Telefono que representa el teléfono del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Telefono con el valor del campo _telefono</value>
        public string Telefono { get; set; }
        /// <summary>
        /// Propiedad calle que representa el calle del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Calle con el valor del campo _calle</value>
        public string Calle { get; set; }
        /// <summary>
        /// Propiedad Calle2 que representa otra calle del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Callle2 con el valor del campo _calle2</value>
        public string Calle2 { get; set; }
        /// <summary>
        /// Propiedad Codpos que representa el codigo postal del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Codpos con el valor del campo _codpos</value>
        public string Codpos { get; set; }
        /// <summary>
        /// Propiedad PuebloID que representa el ID del pueblo del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad PuebloID con el valor del campo _puebloID</value>
        public string PuebloID { get; set; }
        /// <summary>
        /// Propiedad ProvinciaID que representa el ID de la provincia del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad ProvinciaID con el valor del campo _provinciaID</value>
        public string ProvinciaID { get; set; }
        /// <summary>
        /// Propiedad Nacido que representa el nacimiento  del usuario
        /// </summary>
        /// <value>Getter y Setter del valor de la propiedad Nacido con el valor del campo _nacido</value>
        public DateTime? Nacido { get; set; }
      

      


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
        ///  <para>Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.</para>        /// 
        /// </summary>
        /// <returns>string con todos los datos del usuario </returns>
        public override string ToString()
        {
            return UsuarioID + "#" + Email + "#" + Password + "#" + Nombre + "#" + Apellidos + "#" + Dni + "#" + Telefono + "#" + Calle + "#" + Calle2 + "#"
                + Codpos + "#" + PuebloID + "#" + ProvinciaID + "#" + Nacido;
        }

        /// <summary>
        /// metodo para comparar usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <remarks>
        /// <para>Menor que cero	Esta instancia es menor que value.</para>
        /// <para>Cero	Esta instancia es igual a value.</para>
        /// <para>Mayor que cero	Esta instancia es mayor que value.</para>
        /// </remarks>
        /// <returns>devuelve una indicación de sus valores relativos</returns>
        public int CompareTo(Usuario usuario)
        {
            return usuario.Email.CompareTo(this.Email);
        }
    }
}
