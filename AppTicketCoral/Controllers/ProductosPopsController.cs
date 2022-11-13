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
    public class ProductosPopsController : Controller
    {
        private TicketCoralEntities db = new TicketCoralEntities();

        // GET: ProductosPops
        public ActionResult Index()
        {
            return View(db.ProductosPops.ToList());
        }

        // GET: ProductosPops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosPop productosPop = db.ProductosPops.Find(id);
            if (productosPop == null)
            {
                return HttpNotFound();
            }
            return View(productosPop);
        }

        // GET: ProductosPops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosPops/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion,Costo,Proveedor,CCompra,Iva,SubPro")] ProductosPop productosPop)
        {
            if (ModelState.IsValid)
            {
                db.ProductosPops.Add(productosPop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productosPop);
        }

        // GET: ProductosPops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosPop productosPop = db.ProductosPops.Find(id);
            if (productosPop == null)
            {
                return HttpNotFound();
            }
            return View(productosPop);
        }

        // POST: ProductosPops/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion,Costo,Proveedor,CCompra,Iva,SubPro")] ProductosPop productosPop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosPop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productosPop);
        }

        // GET: ProductosPops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosPop productosPop = db.ProductosPops.Find(id);
            if (productosPop == null)
            {
                return HttpNotFound();
            }
            return View(productosPop);
        }

        // POST: ProductosPops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductosPop productosPop = db.ProductosPops.Find(id);
            db.ProductosPops.Remove(productosPop);
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
