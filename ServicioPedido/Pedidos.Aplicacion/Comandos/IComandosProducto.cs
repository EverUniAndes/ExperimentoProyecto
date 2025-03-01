
using Pedidos.Aplicacion.Dto;

namespace Pedidos.Aplicacion.Comandos
{
    public interface IComandosProducto
    {
        Task<BaseOut> CrearPedido(PedidoIn pedido);
    }
}
