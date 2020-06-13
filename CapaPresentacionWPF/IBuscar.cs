using Capa_entidades;

namespace CapaPresentacionWPF
{
    public interface IBuscar
    {
        void Ejecutar(Articulo articulo);
        void DevolucionPedido(Pedido pedido,string  nombre);
    }
}