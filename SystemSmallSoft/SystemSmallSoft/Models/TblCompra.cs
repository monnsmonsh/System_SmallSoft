using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblCompra
    {
        //Propiedades
        [Key]
        public int CompraID { get; set; }//Clave Primaria
        //public double Total { get; set; }


        [Display(Name = "Nombre del Proveedor")]
        public int ProveedorID { get; set; }//Atributo de llave foranea

        public string Folio { get; set; }
        //[Display(Name = "Forma de Pago")]
        //public int ModoPagoID { get; set; }//Atributo de llave foranea

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaCompra { get; set; }




        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual TblProveedor TblProveedores { get; set; }
        public virtual TblProducto TblProductoes { get; set; }

        //
        /// Envio de atributos a los Models apuntados
        //
        //public virtual ICollection<TblDetalleCompra> TblDetalleCompras { get; set; }
    }
}