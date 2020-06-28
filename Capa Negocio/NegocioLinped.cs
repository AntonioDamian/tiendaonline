using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
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

        public bool NuevoLinped(int pedidoID, int linea, string articuloID, decimal importe, int cantidad)
        {
            return _linpedADO.InsertarLinped(pedidoID, linea, articuloID, importe, cantidad);
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
