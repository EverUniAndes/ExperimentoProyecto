
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Dominio.Entidades
{
    [Table("Pedido")]
    public class Pedido : EntidadBase
    {
        public string Producto { get; set; }
        public decimal Valor { get; set; }
    }
}
