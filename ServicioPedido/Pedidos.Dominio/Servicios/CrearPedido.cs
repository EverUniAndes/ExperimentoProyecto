
using Pedidos.Dominio.Entidades;
using Pedidos.Dominio.Puertos.Repositorios;

namespace Pedidos.Dominio.Servicios
{
    public class CrearPedido(IPedidoRepositorio pedidoRepositorio)
    {
        private readonly IPedidoRepositorio _pedidoRepositorio = pedidoRepositorio;

        public async Task Ejecutar(Pedido pedido)
        {
            if (ValorCompra(pedido))
            {
                pedido.Id = Guid.NewGuid();
                pedido.FechaCreacion = DateTime.Now;
                await _pedidoRepositorio.Guardar(pedido);
            }
            else
            {
                throw new InvalidOperationException("Valor de pedido incorrecto");
            }
        }

        public static bool ValorCompra(Pedido pedido) 
        {
            if (pedido.Valor >= 100)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        
        }
    }
}
