using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class Localidad
    {
        public int LocalidadID { get; set; }//Clave Primaria
        public string Nombre { get; set; }
        public int MunicipioID { get; set; }//FK

        //
        /// Atributos obtenidos de los Models apuntados
        //
        public virtual Municipio Municipios { get; set; }

    }
}