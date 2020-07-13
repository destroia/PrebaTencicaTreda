using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using PruebaTecnicaTrade.Data.Repository;
using PruebaTecnicaTrade.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaTrade.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TiendasController : ControllerBase
    {
        TiendasRepository T = new TiendasRepository();
        // GET: api/<TiendasController>
        //fgdfgdf
        [HttpGet]
        public async Task<IEnumerable<Tienda>> GetTiendas()
        {
            var LT = await T.GetTiendas();
            return LT;
        }

        // GET api/<TiendasController>/5
        [HttpGet("{id}")]
        public async Task< bool> GetDeleteTienda(Guid id)
        {
            var res =  await T.DeleteTienda(id);
            return res;
        }

        // POST api/<TiendasController>
        [HttpPost]
        public async Task<Tienda> PostCreateTienda(Tienda tienda)
        {
            var P = await T.PostCreateTienda(tienda);
            return P;
        }

        // PUT api/<TiendasController>/5
        [HttpPost]
        public async Task<bool>  PostUpdateTienda(Tienda tienda)
        {
            bool resul = await T.PostUpdateTienda(tienda);

            return resul;
        }
    }
}
