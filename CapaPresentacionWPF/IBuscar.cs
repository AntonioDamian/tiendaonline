using CapaEntidades;

namespace CapaPresentacionWPF
{
    public interface IBuscar
    {
        void Ejecutar(Articulo articulo);
        void DevolucionPedido(Pedido pedido,string  nombre);
        void DevolucionLocalidad(Localidad localidad);
    }


}