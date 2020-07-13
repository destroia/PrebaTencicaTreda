using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTrade.Data.Interfazes;
using PruebaTecnicaTrade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            try
            {
                var LP = await DB.Productos.ToListAsync();

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
