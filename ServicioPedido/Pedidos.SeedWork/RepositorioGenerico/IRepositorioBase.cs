
using Pedidos.Dominio.Entidades;

namespace Pedidos.SeedWork.RepositorioGenerico
{
    public interface IRepositorioBase<T> : IDisposable where T : EntidadBase
    {
        Task<T> Guardar(T entity);
        Task<T> BuscarPorLlave(object ValueKey);
        Task<List<T>> DarListado();

    }
}
