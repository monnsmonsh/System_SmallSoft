using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class Municipio
    {
        public int MunicipioID { get; set; }//Clave Primaria
        public string Nombre { get; set; }
        public int EstadoID { get; set; }//FK

        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual Estado Estados { get; set; }

        //
        /// Envio de atributos a los Models apuntados
        //
        public virtual ICollection<Localidad> Localidades { get; set; }

    }
}