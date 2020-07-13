using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaTecnicaTrade.Domain.Models
{
    public class Tienda
    {
        [Key,Required]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
