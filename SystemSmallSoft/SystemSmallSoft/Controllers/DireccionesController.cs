using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemSmallSoft.Models;

namespace SystemSmallSoft.Controllers
{
    
    public class DireccionesController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();
        // GET: Direcciones
        public ActionResult Index()
        {
            SmallSoftContext db = new SmallSoftContext();
            ViewBag.EstadoList = new SelectList(GetEstadoList(), "EstadoID", "Nombre");
            return View();
        }
        public List<Estado> GetEstadoList()
        {
            SmallSoftContext db = new SmallSoftContext();
            List<Estado> estados = db.Estadoes.ToList();
            return estados;
        }
        public ActionResult GetMunicipioList(int EstadoID)
        {
            SmallSoftContext db = new SmallSoftContext();
            List<Municipio> selectList = db.Municipios.Where(x => x.EstadoID == EstadoID).ToList();
            ViewBag.Slist = new SelectList("MunicipioID", "Nombre");
            return PartialView("DisplayMunicipio");
        }

    }
}