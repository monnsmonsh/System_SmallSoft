using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class ProductoVenta : TblProducto
    {
        public int Cantidad { set; get; }

        public double SubTotal { get { return PrecioUnitario * Cantidad; } }

        //public double Total { get { return Total  + Partial; } }

        //public double calcularTotal()
        //{
        //    return (double)(Producto.PrecioUnitario * Cantidad);
        //}

    }


}