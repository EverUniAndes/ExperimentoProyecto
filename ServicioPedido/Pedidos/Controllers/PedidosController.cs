using Microsoft.AspNetCore.Mvc;
using Pedidos.Aplicacion.Comandos;
using Pedidos.Aplicacion.Consultas;
using Pedidos.Aplicacion.Dto;
using Pedidos.Aplicacion.Enum;

namespace Pedidos.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PedidosController : ControllerBase
    {
        private readonly IConsultasProducto _consultasPedidos;
        private readonly IComandosProducto _comandosPedido;    
        
        public PedidosController(IConsultasProducto consultasPedidos, IComandosProducto comandosPedido)
        {
            _consultasPedidos = consultasPedidos;
            _comandosPedido = comandosPedido;
        }

        /// <summary>
        /// Obtiene la lista de pedidos
        /// </summary>
        /// <response code="200"> 
        /// ListaPedidoOut pendiente
        /// </response>
        [HttpGet]
        [Route("Listar")]
        [ProducesResponseType(typeof(ListaPedidoOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ListarPedidos()
        {
            var output = await _consultasPedidos.ObtenerPedidos();

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else 
            { 
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
            
        }

        /// <summary>
        /// Crear un pedido
        /// </summary>
        /// /// <param name="input">
        /// pendiente    
        /// </param>
        /// <response code="200"> 
        /// ListaPedidoOut pendiente
        /// </response>
        [HttpPost]
        [Route("Crear")]
        [ProducesResponseType(typeof(PedidoOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> CrearPedido([FromBody] PedidoIn input)
        {
            var output = await _comandosPedido.CrearPedido(input);
            
            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }


    }
}
