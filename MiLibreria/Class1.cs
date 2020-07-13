using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiLibreria
{
    public class Utilidades
    {

        public static bool ValidarFormulario(Control Objeto,ErrorProvider errorProvider)
        {
            bool hayErrores = false;

            foreach (Control Item2 in Objeto.Controls)
            {
                foreach(Control Item in Item2.Controls )
                {
                    if (Item is ErrorTxtBox)
                    {
                        ErrorTxtBox obj = (ErrorTxtBox)Item;
                        if (obj.Validar == true)
                        {
                            if (string.IsNullOrEmpty(obj.Text.Trim()))
                            {
                                errorProvider.SetError(obj, "No puede estar vacio");
                                hayErrores = true;
                            }
                            else
                            {
                                hayErrores = false;
                            }
                        }

                        if (obj.SoloNumeros == true)
                        {
                            int cont = 0; int LetrasEncontradas = 0;

                            foreach (char letra in obj.Text.Trim())
                            {
                                if (char.IsLetter(obj.Text.Trim(), cont))
                                {
                                    LetrasEncontradas++;
                                }
                                cont++;
                            }

                            if (LetrasEncontradas != 0)
                            {
                                hayErrores = true;
                                errorProvider.SetError(obj, "Solo admite numeros");
                            }
                            else
                            {
                                hayErrores = false;
                            }
                        }
                    }
               
                }

                
            }

            return hayErrores;
        }

        public static string ValidaCadena(string campo, string cadena, int longitudMaxima, bool obligatorio)
        {
            int codigoError = 0;
            string mensajeErrores = "";

            if (cadena.Length > longitudMaxima)
                codigoError = 1;
            if (cadena.Length < 1 && obligatorio)
                codigoError = 2;

            switch (codigoError)
            {
                case 0:
                    break;
                case 1:
                    mensajeErrores = "El campo " + campo + " no permite más de " + longitudMaxima + " carácteres" + Environment.NewLine;
                    break;
                case 2:
                    mensajeErrores = "El campo " + campo + " no puede estar vacío" + Environment.NewLine;
                    break;
            }

            return mensajeErrores;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static DataTable ToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }





    }
}
