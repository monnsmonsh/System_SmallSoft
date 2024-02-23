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
    public class CategoriasController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.TblCategorias.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCategoria tblCategoria = db.TblCategorias.Find(id);
            if (tblCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tblCategoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaID,Nombre,Status")] TblCategoria tblCategoria)
        {
            if (ModelState.IsValid)
            {
                db.TblCategorias.Add(tblCategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCategoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCategoria tblCategoria = db.TblCategorias.Find(id);
            if (tblCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tblCategoria);
        }

        // POST: Categorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaID,Nombre,Status")] TblCategoria tblCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCategoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCategoria tblCategoria = db.TblCategorias.Find(id);
            if (tblCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tblCategoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCategoria tblCategoria = db.TblCategorias.Find(id);
            db.TblCategorias.Remove(tblCategoria);
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
