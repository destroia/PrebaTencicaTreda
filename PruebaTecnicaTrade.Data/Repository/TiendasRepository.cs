using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTrade.Data.Interfazes;
using PruebaTecnicaTrade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaTrade.Data.Repository
{
    public class TiendasRepository : ITiendasRepository
    {
        PruebaTecnicaTradeContext DB = new PruebaTecnicaTradeContext();
        public async Task<bool> DeleteTienda(Guid id)
        {
            try
            {
                var T = await DB.Tiendas.FindAsync(id);
                DB.Tiendas.Remove(T);
                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
           
        }

        public async Task<IEnumerable<Tienda>> GetTiendas()
        {
            try
            {
                var Lt = await DB.Tiendas.ToListAsync();
                return Lt;
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public async Task<Tienda> PostCreateTienda(Tienda tienda)
        {
            try
            {
                await DB.AddAsync(tienda);
                await DB.SaveChangesAsync();
                return tienda;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> PostUpdateTienda(Tienda tienda)
        {
           
            try
            {
                DB.Tiendas.Update(tienda);
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
