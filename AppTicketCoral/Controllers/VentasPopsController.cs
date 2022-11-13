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
    public class VentasPopsController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();

        // GET: VentasPops
        public ActionResult Index()
        {
            return View(db.VentasPops.ToList());
        }

        // GET: VentasPops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasPop ventasPop = db.VentasPops.Find(id);
            if (ventasPop == null)
            {
                return HttpNotFound();
            }
            return View(ventasPop);
        }

        // GET: VentasPops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentasPops/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,NoTicket,NoEmpleado,Codigo,Costo,Estado,Cantidad,Operador,Impuesto,Subsidio,Site")] VentasPop ventasPop)
        {
            if (ModelState.IsValid)
            {
                db.VentasPops.Add(ventasPop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ventasPop);
        }

        // GET: VentasPops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasPop ventasPop = db.VentasPops.Find(id);
            if (ventasPop == null)
            {
                return HttpNotFound();
            }
            return View(ventasPop);
        }

        // POST: VentasPops/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,NoTicket,NoEmpleado,Codigo,Costo,Estado,Cantidad,Operador,Impuesto,Subsidio,Site")] VentasPop ventasPop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventasPop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ventasPop);
        }

        // GET: VentasPops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasPop ventasPop = db.VentasPops.Find(id);
            if (ventasPop == null)
            {
                return HttpNotFound();
            }
            return View(ventasPop);
        }

        // POST: VentasPops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentasPop ventasPop = db.VentasPops.Find(id);
            db.VentasPops.Remove(ventasPop);
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
