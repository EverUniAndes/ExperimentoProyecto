
using Pedidos.Aplicacion.Dto;

namespace Pedidos.Aplicacion.Consultas
{
    public interface IConsultasProducto
    {
        public Task<PedidoOut> ObtenerPedido(Guid id);
        public Task<ListaPedidoOut> ObtenerPedidos();
    }
}
