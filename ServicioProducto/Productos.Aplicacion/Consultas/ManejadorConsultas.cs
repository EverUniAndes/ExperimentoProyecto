using AutoMapper;
using Productos.Aplicacion.Dto;
using Productos.Aplicacion.Enum;
using Productos.Dominio.Puertos.Repositorios;
using Productos.Dominio.Servicios;
using System.Net;

namespace Productos.Aplicacion.Consultas
{
    public class ManejadorConsultas: IConsultasProducto
    {
        private readonly ObtenerProducto _obtenerProducto;
        private readonly ListadoProductos _listadoProductos;
        private readonly IMapper _mapper;

        public ManejadorConsultas(IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _obtenerProducto = new ObtenerProducto(productoRepositorio);
            _listadoProductos = new ListadoProductos(productoRepositorio);
            _mapper = mapper;
        }

        public async Task<ProductoOut> ObtenerProducto(Guid id)
        {
            ProductoOut productoOut = new();
            try 
            {
                var producto = await _obtenerProducto.Ejecutar(id);

                if(producto.Id == Guid.Empty)
                {
                    productoOut.Resultado = Resultado.SinRegistros;
                    productoOut.Mensaje = "Producto NO encontrado";
                    productoOut.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    productoOut = _mapper.Map<ProductoOut>(producto);
                    productoOut.Resultado = Resultado.Exitoso;
                    productoOut.Mensaje = "Producto encontrado satisfactoriamente";
                    productoOut.Status = HttpStatusCode.OK;
                }
            }
            catch(Exception ex)
            {
                productoOut.Resultado = Resultado.Error;
                productoOut.Mensaje = ex.Message;
                productoOut.Status = HttpStatusCode.InternalServerError;
            }

            return productoOut;
        }

        public Task<ListaProductosOut> ObtenerProductos()
        {
            throw new NotImplementedException();
        }
    }
}
