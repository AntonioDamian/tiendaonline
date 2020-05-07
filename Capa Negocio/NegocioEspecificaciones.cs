using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_entidades;


namespace Capa_negocio
{
   public class NegocioEspecificaciones
    {
        private TvADO _tvADO;
        private MemoriaADO _memoriaADO;
        private CamaraADO _camaraADO;
        private ObjetivoADO _obtivoADO;

        public NegocioEspecificaciones()
        {
            _tvADO = new TvADO();
            _memoriaADO = new MemoriaADO();
            _obtivoADO = new ObjetivoADO();
            _camaraADO = new CamaraADO();
        }


        public List<Tv> ObtenerTvEspecificaciones()
        {  
            return _tvADO.LeerTvs();
        }

        public List<Tv> ObtenerTvEspecificacionesID(string id)
        {
            return _tvADO.Leertv(id);
        }

        public List<Memoria> ObtenerMemoriaEspecificacionesID(string id)
        {
            return _memoriaADO.LeerMemoria(id);
        }

        public List<Camara>ObtenerCamaraEspecificacionesID(string id)
        {
            return _camaraADO.LeerCamara(id);
        }

        public List<Objetivo>ObtenerObjetivoEspecificacionesID(string id)
        {
            return _obtivoADO.LeerObjetivo(id);
        }


    }
}
