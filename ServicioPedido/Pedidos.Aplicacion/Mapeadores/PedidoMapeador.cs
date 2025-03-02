
using AutoMapper;
using Pedidos.Aplicacion.Dto;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Aplicacion.Mapeadores
{
    public class PedidoMapeador : Profile
    {
        public PedidoMapeador()
        {
            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Pedido, PedidoIn>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ReverseMap();

        }
    }
}
