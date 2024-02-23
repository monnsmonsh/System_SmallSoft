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
    public class OrderController : Controller
    {
        SmallSoftContext db = new SmallSoftContext();
        // GET: Order
        public ActionResult NewOrder()
        {
            VentaView ventaView = new VentaView();
            ventaView.TblClientes = new ClienteVenta();
            ventaView.TblProductos = new List<ProductoVenta>();

            Session["ventaView"] = ventaView;

            var list = db.TblClientes.ToList();
            list.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "FullName");

            return View(ventaView);

        }
        [HttpPost]
        public ActionResult NewOrder(VentaView ventaView)
        {
            ventaView = Session["ventaView"] as VentaView;

            var clienteID = int.Parse(Request["ClienteID"]);
            if (clienteID == 0)
            {
                var list = db.TblClientes.ToList();
                list.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
                list = list.OrderBy(c => c.FullName).ToList();
                ViewBag.ClienteID = new SelectList(list, "ClienteID", "FullName");

                ViewBag.Error = "Debes seleccionar un Cliente";

                return View(ventaView);
            }

            var cliente = db.TblClientes.Find(clienteID);
            if (cliente == null)
            {
                var list = db.TblClientes.ToList();
                list.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
                list = list.OrderBy(c => c.FullName).ToList();
                ViewBag.ClienteID = new SelectList(list, "ClienteID", "FullName");

                ViewBag.Error = "Debes ingresar Detalle";

                return View(ventaView);
            }

            if (ventaView.TblProductos.Count == 0)
            {
                var list = db.TblClientes.ToList();
                list.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
                list = list.OrderBy(c => c.FullName).ToList();
                ViewBag.ClienteID = new SelectList(list, "ClienteID", "FullName");

                ViewBag.Error = "Cliente no Existente";
                return View(ventaView);
            }



            int VentaID = 0;
            
            //----Construccion del Folio
            int idFolioNum = db.TblVentas.ToList().Select(o => o.VentaID).Max();
            string folioF = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + 0000 + Convert.ToString(idFolioNum + 1);


            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var newVenta = new TblVenta
                    {
                        ClienteID = clienteID,
                        FechaAlta = DateTime.Now,
                        //Generado el Folio
                        Folio = folioF

                    };
                    db.TblVentas.Add(newVenta);
                    db.SaveChanges();

                    //toma la ultima venta
                    var lastVentaID = db.TblVentas.ToList().Select(o => o.VentaID).Max();
                    //se crea un ciclo para cada elemento del detalle
                    foreach (ProductoVenta item in ventaView.TblProductos)
                    {
                        var detail = new TblDetalleVenta()
                        {
                            VentaID = lastVentaID,
                            ProductoID = item.ProductoID,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.PrecioUnitario,
                            Total = item.SubTotal

                        };
                        db.TblDetalleVentas.Add(detail);
                        db.SaveChanges();//agregado

                        
                    }
                    //db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.Error = "ERROR: " + ex.Message;
                    var listC = db.TblClientes.ToList();
                    listC.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
                    listC = listC.OrderBy(c => c.FullName).ToList();
                    ViewBag.ClienteID = new SelectList(listC, "ClienteID", "FullName");

                    return View(ventaView);

                }


            }


            ViewBag.Message = string.Format("La orden: {0}, grabada ok",folioF);

            var listCl = db.TblClientes.ToList();
            listCl.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
            listCl = listCl.OrderBy(c => c.FullName).ToList();
            ViewBag.ClienteID = new SelectList(listCl, "ClienteID", "FullName");

            ventaView = new VentaView();
            ventaView.TblClientes = new ClienteVenta();
            ventaView.TblProductos = new List<ProductoVenta>();

            Session["ventaView"] = ventaView;

            return View();

        }
        public ActionResult AddProducto()
        {
            var list = db.TblProductoes.ToList();
            list.Add(new ProductoVenta { ProductoID = 0, Descripcion = "[Seleccione un producto]" });
            list = list.OrderBy(p => p.Descripcion).ToList();
            ViewBag.ProductoID = new SelectList(list, "ProductoID", "Descripcion");

            return View();

        }
        [HttpPost]
        public ActionResult AddProducto(ProductoVenta productoVenta)
        {
            var ventaView = Session["ventaView"] as VentaView;

            var productID = int.Parse(Request["ProductoID"]);
            if(productID == 0)
            {
                var list = db.TblProductoes.ToList();
                list.Add(new ProductoVenta { ProductoID = 0, Descripcion = "[Seleccione un producto]" });
                list = list.OrderBy(p => p.Descripcion).ToList();
                ViewBag.ProductoID = new SelectList(list, "ProductoID", "Descripcion");

                ViewBag.Error = "Debes seleccionar un Producto";

                return View(productoVenta);
            }

            var product = db.TblProductoes.Find(productID);
            if (product == null)
            {
                var list = db.TblProductoes.ToList();
                list.Add(new ProductoVenta { ProductoID = 0, Descripcion = "[Seleccione un producto]" });
                list = list.OrderBy(p => p.Descripcion).ToList();
                ViewBag.ProductoID = new SelectList(list, "ProductoID", "Descripcion");

                ViewBag.Error = "El producto no existe";

                return View(productoVenta);
            }

            productoVenta = ventaView.TblProductos.Find(p => p.ProductoID == productID);
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
            

            var listC = db.TblClientes.ToList();
            listC = listC.OrderBy(c => c.FullName).ToList();
            listC.Add(new TblCliente { ClienteID = 0, Nombre = "[Seleccione un Cliente]" });
            ViewBag.ClienteID = new SelectList(listC, "ClienteID", "FullName");


            return View("NewOrder", ventaView);
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