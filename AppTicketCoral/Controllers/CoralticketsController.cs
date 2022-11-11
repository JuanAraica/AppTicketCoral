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
    public class CoralticketsController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();

        // GET: Coraltickets
        public ActionResult Index()
        {
            return View(db.Coraltickets.ToList());
        }

        // GET: Coraltickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coralticket coralticket = db.Coraltickets.Find(id);
            if (coralticket == null)
            {
                return HttpNotFound();
            }
            return View(coralticket);
        }

        // GET: Coraltickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coraltickets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTicket,Usuario,Operacion,TipoConsulta,Descripcion,Evidencia1,Evidencia2,Evidencia3,Fecha,Hora,Estado,Observacion,TIManager")] Coralticket coralticket)
        {
            if (ModelState.IsValid)
            {
                db.Coraltickets.Add(coralticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coralticket);
        }

        // GET: Coraltickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coralticket coralticket = db.Coraltickets.Find(id);
            if (coralticket == null)
            {
                return HttpNotFound();
            }
            return View(coralticket);
        }

        // POST: Coraltickets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTicket,Usuario,Operacion,TipoConsulta,Descripcion,Evidencia1,Evidencia2,Evidencia3,Fecha,Hora,Estado,Observacion,TIManager")] Coralticket coralticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coralticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coralticket);
        }

        // GET: Coraltickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coralticket coralticket = db.Coraltickets.Find(id);
            if (coralticket == null)
            {
                return HttpNotFound();
            }
            return View(coralticket);
        }

        // POST: Coraltickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coralticket coralticket = db.Coraltickets.Find(id);
            db.Coraltickets.Remove(coralticket);
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
