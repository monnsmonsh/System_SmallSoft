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
    
    [Authorize(Roles = "Admin,Mostrador")]
    public class ClientesController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.TblClientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCliente tblCliente = db.TblClientes.Find(id);
            if (tblCliente == null)
            {
                return HttpNotFound();
            }
            return View(tblCliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
            //return PartialView();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,Nombre,ApPaterno,ApMaterno,RFC,Direccion,Telefono,Correo,Status")] TblCliente tblCliente)
        {
            if (ModelState.IsValid)
            {
                db.TblClientes.Add(tblCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCliente tblCliente = db.TblClientes.Find(id);
            if (tblCliente == null)
            {
                return HttpNotFound();
            }
            return View(tblCliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nombre,ApPaterno,ApMaterno,RFC,Direccion,Telefono,Correo,Status")] TblCliente tblCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCliente tblCliente = db.TblClientes.Find(id);
            if (tblCliente == null)
            {
                return HttpNotFound();
            }
            return View(tblCliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCliente tblCliente = db.TblClientes.Find(id);
            db.TblClientes.Remove(tblCliente);
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
