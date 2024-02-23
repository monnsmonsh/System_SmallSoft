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
    [Authorize(Roles = "Admin,Almacen")]
    public class ProveedoresController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();

        // GET: Proveedores
        public ActionResult Index()
        {
            return View(db.TblProveedors.ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedor tblProveedor = db.TblProveedors.Find(id);
            if (tblProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedor);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProveedorID,RazonSocial,RUC,Marca,Direccion,Telefono,Celular,Representante,Email,URL")] TblProveedor tblProveedor)
        {
            if (ModelState.IsValid)
            {
                db.TblProveedors.Add(tblProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblProveedor);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedor tblProveedor = db.TblProveedors.Find(id);
            if (tblProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedor);
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProveedorID,RazonSocial,RUC,Marca,Direccion,Telefono,Celular,Representante,Email,URL")] TblProveedor tblProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblProveedor);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedor tblProveedor = db.TblProveedors.Find(id);
            if (tblProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedor);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblProveedor tblProveedor = db.TblProveedors.Find(id);
            db.TblProveedors.Remove(tblProveedor);
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
