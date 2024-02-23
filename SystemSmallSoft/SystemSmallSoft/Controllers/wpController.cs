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

using System.Net;
using System.Net.Mail;

namespace SystemSmallSoft.Controllers
{
    public class wpController : Controller
    {
        private SmallSoftContext db = new SmallSoftContext();
        // GET: wp
        public ActionResult Index()
        {
            var tblProductos = db.TblProductoes.Include(t => t.TblCategorias);
            return View(tblProductos.Take(8).ToList());
        }
        public ActionResult Servicios()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Productos()
        {
            var tblProductos = db.TblProductoes.Include(t => t.TblCategorias);
            return View(tblProductos.ToList());
        }

        public ActionResult Nosotros()
        {
            return View();
        }
        public ActionResult Contacto()
        {
            return View();
        }
        public ActionResult Contacto(SystemSmallSoft.Models.gmail model)
        {
            MailMessage mm = new MailMessage("ejemplo@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("ejemplo@gmail.com", "constraseña");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "e-mail enviado";

            return View();
        }



        //
        ///
        //
        Random rnd = new Random();

        [HttpPost]
        public JsonResult AgregaCarrito(int id, int cantidad)
        {

            //Verificamos si la variable de sesión "carrito" ya existe.
            if (Session["carrito"] == null)
            {
                //Creamos una nueva lista de objetos carritoItem
                List<CarritoItem> compras = new List<CarritoItem>();
                //Agregamos el nuevo elemento a la lista


                compras.Add(new CarritoItem(db.TblProductoes.Find(id), cantidad));
                //Guardamos a la lista en la variable de sesión
                Session["Carrito"] = compras;

            }
            else
            {

                //Si ya existe recuperamos la lista de  la variable de sesión.
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int indexExistente = getIndex(id);
                if (indexExistente == -1)
                {
                    compras.Add(new CarritoItem(db.TblProductoes.Find(id), cantidad));
                }
                else
                {
                    //Aumentamos la cantidad de ese producto en la lista
                    compras[indexExistente].Cantidad += cantidad;

                }

                Session["carrito"] = compras;


            }
            return Json(new { Response = true }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult AgregaCarrito()
        {
            return View();
        }

        //Get: Delete método de accion para eliminar un elemento del carrito
        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            //Eliminamos el producto de la lista del carrito en base a su id
            compras.RemoveAt(getIndex(id));
            return View("AgregaCarrito");

        }

        //Get:  método de accion para guardar la venta en la bd
        public ActionResult FinalizarCompra()
        {
            //Verificamos si la variable de sesión "carrito" ya existe.
            if (Session["carrito"] != null)
            {
                //Recuperamos la lista de compras almacenada en la variable de sessión
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                if (compras != null && compras.Count > 0)
                {
                    //Creamos un nuevo objeto venta y establecemos sus valores.
                    TblVenta nuevaVenta = new TblVenta();
                    nuevaVenta.ClienteID = 1;
                    nuevaVenta.Folio = Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Second) + rnd.Next(0, 500);
                    //Establecemos la fecha de la venta.
                    nuevaVenta.FechaAlta = DateTime.Now;

                    //Realizamos la sumatoria del precio del producto por la cantidad.
                    nuevaVenta.SubTotal = compras.Sum(x => x.Producto.PrecioUnitario * x.Cantidad);
                    //Calculamos el IVA.
                    nuevaVenta.IVA = nuevaVenta.SubTotal * 0.16;
                    //Calculamos el Total.
                    nuevaVenta.Total = nuevaVenta.IVA + nuevaVenta.SubTotal;
                    //Establecemos los valores de la lista de venta mediante Linq
                    nuevaVenta.TblDetalleVentas = (from Producto in compras
                                                   select new TblDetalleVenta
                                                   {
                                                       ProductoID = Producto.Producto.ProductoID,
                                                       PrecioUnitario = Producto.Producto.PrecioUnitario,
                                                       Total = (Producto.Producto.PrecioUnitario * Producto.Cantidad)
                                                   }).ToList();
                    //Agregamos el nuevo objeto venta.
                    db.TblVentas.Add(nuevaVenta);
                    //Guardamos la venta en la BD.
                    db.SaveChanges();
                }
            }

            return View();
        }

        //Método que busca en la lista de compras si ya se agregó determinado producto.
        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["Carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.ProductoID == id)
                    return i;
            }

            return -1;
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
    }
}