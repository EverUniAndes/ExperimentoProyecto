using Microsoft.AspNetCore.Mvc;
using Pedidos.Aplicacion.Comandos;
using Pedidos.Aplicacion.Consultas;
using Pedidos.Aplicacion.Dto;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IConsultasProducto _consultasPedidos;
        private readonly IComandosProducto _comandosPedido;    
        
        public PedidosController(IConsultasProducto consultasPedidos, IComandosProducto comandosPedido)
        {
            _consultasPedidos = consultasPedidos;
            _comandosPedido = comandosPedido;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            var output = await _consultasPedidos.ObtenerPedidos();
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPedido(PedidoIn input)
        {
            var output = await _comandosPedido.CrearPedido(input);
            return Ok(output);
        }


    }
}
