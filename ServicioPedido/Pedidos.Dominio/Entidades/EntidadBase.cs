
namespace Pedidos.Dominio.Entidades
{
    public abstract class EntidadBase
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }

}
