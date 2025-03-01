
using Pedidos.Dominio.Entidades;
using Pedidos.Dominio.Puertos.Repositorios;

namespace Pedidos.Dominio.Servicios
{
    public class ObtenerPedido(IPedidoRepositorio pedidoRepositorio)
    {
        private readonly IPedidoRepositorio _pedidoRepositorio = pedidoRepositorio;

        public async Task<Pedido> Ejecutar(Guid id) 
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(id) ?? new Pedido();

            return pedido;
        }

    }
}
