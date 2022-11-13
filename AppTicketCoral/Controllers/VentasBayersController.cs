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
    public class VentasBayersController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();

        // GET: VentasBayers
        public ActionResult Index()
        {
            return View(db.VentasBayers.ToList());
        }

        // GET: VentasBayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasBayer ventasBayer = db.VentasBayers.Find(id);
            if (ventasBayer == null)
            {
                return HttpNotFound();
            }
            return View(ventasBayer);
        }

        // GET: VentasBayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentasBayers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,NoTicket,NoEmpleado,Codigo,Costo,Estado,Cantidad,Operador,Impuesto,Subsidio,Site")] VentasBayer ventasBayer)
        {
            if (ModelState.IsValid)
            {
                db.VentasBayers.Add(ventasBayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ventasBayer);
        }

        // GET: VentasBayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasBayer ventasBayer = db.VentasBayers.Find(id);
            if (ventasBayer == null)
            {
                return HttpNotFound();
            }
            return View(ventasBayer);
        }

        // POST: VentasBayers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,NoTicket,NoEmpleado,Codigo,Costo,Estado,Cantidad,Operador,Impuesto,Subsidio,Site")] VentasBayer ventasBayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventasBayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ventasBayer);
        }

        // GET: VentasBayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasBayer ventasBayer = db.VentasBayers.Find(id);
            if (ventasBayer == null)
            {
                return HttpNotFound();
            }
            return View(ventasBayer);
        }

        // POST: VentasBayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentasBayer ventasBayer = db.VentasBayers.Find(id);
            db.VentasBayers.Remove(ventasBayer);
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
