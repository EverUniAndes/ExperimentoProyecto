
using Pedidos.Dominio.Entidades;
using Pedidos.Dominio.Puertos.Repositorios;

namespace Pedidos.Dominio.Servicios
{
    public class ListadoPedido(IPedidoRepositorio pedidoRepositorio)
    {
        private readonly IPedidoRepositorio _pedidoRepositorio = pedidoRepositorio;
        
        public async Task<List<Pedido>> Ejecutar()
        {
            return await _pedidoRepositorio.DarListado() ?? [];
        }
    }
}
