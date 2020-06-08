using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;									 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_entidades;


namespace Capa_negocio
{
    public class NegocioProducto
    {
        private ArticuloADO _artDAO;
         List<Articulo> listArt;

        public NegocioProducto()
        {
            _artDAO = new ArticuloADO();
			  listArt = new List<Articulo>();
            listArt = ObtenerArticulos();							   
        }


        public List<Articulo> ObtenerArticulos()
        {
            return _artDAO.LeerArticulos();
        }

	  public List<Articulo> ObtenerArticulo(int id)
        {
            return _artDAO.LeerArticulo(id);
        }											 

        public bool Actualizar(Articulo articulo)
        {

            return (_artDAO.ActualizarArticulo(articulo));
        }

		ObservableCollection<Articulo> aux;
        List<Articulo> aux2 = new List<Articulo>();
        NegocioEspecificaciones negEspe;
        NegocioStock negocioStock;

        List<Tv> lTV = new List<Tv>();
        List<Memoria> lMemo = new List<Memoria>();
        List<Camara> lCama = new List<Camara>();
        List<Objetivo> lObje = new List<Objetivo>();
        Stock stocks = new Stock();
        List<Stock> ListStocks;

        public ObservableCollection<Articulo> ListaArticulos(int tipoArticulo)
        {
            negocioStock = new NegocioStock();
            negEspe = new NegocioEspecificaciones();
          
            

            aux2 = listArt.Where(a => a.TipoArticuloID == tipoArticulo).ToList();

            ListStocks = new List<Stock>();

            switch (tipoArticulo)
            {
                

                case 1:                   
                    for (int i = 0; i < aux2.Count; i++)
                    {
                      
                        lTV = negEspe.ObtenerTvEspecificacionesID(aux2[i].ArticuloID);

                        aux2[i].EspeExtra =new ObservableCollection<object>(lTV);

                        stocks = negocioStock.ObtenerStock(aux2[i].ArticuloID);
                        ListStocks.Add(stocks);

                      // aux2[i].Cantidad = new ObservableCollection<Stock>(ListStocks);
                        aux2[i].Cantidad = stocks.Disponible;
                    }
                    break;

                case 2:
                   
                    for (int i = 0; i < aux2.Count; i++)
                    {
                        lMemo = negEspe.ObtenerMemoriaEspecificacionesID(aux2[i].ArticuloID);
                        aux2[i].EspeExtra = new ObservableCollection<object>(lMemo);
                        stocks = negocioStock.ObtenerStock(aux2[i].ArticuloID);
                        ListStocks.Add(stocks);

                      // aux2[i].Cantidad = new ObservableCollection<Stock>(ListStocks);
                        aux2[i].Cantidad = stocks.Disponible;
                    }
                    break;

                case 3:
                    
                    for (int i = 0; i < aux2.Count; i++)
                    {
                        lCama = negEspe.ObtenerCamaraEspecificacionesID(aux2[i].ArticuloID);
                        
                        aux2[i].EspeExtra = new ObservableCollection<object>(lCama);

                        stocks = negocioStock.ObtenerStock(aux2[i].ArticuloID);
                        ListStocks.Add(stocks);

                     // aux2[i].Cantidad = new ObservableCollection<Stock>(ListStocks);
                        aux2[i].Cantidad = stocks.Disponible;
                    }
                    break;
                case 4:

                    for (int i = 0; i < aux2.Count; i++)
                    {
                        lObje = negEspe.ObtenerObjetivoEspecificacionesID(aux2[i].ArticuloID);

                        aux2[i].EspeExtra = new ObservableCollection<object>(lObje);

                        stocks = negocioStock.ObtenerStock(aux2[i].ArticuloID);
                        ListStocks.Add(stocks);

                      // aux2[i].Cantidad = new ObservableCollection<Stock>(ListStocks);
                        aux2[i].Cantidad = stocks.Disponible;
                    }
                    break;

                default:
                    aux2 = listArt.Where(a => a.TipoArticuloID is null).ToList();

                    for (int i = 0; i < aux2.Count; i++)
                    {

                        stocks = negocioStock.ObtenerStock(aux2[i].ArticuloID);
                        ListStocks.Add(stocks);
                        aux2[i].Cantidad = stocks.Disponible;
                    }

                    break;
                  
              
                    
            }
            aux = new ObservableCollection<Articulo>(aux2);

            return aux;

        }								   
    }
}
