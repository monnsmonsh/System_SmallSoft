using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace SystemSmallSoft.Models
{
    public class TblProveedor
    {
        [Key]
        public int ProveedorID { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression("[A-Za-z _]*", ErrorMessage = "Solo se permite letras")]
        public string RazonSocial { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(13, ErrorMessage = "Solo admite 13 digitos")]
        [MinLength(11, ErrorMessage = "Deben de ser 11 digitos minimos")]
        public string RUC { get; set; }


        
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Marca { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion { get; set; }


        [RegularExpression("[0-9]*", ErrorMessage = "Solo permite números")]
        [StringLength(10, ErrorMessage = "Solo diez caracteres")]
        [MinLength(10, ErrorMessage = "Deben de ser 10 Caracteres")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Telefono { get; set; }

        [RegularExpression("[0-9]*", ErrorMessage = "Solo permite números")]
        [StringLength(10, ErrorMessage = "Solo diez caracteres")]
        [MinLength(10, ErrorMessage = "Deben de ser 10 Caracteres")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression("[A-Za-z _]*", ErrorMessage = "Solo se permite letras")]
        public string Representante { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Email { get; set; }

        public string URL { get; set; }




        //
        /// Envio de atributos a los Models apuntados
        //
        public virtual ICollection<TblProveedorProducto> TblProveedorProductos { get; set; }

    }
}