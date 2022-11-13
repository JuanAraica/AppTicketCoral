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
    public class EmpleadosBayersController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();

        // GET: EmpleadosBayers
        public ActionResult Index()
        {
            return View(db.EmpleadosBayers.ToList());
        }

        // GET: EmpleadosBayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosBayer empleadosBayer = db.EmpleadosBayers.Find(id);
            if (empleadosBayer == null)
            {
                return HttpNotFound();
            }
            return View(empleadosBayer);
        }

        // GET: EmpleadosBayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosBayers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NoEmpleado,BadgeID,Nombre,Empresa,Departamento,Imagen,Subsidio,Cantidad,Auto,Fecha,Direccion,Unidad,TipoSubsidio,Gerencia,DesbloqueoSub,SubAct,IDSap,TipoPago,EstadoEmp")] EmpleadosBayer empleadosBayer)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadosBayers.Add(empleadosBayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleadosBayer);
        }

        // GET: EmpleadosBayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosBayer empleadosBayer = db.EmpleadosBayers.Find(id);
            if (empleadosBayer == null)
            {
                return HttpNotFound();
            }
            return View(empleadosBayer);
        }

        // POST: EmpleadosBayers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NoEmpleado,BadgeID,Nombre,Empresa,Departamento,Imagen,Subsidio,Cantidad,Auto,Fecha,Direccion,Unidad,TipoSubsidio,Gerencia,DesbloqueoSub,SubAct,IDSap,TipoPago,EstadoEmp")] EmpleadosBayer empleadosBayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadosBayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleadosBayer);
        }

        // GET: EmpleadosBayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosBayer empleadosBayer = db.EmpleadosBayers.Find(id);
            if (empleadosBayer == null)
            {
                return HttpNotFound();
            }
            return View(empleadosBayer);
        }

        // POST: EmpleadosBayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadosBayer empleadosBayer = db.EmpleadosBayers.Find(id);
            db.EmpleadosBayers.Remove(empleadosBayer);
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
