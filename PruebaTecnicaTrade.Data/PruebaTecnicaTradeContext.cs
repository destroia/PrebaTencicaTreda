using Microsoft.EntityFrameworkCore;
using PruebaTecnicaTrade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnicaTrade.Data
{
    public class PruebaTecnicaTradeContext : DbContext
    {
        //public PruebaTecnicaTradeContext(DbContextOptions<PruebaTecnicaTradeContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
             //"Data Source=SQL5046.site4now.net;" +
             //"Initial Catalog=DB_A4FD02_prueba1234567;User Id=DB_A4FD02_prueba1234567_admin;Password=d_link2010.;");
             "Data Source=.; Initial Catalog=DB_PrebatecnicaTrade; Integrated Security=True;");
            //"Data Source=sql5032.site4now.net;" +
            //    "Initial Catalog=DB_A53E0A_ConfeccionesPrueba;User Id=DB_A53E0A_ConfeccionPrueba_admin;Password=d-link2010.;");
            base.OnConfiguring(optionsBuilder);
            //Primer Migracion   Add-Migration InitialCreate

            //Despues de la primera migracion se utiliza  Update-Database
        }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
