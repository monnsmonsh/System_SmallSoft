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
    public class ProveedorProductoController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();

        // GET: ProveedorProducto
        public ActionResult Index()
        {
            var tblProveedorProductoes = db.TblProveedorProductoes.Include(t => t.TblProductos).Include(t => t.TblProveedores);
            return View(tblProveedorProductoes.ToList());
        }

        // GET: ProveedorProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedorProducto tblProveedorProducto = db.TblProveedorProductoes.Find(id);
            if (tblProveedorProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedorProducto);
        }

        // GET: ProveedorProducto/Create
        public ActionResult Create()
        {
            var listProd = db.TblProductoes.ToList();
            listProd.Add(new TblProducto { ProductoID = 0, SKU = "[Seleccione un Producto]" });
            ViewBag.ProductoID = new SelectList(listProd, "ProductoID", "Descripcion");


            var listProv = db.TblProveedors.ToList();
            listProv.Add(new TblProveedor { ProveedorID = 0, RazonSocial = "[Seleccione un Proveedor]" });
            ViewBag.ProveedorID = new SelectList(listProv, "ProveedorID", "RazonSocial");

            return View();
        }

        // POST: ProveedorProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProveedorProductoID,Price,LastBuy,cantidad,ProveedorID,ProductoID")] TblProveedorProducto tblProveedorProducto)
        {
            if (ModelState.IsValid)
            {
                db.TblProveedorProductoes.Add(tblProveedorProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var listProd = db.TblProductoes.ToList();
            listProd.Add(new TblProducto { ProductoID = 0, SKU = "[Seleccione un Producto]" });
            ViewBag.ProductoID = new SelectList(listProd, "ProductoID", "Descripcion");


            var listProv = db.TblProveedors.ToList();
            listProv.Add(new TblProveedor { ProveedorID = 0, RazonSocial = "[Seleccione un Proveedor]" });
            ViewBag.ProveedorID = new SelectList(listProv, "ProveedorID", "RazonSocial");

            //ViewBag.ProductoID = new SelectList(db.TblProductoes, "ProductoID", "SKU", tblProveedorProducto.ProductoID);
            //ViewBag.ProveedorID = new SelectList(db.TblProveedors, "ProveedorID", "RazonSocial", tblProveedorProducto.ProveedorID);

            return View(tblProveedorProducto);
        }

        // GET: ProveedorProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedorProducto tblProveedorProducto = db.TblProveedorProductoes.Find(id);
            if (tblProveedorProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoID = new SelectList(db.TblProductoes, "ProductoID", "SKU", tblProveedorProducto.ProductoID);
            ViewBag.ProveedorID = new SelectList(db.TblProveedors, "ProveedorID", "RazonSocial", tblProveedorProducto.ProveedorID);
            return View(tblProveedorProducto);
        }

        // POST: ProveedorProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProveedorProductoID,Price,LastBuy,cantidad,ProveedorID,ProductoID")] TblProveedorProducto tblProveedorProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProveedorProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoID = new SelectList(db.TblProductoes, "ProductoID", "SKU", tblProveedorProducto.ProductoID);
            ViewBag.ProveedorID = new SelectList(db.TblProveedors, "ProveedorID", "RazonSocial", tblProveedorProducto.ProveedorID);
            return View(tblProveedorProducto);
        }

        // GET: ProveedorProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedorProducto tblProveedorProducto = db.TblProveedorProductoes.Find(id);
            if (tblProveedorProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedorProducto);
        }

        // POST: ProveedorProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblProveedorProducto tblProveedorProducto = db.TblProveedorProductoes.Find(id);
            db.TblProveedorProductoes.Remove(tblProveedorProducto);
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
