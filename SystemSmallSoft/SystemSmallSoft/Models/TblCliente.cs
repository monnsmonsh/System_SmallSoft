using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSmallSoft.Models
{
    public class TblCliente
    {
        //Constructor
        //public TblCliente()
        //{
        //    this.TblVentas = new HashSet<TblVentas>();

        //    //this.VentaViewModels = new HashSet<VentaViewModels>();
        //}

        //Propiedades
        [Key]
        public int ClienteID { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression("[A-Za-z _]*", ErrorMessage = "Solo se permite letras")]
        public string Nombre { get; set; }


        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Solo se permite letras")]
        public string ApPaterno { get; set; }


        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Solo se permite letras")]
        public string ApMaterno { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string RFC { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion { get; set; }


        [RegularExpression("[0-9]*", ErrorMessage = "Solo permite números")]
        [StringLength(10, ErrorMessage = "Solo diez caracteres")]
        [MinLength(10, ErrorMessage = "Deben de ser 10 Caracteres")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Telefono { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Correo { get; set; }

        public bool Status { get; set; }

        //fulname
        //[NotMapped]
        public string FullName { get { return string.Format("{0} {1}", Nombre, ApPaterno);}  }


        //Atributo de navegacion que apunta al modelo de Ventas
        public virtual ICollection<TblVenta> TblVentas { get; set; }
    }
}