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
    public class EmpleadosPopsController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();

        // GET: EmpleadosPops
        public ActionResult Index()
        {
            return View(db.EmpleadosPops.ToList());
        }

        // GET: EmpleadosPops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosPop empleadosPop = db.EmpleadosPops.Find(id);
            if (empleadosPop == null)
            {
                return HttpNotFound();
            }
            return View(empleadosPop);
        }

        // GET: EmpleadosPops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosPops/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NoEmpleado,BadgeID,Nombre,Empresa,Departamento,Imagen,Subsidio,Cantidad,Auto,Fecha,Planta,TipoPago,CentroCostos,PasswordEmp,Estado,TipoSubsidio,DesbloqueoSub,SubAct,EstadoEmp")] EmpleadosPop empleadosPop)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadosPops.Add(empleadosPop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleadosPop);
        }

        // GET: EmpleadosPops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosPop empleadosPop = db.EmpleadosPops.Find(id);
            if (empleadosPop == null)
            {
                return HttpNotFound();
            }
            return View(empleadosPop);
        }

        // POST: EmpleadosPops/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NoEmpleado,BadgeID,Nombre,Empresa,Departamento,Imagen,Subsidio,Cantidad,Auto,Fecha,Planta,TipoPago,CentroCostos,PasswordEmp,Estado,TipoSubsidio,DesbloqueoSub,SubAct,EstadoEmp")] EmpleadosPop empleadosPop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadosPop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleadosPop);
        }

        // GET: EmpleadosPops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosPop empleadosPop = db.EmpleadosPops.Find(id);
            if (empleadosPop == null)
            {
                return HttpNotFound();
            }
            return View(empleadosPop);
        }

        // POST: EmpleadosPops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadosPop empleadosPop = db.EmpleadosPops.Find(id);
            db.EmpleadosPops.Remove(empleadosPop);
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
