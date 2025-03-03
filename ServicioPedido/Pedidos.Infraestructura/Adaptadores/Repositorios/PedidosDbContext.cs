
using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Infraestructura.Adaptadores.Repositorios
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }

    }
}
