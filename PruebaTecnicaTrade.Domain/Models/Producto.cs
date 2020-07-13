﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaTecnicaTrade.Domain.Models
{
    public class Producto
    {
        [Key,Required]
        public Guid SKU { get; set; }
        [Required]
        public Guid TiendaId {get; set;}
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Imagen { get; set; }

        public virtual Tienda Tienda { get; set; }

    }
}
