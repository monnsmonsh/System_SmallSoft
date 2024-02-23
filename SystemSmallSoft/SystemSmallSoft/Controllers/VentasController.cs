
using Rotativa;
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
    //[Authorize(Roles = "Admin, Mostrador")]
    public class VentasController : Controller
    {
        // GET: Ventas
        private SmallSoftContext db = new SmallSoftContext();


        public ActionResult Index()
        {
            var tblVentas = db.TblVentas.Include(t => t.TblClientes);
            return View(tblVentas.ToList());
        }

        public JsonResult BuscarCliente(string term)
        {
            using(SmallSoftContext db = new SmallSoftContext())
            {
                var resultado = db.TblClientes.Where(x => x.Nombre.StartsWith(term))
                    .Select(x => x.Nombre).Take(5).ToList();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }


        //db incializamos 
        SmallSoftContext detalleVenta = null;
        // GET: Generos/Details/5
        public ActionResult DetailsVenta(int? id)
        {
            detalleVenta = new SmallSoftContext();
            List<TblDetalleVenta> detalle = detalleVenta.TblDetalleVentas.Where(m => m.VentaID == id).ToList();
            return View(detalle);

            //var DetalleVentas = db.TblDetalleVentas.Where(x => x.VentaID == id);
            //return View(DetalleVentas.ToList());

        }






        //Método de acción que consulta el detalle de una venta y lo envía a la vista.
        public ActionResult ReportVenta(int id)
        {
            //Consultamos la venta especificada en el id.
            var venta = db.TblVentas.Find(id);
            return View(venta);
            //return new ActionAsPdf(ReportVenta);
        }
        public ActionResult PrintAll(int id)
        {
            //var venta = db.TblVentas.Find(id);
            var q = new ActionAsPdf("ReportVenta", new { @id = id });
            return q;
        }



        //public ActionResult Invoice_in_pdf(int a)
        //{
        //    dynamic model = new ExpandoObject();
        //    model.SingleMystock = db.MyStocks.Where(x => x.invoice == a).Take(1).ToList();
        //    model.items = db.MyStocks.Where(c => c.invoice == a).ToList();
        //    model.total = from Total_Stock_Order in db.Total_Stock_Orders.Where(d => d.invoice_no_t == a).ToList() select Total_Stock_Order;

        //    return View(model);
        //}
        //public ActionResult PrintAll(int a)
        //{
        //    var q = new ActionAsPdf("Invoice_in_pdf", new { @a = a });
        //    return q;
        //}


        // GET: Ventas
        [HttpGet]
        public ActionResult NewVenta()
        {
            VentaView ventaView = new VentaView();
            ventaView.TblClientes = new ClienteVenta();
            ventaView.TblProductos = new List<ProductoVenta>();

            //Variable de Seccion
            Session["VentaView"] = ventaView;

            //var list = db.TblClientes.ToList();
            //ViewBag.ClienteID = new SelectList(list, "ClienteID", "Nombre");

            var list = db.TblClientes.ToList();
            list.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "FullName");

            return View(ventaView);
        }

        [HttpPost]
        public ActionResult NewVenta(VentaView ventaView)
        {

            ventaView = Session["VentaView"] as VentaView;

            //int clienteID = int.Parse(Request["ClienteID"]);
            var clienteID = int.Parse(Request["ClienteID"]);
            if (clienteID == 0)
            {
                var listC = db.TblClientes.ToList();
                listC.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
                listC = listC.OrderBy(c => c.FullName).ToList();
                ViewBag.ClienteID = new SelectList(listC, "ClienteID", "FullName");

                ViewBag.Error = "Debes seleccionar un Cliente";

                return View(ventaView);
            }




            //DateTime dateVenta = Convert.ToDateTime(Request["TblClientes.FechaAlta"]); DateTime.Now;
            //string indent = Convert.ToString(db.TblVentas.Last<TblVenta>().VentaID + 1);

            //----Construccion del Folio
            int idFolio = db.TblVentas.ToList().Select(o => o.VentaID).Max();
            if (idFolio == null)
            {
                idFolio = 0;
            }
            else
            {
                idFolio = db.TblVentas.ToList().Select(o => o.VentaID).Max();
            }
            //int idFolio = db.TblVentas.ToList().Select(o => o.VentaID).Max();
            string folio = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month);


            ////
            //int Cantidad = int.Parse(Request["Cantidad"]);
            //double subTotal = db.TblProductoes.Sum(x => x.PrecioUnitario * Cantidad);
            //Calculamos el IVA.
            //double iva = subTotal * 0.16;
            //Calculamos el Total.
            //double total = iva + subTotal;
            //////

            TblVenta newVenta = new TblVenta
            {
                ClienteID = clienteID,
                FechaAlta = DateTime.Now,
                //Generado el Folio
                Folio = folio + 0000 +Convert.ToString(idFolio + 1)
                //
                //SubTotal = subTotal,
                //IVA = iva,
                //Total = total


            };
            db.TblVentas.Add(newVenta);
            db.SaveChanges();


            //toma la ultima venta
            int lastVentaID = db.TblVentas.ToList().Select(o => o.VentaID).Max();

            //se crea un ciclo para cada elemento del detalle
            foreach (ProductoVenta item in ventaView.TblProductos)
            {
                var detail = new TblDetalleVenta()
                {
                    VentaID = lastVentaID,
                    ProductoID = item.ProductoID,
                    Cantidad = item.Cantidad,
                    PrecioUnitario= item.PrecioUnitario,
                    Total = item.SubTotal

                };
                db.TblDetalleVentas.Add(detail);
            }
            db.SaveChanges();

            ventaView = Session["VentaView"] as VentaView;
            //datos utilizados en la seccion de venta

            var list = db.TblClientes.ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "Nombre");

            //return View(ventaView);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddProducto()
        {
            //var listp = db.TblProductoes.ToList();
            //ViewBag.ProductoID = new SelectList(listp, "ProductoID", "Descripcion");

            var listp = db.TblProductoes.ToList();
            listp.Add(new ProductoVenta { ProductoID = 0, Descripcion = "[Seleccione un producto]" });
            listp = listp.OrderBy(p => p.Descripcion).ToList();
            ViewBag.ProductoID = new SelectList(listp, "ProductoID", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult AddProducto(ProductoVenta productoVenta)
        {
            var ventaView = Session["VentaView"] as VentaView;
            var productoID = int.Parse(Request["ProductoID"]);
            var product = db.TblProductoes.Find(productoID);

            //productoVenta = new ProductoVenta()
            //{
            //    ProductoID = product.ProductoID,
            //    Descripcion = product.Descripcion,
            //    PrecioUnitario = product.PrecioUnitario,
            //    Cantidad = int.Parse(Request["Cantidad"])
            //};

            productoVenta = ventaView.TblProductos.Find(p => p.ProductoID == productoID);
            if (productoVenta == null)
            {
                productoVenta = new ProductoVenta
                {
                    ProductoID = product.ProductoID,
                    Descripcion = product.Descripcion,
                    PrecioUnitario = product.PrecioUnitario,
                    Cantidad = int.Parse(Request["Cantidad"])
                };
                ventaView.TblProductos.Add(productoVenta);
            }
            else
            {
                productoVenta.Cantidad += int.Parse(Request["Cantidad"]);
            }

            //ventaView.TblProductos.Add(productoVenta);

            //datos utilizados en la seccion de venta
            //var list = db.TblClientes.ToList();
            //ViewBag.ClienteID = new SelectList(list, "ClienteID", "Nombre");
            var list = db.TblClientes.ToList();
            list.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "FullName");

            var listp = db.TblProductoes.ToList();
            ViewBag.ProductoID = new SelectList(listp, "ProductoID", "Nombre");

            return View("NewVenta", ventaView);
        }

        public ActionResult Delete(int ProductoID)
        {
            var ventaView = Session["VentaView"] as VentaView;

            ventaView.TblProductos.RemoveAt((ProductoID));

            return View("NewVenta", ventaView);
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