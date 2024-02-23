using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class TblModoPago
    {
        [Key]
        public int ModoPagoID { get; set; }//Clave Primaria


        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        public bool Status { get; set; }




        //Atributo de navegacion que apunta al modelo de Productos
        public virtual ICollection<TblVenta> TblVentas { get; set; }
    }
}