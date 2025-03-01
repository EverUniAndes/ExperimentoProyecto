
using Pedidos.Dominio.Entidades;
using Pedidos.Dominio.Puertos.Repositorios;
using Pedidos.SeedWork.RepositorioGenerico;

namespace Pedidos.Infraestructura.Adaptadores.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly IRepositorioBase<Pedido> _repositorioPedido;

        public PedidoRepositorio(IRepositorioBase<Pedido> repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
        public async Task<List<Pedido>> DarListado()
        {
            return await _repositorioPedido.DarListado();
        }

        public async Task Guardar(Pedido entidad)
        {
            await _repositorioPedido.Guardar(entidad);
        }

        public async Task<Pedido> ObtenerPorId(Guid id)
        {
            return await _repositorioPedido.BuscarPorLlave(id);
        }
    }
}
