
namespace Pedidos.Aplicacion.Dto
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public string Producto { get; set; }
        public decimal Valor { get; set; }

    }

    public class PedidoOut : BaseOut
    {
        public PedidoDto Pedido { get; set; }

    }

    public class ListaPedidoOut : BaseOut
    {
        public List<PedidoDto> Pedidos { get; set; }

    }


}
