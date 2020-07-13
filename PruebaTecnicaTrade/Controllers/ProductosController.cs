using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaTrade.Data.Repository;
using PruebaTecnicaTrade.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        ProductosRepository P = new ProductosRepository();
       // GET: api/<ProductosController>
       [HttpGet]
        public async Task< IEnumerable<Producto>> GetProductos()
        {
            var Lp =await P.GetProductos();
            return Lp; ;
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<bool> DeleteProducto(Guid id)
        {
            bool resul = await P.DeleteProducto(id);
            return resul;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<Producto> PostCreateProducto(Producto pro)
        {
            var p = await P.PostCreateProducto(pro);

            return p;
        }

        [HttpPost]
        public async Task<bool> PostUdateProducto(Producto pro)
        {
            var p = await P.PostUpdateProducto(pro);

            return p;
        }
    }
}
