using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTrade.Data.Interfazes;
using PruebaTecnicaTrade.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PruebaTecnicaTrade.Data.Repository
{
    public class ProductosRepository : IProductosRepository
    {
        PruebaTecnicaTradeContext DB = new PruebaTecnicaTradeContext();

        public async Task<bool> DeleteProducto(Guid id)
        {
            try
            {
                var P = await DB.Productos.FindAsync(id);
                DB.Productos.Remove(P);
                await DB.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        //dasdasd
        public async Task<IEnumerable<Producto>> GetProductos(Guid id)
        {
            try
            {
                var LP = await DB.Productos.Where( x => x.TiendaId == id).ToListAsync();

                foreach (var item in LP)
                {
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), item.Imagen);

                    byte[] imageArray = System.IO.File.ReadAllBytes(pathToSave);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    item.ImagenBase64 = base64ImageRepresentation;
                }
                return LP;
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public async Task<Producto> PostCreateProducto(Producto Producto)
        {
            try
            {
                await DB.Productos.AddAsync(Producto);
                await DB.SaveChangesAsync();
                return Producto;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> PostUpdateProducto(Producto Producto)
        {
           
            try
            {
                DB.Productos.Update(Producto);
                await DB.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
