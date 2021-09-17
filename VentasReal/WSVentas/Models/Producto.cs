using System;
using System.Collections.Generic;

#nullable disable

namespace WSVentas.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Conceptos = new HashSet<Concepto>();
        }

        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal Costo { get; set; }

        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
