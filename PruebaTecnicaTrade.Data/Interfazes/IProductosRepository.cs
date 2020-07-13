using PruebaTecnicaTrade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaTrade.Data.Interfazes
{
    public interface IProductosRepository
    {
        Task<bool> DeleteProducto(Guid id);
        Task<Producto> PostCreateProducto(Producto Producto);
        Task<bool> PostUpdateProducto(Producto Producto);
        Task<IEnumerable<Producto>> GetProductos();
    }
}
