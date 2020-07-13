using PruebaTecnicaTrade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaTrade.Data.Interfazes
{
    public interface ITiendasRepository
    {
        Task<bool> DeleteTienda(Guid id);
        Task<Tienda> PostCreateTienda(Tienda tienda);
        Task<bool> PostUpdateTienda(Tienda tienda);
        Task<IEnumerable<Tienda>> GetTiendas();
        

    }
}
