using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class Estado
    {
        public int EstadoID { get; set; }//Clave Primaria
        public string Nombre { get; set; }

        //Atributo de navegacion que apunta al modelo de Productos
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}