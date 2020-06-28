using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using MiLibreria;

namespace CapaNegocio
{
    public class NegocioProvincia
    {

        private ProvinciaADO _dat;

        public NegocioProvincia()
        {
            _dat = new ProvinciaADO();
        }

        public List<Provincia> ObtenerProvincias()
        {
            return _dat.LeerProvincias();
        }



        // Creo una nueva Provincia
        public bool Nuevo(string provinciaID,string nombre)
        {

            return (_dat.InsertarProvincia(provinciaID,nombre));
        }


        public bool Actualizar(Provincia provincia)
        {

            return (_dat.ActualizarProvincia(provincia));
        }

        public bool Borrar(int prov)
        {
            return (_dat.BorrarProvincia(prov));
        }

        public DataTable TablaProvincias()
        {


            List<Provincia> loc = ObtenerProvincias();
            loc.OrderBy(x => x.Nombre);

            DataTable dataTableProvincias = Utilidades.ConvertToDataTable(loc); 



            return dataTableProvincias;
        }




    }
}
