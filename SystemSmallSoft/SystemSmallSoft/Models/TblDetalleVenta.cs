using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblDetalleVenta
    {
        [Key]
        public int DetalleVentaID { get; set; }//Clave Primaria
        //public int NumFacturaID { get; set; }//Atributo de llave foranea


        public int VentaID { get; set; }//Atributo de llave foranea


        [Display(Name = "Producto")]
        public int ProductoID { get; set; }//Atributo de llave foranea

        [Display(Name = "Precio")]
        public double PrecioUnitario { get; set; }

        public int Cantidad { get; set; }

        //public double SubTotal { get; set; }
        public double Total { get; set; }
        //public double Descuento { get; set; }

        //Atributo de navegacion que apunta al modelo de Cliente
        //public virtual Factura Factura { get; set; }


        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual TblVenta TblVentas { get; set; }
        public virtual TblProducto TblProductos { get; set; }
    }
}