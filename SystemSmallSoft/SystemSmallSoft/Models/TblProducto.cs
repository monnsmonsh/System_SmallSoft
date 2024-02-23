using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblProducto
    {
        //Constructor
        //public TblProductos()
        //{
        //    this.TblDetalleVenta = new HashSet<TblDetalleVentas>();
        //}

        //Propiedades
        [Key]
        public int ProductoID { get; set; }//Clave Primaria


        public byte[] IMG { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string SKU { get; set; }


        [StringLength(60, MinimumLength = 10)]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Descripcion { get; set; }
        

        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }//Atributo de llave foranea


        [Display(Name = "Precio")]
        [RegularExpression("[0-9]*", ErrorMessage = "Solo permite números")]
        public double PrecioUnitario { get; set; }


        [Display(Name = "Precio de Compra")]
        [RegularExpression("[0-9]*", ErrorMessage = "Solo permite números")]
        public double PrecioCompra { get; set; }



        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression("[0-9]*", ErrorMessage = "Solo permite números")]
        public double Stock { get; set; }


        
        public bool Status { get; set; }


        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual TblCategoria TblCategorias { get; set; }


        //
        /// Envio de atributos a los Models apuntados
        //
        public virtual ICollection<TblProveedorProducto> TblProveedorProductos { get; set; }
        public virtual ICollection<TblDetalleVenta> TblDetalleVentas { get; set; }

    }
}