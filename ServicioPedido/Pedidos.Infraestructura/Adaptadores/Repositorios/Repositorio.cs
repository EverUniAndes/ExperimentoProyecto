
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Dominio.Entidades;
using Pedidos.SeedWork.RepositorioGenerico;

namespace Pedidos.Infraestructura.Adaptadores.Repositorios
{
    public class Repositorio<T> : IRepositorioBase<T> where T : EntidadBase
    {
        private readonly IServiceProvider _serviceProvider;

        public Repositorio(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        private PedidosDbContext GetContext()
        {
            return _serviceProvider.GetService<PedidosDbContext>();
        }

        protected DbSet<T> GetEntitySet()
        {
            return GetContext().Set<T>();
        }

        public async Task<T> BuscarPorLlave(object ValueKey)
        {
            var ctx = GetContext();
            var entitySet = ctx.Set<T>();
            var res = await entitySet.FindAsync(ValueKey);
            await ctx.DisposeAsync();
            return res;
        }

        public async Task<List<T>> DarListado()
        {
            var ctx = GetContext();
            var entitySet = ctx.Set<T>();
            var res = await entitySet.ToListAsync();
            await ctx.DisposeAsync();
            return res;
        }

        public async Task<T> Guardar(T entity)
        {
            var ctx = GetContext();
            var entitySet = ctx.Set<T>();
            var res = await entitySet.AddAsync(entity);
            await ctx.SaveChangesAsync();
            await ctx.DisposeAsync();
            return res.Entity;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                var ctx = GetContext();
                ctx.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
