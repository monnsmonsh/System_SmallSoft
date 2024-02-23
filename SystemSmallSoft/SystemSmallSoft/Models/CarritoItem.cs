using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemSmallSoft.Models;

namespace SystemSmallSoft.Models
{
    public class CarritoItem
    {
        public TblProducto Producto;
        public int Cantidad;

        public CarritoItem()
        {

        }

        public CarritoItem(TblProducto Producto, int Cantidad)
        {
            this.Producto = Producto;
            this.Cantidad = Cantidad;
        }

        public double calcularTotal()
        {
            return (double)(Producto.PrecioUnitario * Cantidad);
        }
    }
}
