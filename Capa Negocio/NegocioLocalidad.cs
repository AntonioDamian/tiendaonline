using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;


namespace CapaNegocio
{
    public class NegocioLocalidad
    {

        private LocalidadADO _dat;

        public NegocioLocalidad()
        {
            _dat = new LocalidadADO();
        }

        public List<Localidad> ObtenerLocalidades()
        {
            return _dat.LeerLocalidades();
        }

       

        // Creo una nueva localidad
        public bool Nuevo(string localidadId,string nombre,string provinciaId)
        {

            return (_dat.InsertarLocalidad(localidadId,nombre,provinciaId));
        }


        public bool Actualizar(Localidad localidad)
        {

            return (_dat.ActualizarLocalidad(localidad));
        }

        public bool Borrar(int loca)
        {
            return (_dat.BorrarLocalidad(loca));
        }

        public DataTable TablaLocalidades()     {
        

            List<Localidad> loc = ObtenerLocalidades();
            List<Localidad> locOrdenada = new List<Localidad>();
            locOrdenada= loc.OrderBy(x => x.Nombre).ToList();

            DataTable dataTableLocalidades = ConvertToDataTable(locOrdenada);


            return dataTableLocalidades;
        }





        public DataTable ConvertToDataTable<T>(IList<T> data)
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
    }
}
