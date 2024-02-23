using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SystemSmallSoft.Models;

namespace SystemSmallSoft.Controllers
{
    [RoutePrefix("Models/Entidad")]
    public class EntidadesController : Controller
    {
        Direccion objCasc = new Direccion();
        [HttpGet]
        [Route("EstadoDetails")]
        public List<Estado> BindEstadoDetails()
        {
            List<Estado> estadoDetails = new List<Estado>();
            try
            {
                estadoDetails = objCasc.BindEstado();
            }
            catch (ApplicationException ex)
            {
                    throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            
            }

            return estadoDetails;

        }

        [HttpGet]
        [Route("MunicipioDetails")]
        public List<Municipio> BindMunicipioDetails(int EstadoId)
        {

            List<Municipio> municipioDetail = new List<Municipio>();
            try
            {
                municipioDetail = objCasc.BindMunicipio(EstadoId);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return municipioDetail;
        }

        [HttpGet]
        [Route("LocalidadDetails")]
        public List<Localidad> BindCityDetails(int MunicipioId)
        {
            List<Localidad> localidadDetail = new List<Localidad>();
            try
            {
                localidadDetail = objCasc.BindLocalidad(MunicipioId);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
                
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return localidadDetail;
        }

        public ActionResult Details()
        {
            return View();
        }


    }
}