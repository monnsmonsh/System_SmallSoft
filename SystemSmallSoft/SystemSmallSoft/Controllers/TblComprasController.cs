using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemSmallSoft.Models;

namespace SystemSmallSoft.Controllers
{
    public class TblComprasController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();

        // GET: TblCompras
        public ActionResult Index()
        {
            var tblCompras = db.TblCompras.Include(t => t.TblProveedores);
            return View(tblCompras.ToList());
        }

        // GET: TblCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCompra tblCompra = db.TblCompras.Find(id);
            if (tblCompra == null)
            {
                return HttpNotFound();
            }
            return View(tblCompra);
        }

        // GET: TblCompras/Create
        public ActionResult Create()
        {
            ViewBag.ProveedorID = new SelectList(db.TblProveedors, "ProveedorID", "RazonSocial");
            return View();
        }

        // POST: TblCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompraID,ProveedorID,Folio,FechaCompra")] TblCompra tblCompra)
        {
            if (ModelState.IsValid)
            {
                db.TblCompras.Add(tblCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProveedorID = new SelectList(db.TblProveedors, "ProveedorID", "RazonSocial", tblCompra.ProveedorID);
            return View(tblCompra);
        }

        // GET: TblCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCompra tblCompra = db.TblCompras.Find(id);
            if (tblCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProveedorID = new SelectList(db.TblProveedors, "ProveedorID", "RazonSocial", tblCompra.ProveedorID);
            return View(tblCompra);
        }

        // POST: TblCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompraID,ProveedorID,Folio,FechaCompra")] TblCompra tblCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedorID = new SelectList(db.TblProveedors, "ProveedorID", "RazonSocial", tblCompra.ProveedorID);
            return View(tblCompra);
        }

        // GET: TblCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCompra tblCompra = db.TblCompras.Find(id);
            if (tblCompra == null)
            {
                return HttpNotFound();
            }
            return View(tblCompra);
        }

        // POST: TblCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCompra tblCompra = db.TblCompras.Find(id);
            db.TblCompras.Remove(tblCompra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
