using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblVenta
    {
        //Propiedades
        [Key]
        public int VentaID { get; set; }//Clave Primaria
        //public double Total { get; set; }


        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }//Atributo de llave foranea

        public string Folio { get; set; }
        //[Display(Name = "Forma de Pago")]
        //public int ModoPagoID { get; set; }//Atributo de llave foranea

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaAlta { get; set; }

        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }



        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual TblCliente TblClientes { get; set; }
        public virtual TblModoPago TblModoPago { get; set; }

        //
        /// Envio de atributos a los Models apuntados
        //
        public virtual ICollection<TblDetalleVenta> TblDetalleVentas { get; set; }
    }
}