using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AppTicketCoral.Models;

namespace AppTicketCoral.Controllers
{
    public class EmpleadosController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();
        HistoriesController carturer = new HistoriesController();
  
        public ActionResult Index()
        {

            return View(db.Empleados.ToList());
        }

     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

 
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTicket,NoEmpleado,BadgeID,Nombre,Empresa,Departamento,Imagen,Subsidio,Cantidad,Auto,Fecha,Planta,TipoPago,CentroCostos,PasswordEmp,Estado,TipoSubsidio,DesbloqueoSub,SubAct,EstadoEmp")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                carturer.RegistrarEvento("Se ha creado el registro de empleado n°: " + empleado.idTicket);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTicket,NoEmpleado,BadgeID,Nombre,Empresa,Departamento,Imagen,Subsidio,Cantidad,Auto,Fecha,Planta,TipoPago,CentroCostos,PasswordEmp,Estado,TipoSubsidio,DesbloqueoSub,SubAct,EstadoEmp")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                carturer.RegistrarEvento("Se ha editado el registro de empleado n°: " + empleado.idTicket);
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }
 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
            db.SaveChanges();
            carturer.RegistrarEvento("Se ha eliminado el registro de empleado n°: " + empleado.idTicket);
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
