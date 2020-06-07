using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Capa_entidades
{

    /// <summary>
    /// Clase stock
    /// </summary>
    /// <Author>Ant� Damian Galva� Candela</Author>  
    /// 
    [Serializable]
    public enum Entrega
    {
        Descatalogado,
        Proximamente,
        [Description("24 horas")]
        Horas,
        [Description("3/4 dias")]
        Dias,
        [Description("1/2 semanas")]
        Semanas,

    }

    /* public static string GetDescription(this Enum e)
       {
           FieldInfo field = e.GetType().GetField(e.ToString());
           if (field != null)
           {
               object[] attribs =
                 field.GetCustomAttributes(typeof(DescriptionAttribute), false);

               if (attribs.Length > 0)
                   return (attribs[0] as DescriptionAttribute).Description;
           }
           return e.ToString();
       }*/


   

    public class Stock
    {
        //Atributos
        private string _articuloID;
        private int? _disponible;
       // private Entrega _entrega;
        private string _entrega;

        //Propiedades
        public string ArticuloID { get => _articuloID;
            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentOutOfRangeException("ArticuloID no puede superar los 7 caracteres");
                }
                _articuloID = value ?? throw new ArgumentNullException("ArticuloID no puede ser nulo");



            }
        }
        public int? Disponible
        {
            get => _disponible;
            set
            {


                if (value.ToString().Length > 11)
                {
                    throw new ArgumentOutOfRangeException("Disponible no puede superar los 11 caracteres");
                }

                else
                {
                    _disponible = value;
                }
            }
        }

        public string Entrega { get => _entrega.ToString(); set => _entrega =value; }

        


        //Constructor sin argumentos
        public Stock()
        {
            _articuloID = "articuloID";
            _disponible = 0;
           _entrega = default;

        }

        //Constructor con argumentos
        public Stock(string articuloID, int disponible, Entrega entrega)
        {
            _articuloID = articuloID;
            _disponible = disponible;
            //  _entrega = ObtenerValorString(entrega);

             _entrega = entrega.ToString();
           


        }
        //Constructor de copia
        public Stock(Stock otroStock)
        {
            _articuloID = otroStock._articuloID;
            _disponible = otroStock._disponible;
            _entrega = otroStock._entrega;
        }

        //Destructor
        ~Stock()
        {
            _articuloID = "";
            _disponible = 0;
            _entrega = default;
        }


        //Metodos

        /// <summary>
        ///  Metodo ToString, creara una cadena de texto separando todos y cada uno de los atributos por el caracter #.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return ArticuloID + "#" + Disponible + "#" + _entrega.ToString();
        }

        public static string ObtenerValorString(Enum value)

        {

            // Obtiene el tipo

            Type type = value.GetType();
            // Obtiene el fieldinfo para este tipo

            FieldInfo fieldInfo = type.GetField(value.ToString());



            // Obtiene el atributo ValorString

            Stock[] attribs = fieldInfo.GetCustomAttributes(

            typeof(Stock), false) as Stock[];



            // Retorna el primer elemento.

            return attribs.Length > 0 ? attribs[0].ToString() : null;
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(
                                typeof(DescriptionAttribute), false), (
                                    f, a) => new { Field = f, Att = a })
                            .Where(a => ((DescriptionAttribute)a.Att)
                                .Description == description).SingleOrDefault();
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }




    }




}

    

