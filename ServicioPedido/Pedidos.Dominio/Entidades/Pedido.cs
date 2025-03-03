
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Dominio.Entidades
{
    [Table("pedido")]
    public class Pedido : EntidadBase
    {
        [Column("producto")]
        public string Producto { get; set; }
        [Column("valor")]
        public decimal Valor { get; set; }
    }
}
