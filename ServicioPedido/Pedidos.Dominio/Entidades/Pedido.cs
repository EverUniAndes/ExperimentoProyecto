
namespace Pedidos.Dominio.Entidades
{
    public class Pedido : EntidadBase
    {
        public string Producto { get; set; }
        public decimal Valor { get; set; }
    }
}
