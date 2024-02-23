using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblProveedorProducto
    {
        [Key]
        public int ProveedorProductoID { get; set; }


        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [Display(Name = "Precio de Compra")]
        public decimal Price { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de compra")]
        public DateTime LastBuy { get; set; }

        [Display(Name = "Cantidad Compra")]
        public int cantidad { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorID { get; set; }

        [Display(Name = "Producto")]
        public int ProductoID { get; set; }



        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual TblProveedor TblProveedores { get; set; }
        public virtual TblProducto TblProductos { get; set; }
    }
}