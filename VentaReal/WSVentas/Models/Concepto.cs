using System;
using System.Collections.Generic;

#nullable disable

namespace WSVentas.Models
{
    public partial class Concepto
    {
        public decimal Id { get; set; }
        public decimal IdVenta { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal Importe { get; set; }
        public decimal IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}
