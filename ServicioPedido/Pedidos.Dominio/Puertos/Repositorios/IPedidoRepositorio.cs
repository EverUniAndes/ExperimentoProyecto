
using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.Puertos.Repositorios
{
    public interface IPedidoRepositorio
    {
        Task Guardar(Pedido entidad);
        Task<Pedido> ObtenerPorId(Guid id);
        Task<List<Pedido>> DarListado();
    }
}
