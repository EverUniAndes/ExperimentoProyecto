
using AutoMapper;
using Pedidos.Aplicacion.Dto;
using Pedidos.Aplicacion.Enum;
using Pedidos.Dominio.Servicios;
using System.Net;

namespace Pedidos.Aplicacion.Consultas
{
    public class ManejadorConsultas : IConsultasProducto
    {
        private readonly ObtenerPedido _obtenerPedido;
        private readonly ListadoPedido _listadoPedido;
        private readonly IMapper _mapeador;

        public ManejadorConsultas(ObtenerPedido obtenerPedido, ListadoPedido listadoPedido, IMapper mapeador)
        {
            _obtenerPedido = obtenerPedido;
            _listadoPedido = listadoPedido;
            _mapeador = mapeador;
        }
        public async Task<PedidoOut> ObtenerPedido(Guid id)
        {
            PedidoOut output = new ();
            
            try 
            {
                var pedido = await _obtenerPedido.Ejecutar(id);

                if (pedido.Id == Guid.Empty)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "Pedido no encontrado";
                    output.Status = HttpStatusCode.NoContent;
                }
                else 
                {
                    output = _mapeador.Map<PedidoOut>(pedido);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Pedido encontrado";
                    output.Status = HttpStatusCode.OK;
                }
                
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }
            
            return output;
        }

        public async Task<ListaPedidoOut> ObtenerPedidos()
        {
            ListaPedidoOut output = new ();
            
            try 
            {
                var pedidos = await _listadoPedido.Ejecutar();

                if (pedidos.Count > 0)
                {
                    pedidos.ForEach(pedido => output.Pedidos.Add(_mapeador.Map<PedidoDto>(pedido)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Pedidos encontrados";
                    output.Status = HttpStatusCode.OK;
                }
                else 
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "Pedidos no encontrados";
                    output.Status = HttpStatusCode.NoContent;
                }
                
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
