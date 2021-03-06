﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaTrade.Data.Repository;
using PruebaTecnicaTrade.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaTrade.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        ProductosRepository P = new ProductosRepository();
       // GET: api/<ProductosController>
       [HttpGet("{id}")]
        public async Task<IEnumerable<Producto>> GetProductos(Guid id)
        {
            var Lp =await P.GetProductos(id);
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

        //Post Desde angular 
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Imagenes");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    //Producto
                    var json = Request.Form["producto"];
                    var pro = Newtonsoft.Json.JsonConvert.DeserializeObject<Producto>(json);
                    pro.Imagen = dbPath;
                    var p = await P.PostCreateProducto(pro);
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
               

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        public async Task<IActionResult> UpdateUpload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Imagenes");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    //Producto
                    var json = Request.Form["producto"];
                    var pro = Newtonsoft.Json.JsonConvert.DeserializeObject<Producto>(json);
                    pro.Imagen = dbPath;
                    var p = await P.PostUpdateProducto(pro);
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
