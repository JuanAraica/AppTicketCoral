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
        HistoriesController carturer = new HistoriesController();

 
        public ActionResult Index()
        {
            carturer.RegistrarEvento("Se ha abierto el modulo tickets");
            return View(db.Coraltickets.ToList());
        }

 
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
            carturer.RegistrarEvento("Se ha abierto el ticket n°: "+ coralticket.idTicket);
            return View(coralticket);
        }

        // GET: Coraltickets/Create
        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTicket,Usuario,Operacion,TipoConsulta,Descripcion,Evidencia1,Evidencia2,Evidencia3,Fecha,Hora,Estado,Observacion,TIManager")] Coralticket coralticket)
        {
            if (ModelState.IsValid)
            {
                db.Coraltickets.Add(coralticket);
                db.SaveChanges();
                carturer.RegistrarEvento("Se ha Creado el ticket n°: " + coralticket.idTicket);
                return RedirectToAction("Index");
            }

            return View(coralticket);
        }

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTicket,Usuario,Operacion,TipoConsulta,Descripcion,Evidencia1,Evidencia2,Evidencia3,Fecha,Hora,Estado,Observacion,TIManager")] Coralticket coralticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coralticket).State = EntityState.Modified;
                db.SaveChanges();
                carturer.RegistrarEvento("Se ha editado el ticket n°: " + coralticket.idTicket);
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
            carturer.RegistrarEvento("Se ha eliminado el ticket n°: " + coralticket.idTicket);
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
