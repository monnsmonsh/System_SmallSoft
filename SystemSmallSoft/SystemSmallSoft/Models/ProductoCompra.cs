using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class ProductoCompra:TblProducto
    {
        

        //public double PrecioCompra { set; get; }

        //public int Stock { get { return Stock + Cantidad; } }

        public double SubTotal { get { return PrecioUnitario * PrecioCompra; } }

        //public double Total { get { return Total  + Partial; } }

    }
}