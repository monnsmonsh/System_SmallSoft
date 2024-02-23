using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemSmallSoft.Models;
using Rotativa;

namespace SystemSmallSoft.Controllers
{

    public class ReportesController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();

        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        //Reportes Clientes
        public ActionResult ReporteClientes()
        {
            return View(db.TblClientes.ToList());
        }
        public ActionResult ReporteClientesPrint()
        {
            return new ActionAsPdf("ReporteClientes", new { nombre = "Reporte" })
            { FileName = "ClientesReportes.pdf" };
        }

        //Reporte Proveedores
        public ActionResult ReporteProveedores()
        {
            return View(db.TblProveedors.ToList());
        }
        public ActionResult ReporteProveedoresPrint()
        {
            return new ActionAsPdf("ReporteProveedores", new { nombre = "Reporte" })
            { FileName = "ProveedoresReportes.pdf" };
        }

        //Reporte Productos
        [HttpGet]
        public ActionResult ReporteProductos()
        {
            var tblProductos = db.TblProductoes.Include(t => t.TblCategorias);
            return View(tblProductos.ToList());
        }
        public ActionResult ReporteProductosPrint()
        {
            return new ActionAsPdf("ReporteProductos", new { nombre = "Reporte" })
            { FileName = "ProductosReportes.pdf" };
        }


        //Reporte Ventas
        public ActionResult ReporteVentas()
        {
            var tblVentas = db.TblVentas.Include(t => t.TblClientes);
            return View(tblVentas.ToList());
        }
        public ActionResult ReporteVentasPrint()
        {
            return new ActionAsPdf("ReporteVentas", new { nombre = "Reporte" })
            { FileName = "VentasReportes.pdf" };
        }



    }
}