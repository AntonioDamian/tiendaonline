using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_entidades;
using Capa_Datos;

namespace Capa_negocio
{
   public class NegocioLinped
    {
        private LinpedADO _linpedADO;


        public NegocioLinped()
        {
            _linpedADO = new LinpedADO();
        }

        public List<Linped> ObtenerLinped()
        {
            return _linpedADO.LeerLinped();
        }

        public bool Actualizar(Linped linped)
        {

            return (_linpedADO.ActualizarLinped(linped));
        }

        public bool Borrar(int linped)
        {
            return (_linpedADO.BorrarLinped(linped));
        }
    }


}
