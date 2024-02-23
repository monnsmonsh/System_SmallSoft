using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblPurchase
    {
        //Propiedades
        [Key]
        public int PurchaseID { get; set; }//Clave Primaria


        [Display(Name = "Nombre del Proveedor")]
        public string PurchaseProd { get; set; }//Clave Primaria

        public string PurchaseCant { get; set; }//Clave Primaria

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaCompra { get; set; }
    }
}