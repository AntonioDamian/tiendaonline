using MiLibreria;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CapaPresentacionWPF
{
    public class ValidacionesString : ValidationRule
    {
        public string Campo { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            switch (Campo)

            {
                case "Nombre":

                    if (string.IsNullOrWhiteSpace(str))

                        return new ValidationResult(false, "Nombre es requerido");

                    else if (35 < str.Length)

                        return new ValidationResult(false, "Nombre no debe contener más de 35 caracteres");

                    break;

                case "Apellidos":

                    if (string.IsNullOrWhiteSpace(str))

                        return new ValidationResult(false, "Apellidos es requerido");

                    else if (55 < str.Length)

                        return new ValidationResult(false, "Apellidos no debe " +

                        "contener más de 55 caracteres");

                    break;

                case "Email":

                    if (string.IsNullOrWhiteSpace(str))

                        return new ValidationResult(false, "CorreoElectronico es requerido");

                    else if (50 < str.Length)

                        return new ValidationResult(false, "CorreoElectronico no debe "

                        + "contener más de 50 caracteres");

                    else

                    {

                        Regex regEx;

                        regEx = new Regex("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$");

                        if (!regEx.IsMatch(str))

                            return new ValidationResult(false, "CorreoElectronico no " +

                            "tiene un formato correcto");

                    }

                    break;
                case "Password":
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        string patronContrasenyaValido = (@"[A-Z0-9!@#\$%\^&\*\?_~\/]{8,}$");

                        if (!Regex.IsMatch(str, patronContrasenyaValido))
                        {
                            return new ValidationResult(false, "El formato de la contraseña no es correcto" + Environment.NewLine +
                                "deberá tener al menos 1 número, una mayúscula y un carácter no alfanumérico");

                        }
                        else if (32 < str.Length)
                        {
                            return new ValidationResult(false, "Password no debe "

                       + "contener más de 32 caracteres");
                        }
                    }


                    break;
                case "RePassword":
                    if (!string.IsNullOrWhiteSpace(str))
                    {

                        if (4 < str.Length)
                        {
                            return new ValidationResult(false, "Password no debe "

                       + "contener más de 32 caracteres");
                        }
                    }


                    break;

                case "Dni":
                    if (string.IsNullOrWhiteSpace(str))

                        return new ValidationResult(false, "Dni es requerido");

                    else if (!string.IsNullOrWhiteSpace(str))
                    {
                        string txdni = str;

                        string error = ValidarDni(txdni);

                        return new ValidationResult(false, error);

                    }


                    break;
                case "Telefono":

                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        if (str.Length < 9 || str.Length > 12)
                            return new ValidationResult(false, "El nº telefono no tiene la longitud correcta" + Environment.NewLine + "Min 9 y max 12");
                    }

                    break;
                case "Calle":

                    if (!string.IsNullOrWhiteSpace(str))
                    {

                        if (str.Length > 45)

                            return new ValidationResult(false, "Calle no debe contener más de 45 caracteres");
                    }

                    break;
                case "Calle2":

                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        if (str.Length > 45)
                            return new ValidationResult(false, "Calle2 no debe contener más de 45 caracteres");
                    }

                    break;

                case "Codpos":
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        if (str.Length > 5)
                            return new ValidationResult(false, "Codigo Postal no debe contener más de 5 caracteres");
                    }
                    break;
                case "PuebloID":

                    if (string.IsNullOrWhiteSpace(str))

                        return new ValidationResult(false, "PuebloID es requerido");

                    else if (4 < str.Length)

                        return new ValidationResult(false, "PuebloID no debe contener más de 4 caracteres");

                    break;

                case "ProvinciaID":

                    if (string.IsNullOrWhiteSpace(str))

                        return new ValidationResult(false, "ProvinciaID es requerido");

                    else if (4 < str.Length)

                        return new ValidationResult(false, "ProvinciaID no debe contener más de 4 caracteres");

                    break;
                case "Nacido":


                    try
                    {
                        if (str != null)
                        {
                            DateTime? dateTime = Convert.ToDateTime(str);
                            if (dateTime.Value.Date > DateTime.Now.Date)
                            {
                                return new ValidationResult(false, "La fecha de alta no puede ser mayor que la actual");
                            }
                        }


                    }
                    catch (FormatException)
                    {
                        return new ValidationResult(false, "La fecha seleccionada no es válida");

                    }

                    break;
            }
            return new ValidationResult(true, null);
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
                    mensajesErrores += ("Introduce un DNI o un DNI válido");

                }


            }


            return mensajesErrores;
        }
    }
}
