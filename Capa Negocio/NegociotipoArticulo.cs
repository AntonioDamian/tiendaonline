using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_entidades;
using System.Collections.ObjectModel;									 

namespace Capa_negocio
{
    public class NegociotipoArticulo
    {

        private TipoArticuloADO _tipoArticuloADO;
        NegocioProducto negProducto = new NegocioProducto();
        ObservableCollection<TipoArticulo> ListaTipos;
        List<TipoArticulo> aux = new List<TipoArticulo>();



        public NegociotipoArticulo()
        {
            _tipoArticuloADO = new TipoArticuloADO();
        }


        public List<TipoArticulo> ObtenertiposArticulos()
        {
            return _tipoArticuloADO.LeerTipoTipoArticulos();
        }
        public ObservableCollection<TipoArticulo>ListadoTipos()
        {
            ListaTipos = new ObservableCollection<TipoArticulo>();


            aux = ObtenertiposArticulos();
            ListaTipos.Add(new TipoArticulo(0, "Null", negProducto.ListaArticulos(0)));
            foreach (TipoArticulo t in aux)
            {

                ListaTipos.Add(new TipoArticulo( t.TipoArticuloID, t.Descripcion, negProducto.ListaArticulos(t.TipoArticuloID)));

            } 

           

            return ListaTipos;

        }
      
    }
}
