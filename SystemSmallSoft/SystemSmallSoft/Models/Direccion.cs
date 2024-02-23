using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class Direccion
    {
        private SmallSoftContext db = new SmallSoftContext();

        public List<Estado> BindEstado()
        {
            this.db.Configuration.ProxyCreationEnabled = false;

            List<Estado> lstEstados = new List<Estado>();
            try
            {
                lstEstados = db.Estadoes.ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstEstados;
        }

        public List<Municipio> BindMunicipio(int EstadoID)
        {
            List<Municipio> lstMunicipio = new List<Municipio>();
            try
            {
                this.db.Configuration.ProxyCreationEnabled = false;

                lstMunicipio = db.Municipios.Where(a => a.EstadoID == EstadoID).ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstMunicipio;
        }

        public List<Localidad> BindLocalidad(int MunicipioID)
        {
            List<Localidad> lstLocalidad = new List<Localidad>();
            try
            {
                this.db.Configuration.ProxyCreationEnabled = false;

                lstLocalidad = db.Localidads.Where(a => a.MunicipioID == MunicipioID).ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstLocalidad;
        }
    }
}