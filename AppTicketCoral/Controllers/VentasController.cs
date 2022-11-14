using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTicketCoral.Models;

namespace AppTicketCoral.Controllers
{
    public class VentasController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();
        List<Venta> misventasUser= new List<Venta>();


        public ActionResult Index()
        {
            return View(db.Ventas.ToList());
        }
        public ActionResult Index2()
        {
            return View(misventasUser.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        public ActionResult DetailsVentasUserform()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsVentasUserform([Bind(Include = "NoEmpleado")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                List<Venta> misventas2 = new List<Venta>();
                foreach (var ventas in db.Ventas.ToList())
                {
                    if (ventas.NoEmpleado == venta.NoEmpleado)
                    {
                        misventas2.Add(ventas);
                    }
                }
                misventasUser = misventas2;
            DetailsVentasUser();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DetailsVentasUser()
        {
            return View(misventasUser.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVentas,Fecha,Hora,NoTicket,NoEmpleado,Codigo,Costo,Estado,Cantidad,Operador,Impuesto,Subsidio,Site")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venta);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVentas,Fecha,Hora,NoTicket,NoEmpleado,Codigo,Costo,Estado,Cantidad,Operador,Impuesto,Subsidio,Site")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venta);
        }


 
        
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Ventas.Find(id);
            db.Ventas.Remove(venta);
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
