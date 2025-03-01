
namespace Pedidos.Aplicacion.Dto
{
    public class PedidoIn
    {
        public Guid Id { get; set; }
        public string Producto { get; set; }
        public decimal Valor { get; set; }
    }
}
