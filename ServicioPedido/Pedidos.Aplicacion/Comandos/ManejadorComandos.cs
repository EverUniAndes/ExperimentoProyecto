
using AutoMapper;
using Pedidos.Aplicacion.Dto;
using Pedidos.Aplicacion.Enum;
using Pedidos.Dominio.Entidades;
using Pedidos.Dominio.Servicios;
using System.Net;

namespace Pedidos.Aplicacion.Comandos
{
    public class ManejadorComandos : IComandosProducto
    {
        private readonly CrearPedido _crearPedido;
        private readonly IMapper _mapeador;
        public ManejadorComandos(CrearPedido crearPedido, IMapper mapeador)
        {
            _crearPedido = crearPedido;
            _mapeador = mapeador;
        }
        public async  Task<BaseOut> CrearPedido(PedidoIn pedido)
        {
            BaseOut output = new ();
            try 
            {
                var pedidoDominio = _mapeador.Map<Pedido>(pedido);
                await _crearPedido.Ejecutar(pedidoDominio);
                output.Resultado = Resultado.Exitoso;
                output.Mensaje = "Pedido creado exitosamente";
                output.Status = HttpStatusCode.Created;
            }
            catch (Exception ex) 
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
