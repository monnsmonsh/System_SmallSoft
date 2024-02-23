using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SystemSmallSoft.Models;

namespace SystemSmallSoft.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();

        // GET: Productos
        public ActionResult Index()
        {
            var tblProductos = db.TblProductoes.Include(t => t.TblCategorias);
            return View(tblProductos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProducto tblProducto = db.TblProductoes.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // GET: Productos/Create
        [Authorize(Roles = "Admin,Almacen")]
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.TblCategorias, "CategoriaID", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoID,IMG,SKU,Descripcion,PrecioUnitario,Stock,CategoriaID,Status")] TblProducto tblProducto)
        {
            //
            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase.ContentLength == 0)
            {
                ModelState.AddModelError("Imagen", "El necesario seleccionar una imagen");
            }
            else
            {
                if (FileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage image = new WebImage(FileBase.InputStream);
                    tblProducto.IMG = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "El sistema solo admite formato jpg");
                }

            }



            if (ModelState.IsValid)
            {
                db.TblProductoes.Add(tblProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.TblCategorias, "CategoriaID", "Nombre", tblProducto.CategoriaID);
            return View(tblProducto);
        }

        // GET: Productos/Edit/5
        [Authorize(Roles = "Admin,Almacen")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProducto tblProducto = db.TblProductoes.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.TblCategorias, "CategoriaID", "Nombre", tblProducto.CategoriaID);
            return View(tblProducto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoID,IMG,SKU,Descripcion,PrecioUnitario,Stock,CategoriaID,Status")] TblProducto tblProducto)
        {
            //
            //byte[] imagenActual = null;
            TblProducto _tblProductos = new TblProducto();

            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.ContentLength == 0)
            {
                _tblProductos = db.TblProductoes.Find(tblProducto.ProductoID);
                tblProducto.IMG = _tblProductos.IMG;
            }
            else
            {
                if (FileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage image = new WebImage(FileBase.InputStream);
                    tblProducto.IMG = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "El sistema solo admite formato jpg");
                }
            }

     

            if (ModelState.IsValid)
            {
                //
                db.Entry(_tblProductos).State = EntityState.Detached;

                db.Entry(tblProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.TblCategorias, "CategoriaID", "Nombre", tblProducto.CategoriaID);
            return View(tblProducto);
        }

        // GET: Productos/Delete/5
        [Authorize(Roles = "Admin,Almacen")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProducto tblProducto = db.TblProductoes.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblProducto tblProducto = db.TblProductoes.Find(id);
            db.TblProductoes.Remove(tblProducto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getImage(int id)
        {
            TblProducto tblProducto = db.TblProductoes.Find(id);
            byte[] byteImage = tblProducto.IMG;

            MemoryStream memoryStrem = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStrem);

            memoryStrem = new MemoryStream();
            image.Save(memoryStrem, ImageFormat.Jpeg);
            memoryStrem.Position = 0;

            return File(memoryStrem, "image/jpg");
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
