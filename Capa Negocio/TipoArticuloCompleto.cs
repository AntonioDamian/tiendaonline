using Capa_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_negocio
{
    public class TipoArticuloCompleto:List<TipoArticulo>
    {
        NegociotipoArticulo negociotipoArticulo = new NegociotipoArticulo();
        NegocioProducto negocioProducto = new NegocioProducto();
        NegocioEspecificaciones negoEspe = new NegocioEspecificaciones();
        NegocioStock negocioStock = new NegocioStock();

        public TipoArticuloCompleto()
        {
            this.AddRange(GetTipoArticulo().ToList());

        }


        public IEnumerable<TipoArticulo> GetTipoArticulo()
        {
            return from x in  negociotipoArticulo.ObtenertiposArticulos()
                   select new TipoArticulo
                   {
                       TipoArticuloID = x.TipoArticuloID,
                       Descripcion=x.Descripcion,
                       Articulos = GetArticulos(x.TipoArticuloID).ToList()
                   };
        }

        private IEnumerable<Articulo> GetArticulos(int tipoArticuloID)
        {
            return from x in(negocioProducto.ObtenerArticulos())
                   where x.TipoArticuloID== tipoArticuloID
                   select new Articulo
                   {
                      ArticuloID=x.ArticuloID,
                      Nombre=x.Nombre,
                      Pvp=x.Pvp,
                      MarcaID=x.MarcaID,
                      Imagen=x.Imagen,
                      Urlimagen=x.Urlimagen,
                      Especificaciones=x.Especificaciones,
                      TipoArticuloID=x.TipoArticuloID,
                      EspecificacionesisExtra1=GetExpe(x.ArticuloID,x.TipoArticuloID),
                      Stocks=GetStocks(x.ArticuloID)
                   };
        }

        private IEnumerable<Stock> GetStocks(string articuloID)
        {
            IEnumerable<Stock> list = new List<Stock>();
            Stock st = new Stock();

            st =negocioStock.ObtenerStock(articuloID);

            list.ToList().Add(st);
            ((List<Stock>)list).Add(st);

            return list;


        }

        private IEnumerable<object> GetExpe(string articuloID,int? tipArticulo)
        {
            IEnumerable<Object> list=null;
          
            
            switch(tipArticulo)
            {
                case 1:
                    list = from x in negoEspe.ObtenerTvEspecificacionesID(articuloID)
                           select new Tv
                           {
                              TvID=x.TvID,
                              Panel=x.Panel,
                              Pantalla=x.Pantalla,
                              Resolucion=x.Resolucion,
                              Hdreadyfullhd=x.Hdreadyfullhd,
                              Tdt=x.Tdt
                           };


                    break;
                case 2:

                    list = from x in negoEspe.ObtenerMemoriaEspecificacionesID(articuloID)
                           select new Memoria
                           {
                             MemoriaID= x.MemoriaID,
                             Tipo=x.Tipo
                           };

                    break;
                case 3:

                    list= from x in negoEspe.ObtenerCamaraEspecificacionesID(articuloID)
                           select new Camara
                           {
                               CamaraID = x.CamaraID,
                               Resolucion = x.Resolucion,
                               Sensor = x.Sensor,
                               Tipo = x.Tipo,
                               Factor = x.Factor,
                               Objetivo = x.Objetivo,
                               Pantalla = x.Pantalla,
                               Zoom = x.Zoom
                           };

                    break;
                case 4:

                    list = from x in negoEspe.ObtenerObjetivoEspecificacionesID(articuloID)
                           select new Objetivo

                           {
                              ObjetivoID=x.ObjetivoID,
                              Tipo=x.Tipo,
                              Montura=x.Montura,
                              Focal=x.Focal,
                              Apertura=x.Apertura,
                              Especiales=x.Especiales
                           };

                    break;
            }

        

            return list;     

            
            
           
        }

    }
}
