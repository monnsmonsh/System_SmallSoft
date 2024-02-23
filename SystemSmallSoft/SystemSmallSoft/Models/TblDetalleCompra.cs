using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblDetalleCompra
    {
        [Key]
        public int DetalleCompraID { get; set; }//Clave Primaria


        public int CompraID { get; set; }//Atributo de llave foranea


        [Display(Name = "Producto")]
        public int ProductoID { get; set; }//Atributo de llave foranea

        [Display(Name = "Precio de Compra")]
        public double PrecioCompra { get; set; }



        public int Stock { get; set; }

        public double SubTotal { get; set; }
        //public double Descuento { get; set; }

        //Atributo de navegacion que apunta al modelo de Cliente
        //public virtual Factura Factura { get; set; }


        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual TblCompra TblCompras { get; set; }
        public virtual TblProducto TblProductos { get; set; }
    }
}