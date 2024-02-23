using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class VentaView
    {
        public ClienteVenta TblClientes { get; set; }
        public ProductoVenta Titles { get; set; }
        public List<ProductoVenta> TblProductos { get; set; }
    }
}